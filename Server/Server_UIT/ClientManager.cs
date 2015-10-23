using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using _Command;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Enum;
using System.Data;
using BUS;
using DTO;

namespace Server_UIT
{
    public class ClientManager
    {
        private IPAddress _ipAdress;//địa chỉ Ip client
        public IPAddress ipAdress
        {
            get { return _ipAdress; }
            set { _ipAdress = value; }
        }
        private int _Port;//port của lient
        public int Port
        {
            get { return _Port; }
            set { _Port = value; }
        }
        private string _userName;
        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        Form1 _form1;
        Chat chat = null;

        public Chat Chat
        {
            get { return chat; }
            set { chat = value; }
        }
        public Socket socket;//kết nối giữa client-server
        private NetworkStream stream;//dùng để nhận và gởi tin
        private BackgroundWorker bw_receive;//thread dùng để nhận tin nhắn từ
        public ClientManager(Form1 form1, Socket _temp)
        {
            _form1 = form1;
            socket = _temp;
            this._Port = ((IPEndPoint)this.socket.RemoteEndPoint).Port;
            this._ipAdress = ((IPEndPoint)this.socket.RemoteEndPoint).Address;
            stream = new NetworkStream(socket);
            //tạo tiểu trình sẵn sàng nhận tin nhắn
            bw_receive = new BackgroundWorker();
            bw_receive.DoWork += bw_receive_DoWork;
            bw_receive.RunWorkerAsync();

        }
        public  void Online(string user)
        {
            //khi có 1 client kết nối thành công thì tìm user này trong list các ShowClient
            //và thay đổi backcolor của show client đó
            //và gán ClientManager vào cho showclinet để biết tab client đó thuộc kết nối nào
            for (int i = 0; i < Form1.lstShowClient.Count; i++)
            {
                if (Form1.lstShowClient[i]._username == user)
                {
                    Form1.lstShowClient[i].BackColor = System.Drawing.Color.LimeGreen;
                    Form1.lstShowClient[i]._cm = this;
                }
            }
        }
        public void Offline(string user)
        {
          
            for (int i = 0; i < Form1.lstShowClient.Count; i++)
            {
                if (Form1.lstShowClient[i]._username == user)
                {
                    //tìm user vừa thoát và làm đỏ ShowClient .
                    //gán cho CLientManger trong show client là null
                    Form1.lstShowClient[i].BackColor = System.Drawing.Color.Firebrick;
                    Form1.lstShowClient[i]._cm = null;
                    
                }
            }
            for (int i = 0; i < Form1.listClient.Count;i++ )
            {
                //tìm user vừa thoát kết nối và remove khỏi list client
                if (Form1.listClient[i].userName == user)
                    Form1.listClient.Remove(Form1.listClient[i]);
            }

        }
        //hàm kiểm tra xem user này đã online chưa
        public  bool IsOnline(string cm)
        {
            foreach (var s in Form1.listClient)
            {
                if (s.userName == cm)
                    return true;
            }
            return false;
        }
       
        //hàm chính trong tiểu trình nhận thông điệp
         public void bw_receive_DoWork(object sender, DoWorkEventArgs e)
        {
            while (socket.Connected)
            {
                try
                {
                    string user;//lưu tên người dùng vừa đăng nhập
                    //lưu thong tin tài khoản đăng kí
                    string account;
                    string username;
                    string password;
                    string email;
                    //end
                    byte[] buffer = new byte[4];
                    byte[] data;//lưu byte của tin nhắn dạng chữ
                    byte[] dataPicture = new byte[10000];
                    NetworkStream stream;
                    stream = new NetworkStream(socket);
                    stream.Read(buffer, 0, 4);
                    CommandType_ cmt;
                    cmt = (CommandType_)BitConverter.ToInt32(buffer, 0);
                    //if client vừa kết nối muốn đăng nhập
                    if (cmt == CommandType_.Login)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        account = Encoding.ASCII.GetString(data);
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        password = Encoding.ASCII.GetString(data);
                        //kiểm tra xem trong database có đúng tài khoản mật khẩu hay ko
                        DataTable dt = new DataTable();
                        dt = Khachhang_BUS.Dangnhap(account, password);
                        if (dt.Rows.Count > 0)
                        {
                            //nếu đúng thì lấy username của tài khoản vừa đang nhâp
                            user = dt.Rows[0][1].ToString();
                            //kiểm tra client này đã có kết nối trước chưa
                            if (!IsOnline(user))
                            {
                                //nếu chưa từng kết nối
                                this.userName = user;
                                buffer = BitConverter.GetBytes((int)CommandType_.LoginSuccess);//gởi tin nhắn là đã chấp nhận kết nối
                                stream.Write(buffer, 0, 4);
                                stream.Flush();
                                //gởi tên user qua cho client
                                data = new byte[user.Length];
                                buffer = BitConverter.GetBytes(user.Length);
                                stream.Write(buffer, 0, 4);
                                stream.Flush();
                                data = Encoding.ASCII.GetBytes(user);
                                stream.Write(data, 0, user.Length);
                                stream.Flush();
                                
                                
                                //gởi avatar cho user
                                
                                dataPicture = (byte[])dt.Rows[0][5];
                                lengh = dataPicture.Length;
                                buffer=BitConverter.GetBytes(lengh);
                                stream.Write(buffer, 0, 4);
                                stream.Flush();
                                stream.Write(dataPicture, 0, lengh);
                                stream.Flush();
                                Online(user);

                                //gởi list danh sách bạn
                                dt = Khachhang_BUS.Loadds_FRIEND(user);
                                int _CountTemp;//lưu số lượng friend của user
                                _CountTemp = dt.Rows.Count;
                                buffer = BitConverter.GetBytes(_CountTemp);
                                stream.Write(buffer, 0, 4);
                                stream.Flush();
                                for (int i = 0; i < _CountTemp; i++)
                                {
                                    //gởi tên userFriend
                                    buffer = BitConverter.GetBytes( dt.Rows[i][0].ToString().Length);
                                    stream.Write(buffer, 0, 4);
                                    stream.Flush();
                                    data = new byte[dt.Rows[i][0].ToString().Length];
                                    data = Encoding.ASCII.GetBytes(dt.Rows[i][0].ToString());
                                    stream.Write(data, 0, dt.Rows[i][0].ToString().Length);
                                    stream.Flush();


                                    //gởi avatar cho user

                                    dataPicture = (byte[])dt.Rows[i][1];
                                    lengh = dataPicture.Length;
                                    buffer = BitConverter.GetBytes(lengh);
                                    stream.Write(buffer, 0, 4);
                                    stream.Flush();
                                    stream.Write(dataPicture, 0, lengh);
                                    stream.Flush();
                                }
                                ////lưu client vào List  client
                                Form1.listClient.Add(this);
                            }
                            else
                            {
                                //client này đã kết nối ,gởi tin nhắn đăng nhập đã tồn tại
                                buffer = BitConverter.GetBytes((int)CommandType_.NameExists);
                                stream.Write(buffer, 0, 4);
                                stream.Flush();
                            }
                        }
                        else
                        {
                            //nếu tài khoản hoặc mật khẩu không đúng
                            buffer = BitConverter.GetBytes((int)CommandType_.Failure);//gởi tin nhắn là kết nối ko thành công
                            stream.Write(buffer, 0, 4);
                            stream.Flush();
                        }
                    }
                    if (cmt == CommandType_.Register)
                    {
                        //đọc username
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        username = Encoding.ASCII.GetString(data);
                        //đọc account
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        account = Encoding.ASCII.GetString(data);
                        //đọc password
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        password = Encoding.ASCII.GetString(data);
                        //đọc email
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        email = Encoding.ASCII.GetString(data);
                        //kiểm tra tên người dùng và tài khoản có tồn tại chưa
                        DataTable da = new DataTable(); 
                        da =Khachhang_BUS.Kiemtra_Dangki(account, username);
                        if (da.Rows.Count > 0)
                        {
                            buffer = BitConverter.GetBytes((int)CommandType_.RegisterFailure);//gởi tin nhắn là đăng kí thất bại
                            stream.Write(buffer, 0, 4);
                            stream.Flush();
                        }
                        else
                        {
                            Image _imageTemp = (Image)Properties.Resources.ResourceManager.GetObject("_default");
                            MemoryStream ms=new MemoryStream();
                            ImageConverter imageConvert = new ImageConverter();
                            data = new byte[10000];
                            data = (byte[])imageConvert.ConvertTo(_imageTemp, typeof(byte[]));
                            //data = ms.ToArray();
                            KhachHang_DTO kh_dto = new KhachHang_DTO(account, password, username, data, email);
                            Khachhang_BUS.Add_kh(kh_dto);
                            buffer = BitConverter.GetBytes((int)CommandType_.RegisterSuccess);//gởi tin nhắn là đăng kí thành công
                            stream.Write(buffer, 0, 4);
                            stream.Flush();
                            _form1.AddShowClient(username);
                        }
                    }
                    //nếu thông điệp nhận được là 1 tin nhắn
                    if (cmt == CommandType_.Message)
                    {
                        //đọc nội dung tin nhắn
                        string cmdMetaData = "";
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        byte[] metaBuffer = new byte[lenght];
                        stream.Read(metaBuffer, 0, lenght);
                        cmdMetaData = Encoding.ASCII.GetString(metaBuffer);
                        //đọc font
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        metaBuffer = new byte[lenght];
                        stream.Read(metaBuffer, 0, lenght);
                       //convert byte sang font
                        MemoryStream s = new MemoryStream(metaBuffer);
                        BinaryFormatter bf = new BinaryFormatter();
                        Font temp = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
                        temp = (Font)bf.Deserialize(s);
                        //gọi form chat thông qua delegate
                        _form1.Invoke(new Action(delegate()
                        {
                           // nếu chưa tồn tại hoặc đã BỊ tắt thÌ khởi tạo lại
                            if (chat == null || chat.IsDisposed)
                            {
                                chat = new Chat(this);
                                chat.Show();
                            }
                        }));
                        //gởi yin nhắn đã nhận được cho form chat vừa khởi tạo để hiển thị lên form
                        chat.Receive(cmdMetaData, temp);
                    }
                }
                catch
                {
                    //kết nối bên client bị đóng
                    Offline(this._userName);

                }
            }
             //đóng kết nồi
            socket.Close();
            //Form1.listClient[1]._userName = "asdas";
        }
        //gởi tin nhắn đi
        public void SendCommand(Command cmd)
        {
            if (this.socket != null && this.socket.Connected)
            {
                //tạo tiểu trình gởi tin nhắn
                BackgroundWorker bwSender = new BackgroundWorker();
                bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
                //bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
                bwSender.RunWorkerAsync(cmd);
            }
        }
        //hàm chạy trong tiểu trình
        private void bwSender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command cmd = (Command)e.Argument;
            if (cmd.commandBody == null || cmd.commandBody == "")
                cmd.commandBody = "\n";
            byte[] metaBuffer = Encoding.ASCII.GetBytes(cmd.commandBody);
            byte[] buffer = new byte[4];
            //gởi thông điệp là tin nhắn cho bên nhận biết
            buffer = BitConverter.GetBytes((int)CommandType_.Message);
            stream.Write(buffer, 0, 4);
            stream.Flush();
            //gởi nội dung tin nhắn
            buffer=BitConverter.GetBytes(metaBuffer.Length);
            stream.Write(buffer, 0, 4);
            this.stream.Flush();
            this.stream.Write(metaBuffer, 0, cmd.commandBody.Length);
            this.stream.Flush();
            //convert font để gởi
            MemoryStream s = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, cmd.Fontsyle);
            //send font
            metaBuffer = new byte[1024];
            metaBuffer = s.ToArray();
            buffer = BitConverter.GetBytes(metaBuffer.Length);
            stream.Write(buffer, 0, 4);
            this.stream.Flush();
            stream.Write(metaBuffer, 0, metaBuffer.Length);
            this.stream.Flush();

        }
    }
}
