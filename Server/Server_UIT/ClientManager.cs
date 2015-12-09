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
        public void Online(string user)
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
                    Form1.lstShowClient[i].Online = true;
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
                    Form1.lstShowClient[i].Online = false;

                }
            }
            for (int i = 0; i < Form1.listClient.Count; i++)
            {
                //tìm user vừa thoát kết nối và remove khỏi list client
                if (Form1.listClient[i].userName == user)
                    Form1.listClient.Remove(Form1.listClient[i]);
            }

        }
        //hàm kiểm tra xem user này đã online chưa
        public ClientManager IsOnline(string cm)
        {
            foreach (var s in Form1.lstShowClient)
            {
                if (s._username == cm)
                    if (s.Online)
                    {
                        return s._cm;

                    }
                    else
                    {
                        return null;
                    }
            }
            return null;
        }

        //hàm chính trong tiểu trình nhận thông điệp
        public void bw_receive_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt_friend=null;
            while (socket.Connected)
            {
                try
                {
                    //lưu thong tin tài khoản đăng kí
                    string accountTemp;
                    string usernameTemp;
                    string passwordTemp;
                    string emailTemp;
                    //end
                    byte[] buffer = new byte[4];
                    byte[] data;//lưu byte của tin nhắn dạng chữ
                    byte[] dataPicture = new byte[10000];
                    int lengh;
                    stream.Read(buffer, 0, 4);
                    CommandType_ cmt;
                    cmt = (CommandType_)BitConverter.ToInt32(buffer, 0);
                    //if client vừa kết nối muốn đăng nhập
                    if (cmt == CommandType_.Login)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        accountTemp = Encoding.ASCII.GetString(data);
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        passwordTemp = Encoding.ASCII.GetString(data);
                        //kiểm tra xem trong database có đúng tài khoản mật khẩu hay ko
                        DataTable dt = new DataTable();
                        dt = Khachhang_BUS.Dangnhap(accountTemp, passwordTemp);
                        if (dt.Rows.Count > 0)
                        {
                            //nếu đúng thì lấy username của tài khoản vừa đang nhâp
                            this.userName = dt.Rows[0][1].ToString();
                            //kiểm tra client này đã có kết nối chưa
                            if (IsOnline(this.userName) == null)
                            {
                                //đăng nhập thành công và gởi danh sách bạn
                                Command cmd = new Command(CommandType_.LoginSuccess, this.userName, (byte[])dt.Rows[0][5],null);
                                SendCommand(cmd);
                                dt_friend = Khachhang_BUS.Loadds_FRIEND(this.userName);
                                cmd = new Command(CommandType_.ListFriend, dt_friend);
                                SendCommand(cmd);
                                //nếu chưa kết nối5
                                Online(this.userName);
                                ////lưu client vào List  client
                                Form1.listClient.Add(this);
                            }
                            else
                            {
                                //tài khoản này đã được đăng nhập bởi người khác
                                Command cmd = new Command(CommandType_.NameExists);
                                this.SendCommand(cmd);
                            }
                        }
                        else
                        {
                            //đăng nhập thất bại.tài khoản hoặc mật khẩu không đúng
                            Command cmd = new Command(CommandType_.Failure);
                            this.SendCommand(cmd);
                        }
                    }
                    //đăng kí 1 tài khoản mới
                    if (cmt == CommandType_.Register)
                    {
                        //đọc username
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        usernameTemp = Encoding.ASCII.GetString(data);
                        //đọc account
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        accountTemp = Encoding.ASCII.GetString(data);
                        //đọc password
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        passwordTemp = Encoding.ASCII.GetString(data);
                        //đọc email
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        emailTemp = Encoding.ASCII.GetString(data);
                        //kiểm tra tên người dùng và tài khoản có tồn tại chưa
                        DataTable da = new DataTable();
                        da = Khachhang_BUS.Kiemtra_Dangki(accountTemp, usernameTemp);
                        if (da.Rows.Count > 0)
                        {
                            Command cmd = new Command(CommandType_.RegisterFailure);
                            this.SendCommand(cmd);
                        }
                        else
                        {
                            Image _imageTemp = (Image)Properties.Resources.ResourceManager.GetObject("_default");
                            MemoryStream ms = new MemoryStream();
                            ImageConverter imageConvert = new ImageConverter();
                            data = new byte[10000];
                            data = (byte[])imageConvert.ConvertTo(_imageTemp, typeof(byte[]));
                            //data = ms.ToArray();
                            KhachHang_DTO kh_dto = new KhachHang_DTO(accountTemp, passwordTemp, usernameTemp, data, emailTemp);
                            Khachhang_BUS.Add_kh(kh_dto);

                            Command cmd = new Command(CommandType_.RegisterSuccess);
                            this.SendCommand(cmd);
                            _form1.AddShowClient(usernameTemp);
                        }
                    }
                    //nếu thông điệp nhận được là 1 tin nhắn trao đổi với server
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
                    //tin nhắn trao đổi giữa những người trong danh sách bạn
                    if (cmt == CommandType_.MessageFriend)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        usernameTemp = Encoding.ASCII.GetString(data);

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
                        Command cmd = new Command(CommandType_.MessageFriend, this.userName, cmdMetaData, temp);
                        ClientManager clm=null;
                        for (int i = 0; i < Form1.listClient.Count;i++ )
                        {
                            if(Form1.listClient[i].userName==usernameTemp)
                            {
                                clm = Form1.listClient[i];
                                break;
                            }
                        }
                        clm.SendCommand(cmd);
                    }
                    if (cmt == CommandType_.ListFriend)
                    {
                       dt_friend = Khachhang_BUS.Loadds_FRIEND(this.userName);
                       Command cmd = new Command(CommandType_.ListFriend, dt_friend);
                       this.SendCommand(cmd);
                    }
                    if(cmt==CommandType_.FindFriend)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        lengh = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lengh];
                        stream.Read(data, 0, lengh);
                        usernameTemp = Encoding.ASCII.GetString(data);
                       DataTable dt= Khachhang_BUS.FindFriend(usernameTemp);
                       //có tồn tại username này trong danh sách --trả thông tin của username này về cho client
                        if(dt.Rows.Count>0)
                        {
                            Command cmd = new Command(CommandType_.Found, dt.Rows[0][1].ToString(),dt.Rows[0][4].ToString(),(byte[])dt.Rows[0][5]);
                            this.SendCommand(cmd);
                        }
                        else
                        {
                            Command cmd = new Command(CommandType_.NotFound);
                            this.SendCommand(cmd);
                        }
                    }
                    if (cmt == CommandType_.LoadNotice)
                    {
                        DataTable dt = Khachhang_BUS.LoadNotice(this.userName);

                        Command cmd = new Command(CommandType_.LoadNotice, dt);
                        this.SendCommand(cmd);

                    }
                    if (cmt == CommandType_.AddNotice)
                    {
                        
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userPrimary = Encoding.ASCII.GetString(data);

                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userReference = Encoding.ASCII.GetString(data);

                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _type = Encoding.ASCII.GetString(data);
                        string _time= DateTime.Now.ToString();
                        NOTICE_DTO notice = new NOTICE_DTO(_userPrimary, _userReference, _type, "", _time);
                        DataTable dt= Khachhang_BUS.AddNotice(notice);
                        if (int.Parse(dt.Rows[0][0].ToString()) == 0)
                        {
                            Command cmd = new Command(CommandType_.AddFriendFailure);
                            this.SendCommand(cmd);
                        }
                        if(int.Parse( dt.Rows[0][0].ToString())==1)
                        {
                            Command cmd = new Command(CommandType_.AddNoticeFailure);
                            this.SendCommand(cmd);
                        }
                        if (int.Parse(dt.Rows[0][0].ToString()) == 2)
                        {
                            Command cmd = new Command(CommandType_.AddNoticeSuccess);
                            this.SendCommand(cmd);
                        }
                    }
                    if (cmt == CommandType_.AddFriend)
                    {

                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userPrimary = Encoding.ASCII.GetString(data);

                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userReference = Encoding.ASCII.GetString(data);
                        string _time = DateTime.Now.ToString();
                        NOTICE_DTO notice = new NOTICE_DTO(_userReference, _userPrimary, "2", "", _time);
                        Khachhang_BUS.AddNotice(notice);
                        Khachhang_BUS.Add_Friend(_userPrimary, _userReference);
                        Khachhang_BUS.DeleteNotice(_userPrimary, _userReference);
                        Command cmd = new Command(CommandType_.DeleteNoticeSuccess);
                        this.SendCommand(cmd);
                        ClientManager cmTemp;
                        //gởi trạng thái của friend
                        if ((cmTemp = IsOnline(_userReference)) != null)
                        {
                            Command _cmd = new Command(CommandType_.ListFriend, Khachhang_BUS.Loadds_FRIEND(_userReference));
                            cmTemp.SendCommand(_cmd);
                        }
                    }
                    if (cmt == CommandType_.DeleteNotice)
                    {
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userPrimary = Encoding.ASCII.GetString(data);

                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string _userReference = Encoding.ASCII.GetString(data);
                        Khachhang_BUS.DeleteNotice(_userPrimary, _userReference);
                        Command cmd = new Command(CommandType_.DeleteNoticeSuccess);
                        this.SendCommand(cmd);
                    }
                }
                catch
                {
                    //kết nối bên client bị đóng
                    Offline(this._userName);
                    if ((dt_friend=Khachhang_BUS.Loadds_FRIEND(this.userName)) != null)
                    {
                        int _CountTemp;//lưu số lượng friend của user
                        _CountTemp = dt_friend.Rows.Count;
                        for (int i = 0; i < _CountTemp; i++)
                        {
                            ClientManager cmTemp;
                            //gởi trạng thái của friend
                            if ((cmTemp = IsOnline(dt_friend.Rows[i][0].ToString())) != null)
                            {
                                Command _cmd = new Command(CommandType_.Offline, this.userName);
                                cmTemp.SendCommand(_cmd);
                            }
                        }
                    }
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
        void SendLargeFile(byte[] data, NetworkStream stream)
        {
           
            byte[] bytes=new byte[1024];
            int count = data.Length/1024;
            int j = 0;
            int countTemp=count;
            while(count!=0)
            {
                for (int i = 0; i < 1024; i++)
                {
                    bytes[i]=data[j * 1024 + i];
                }
                stream.Write(bytes, 0, 1024);
                stream.Flush();
                j++;
                count--;
            }
            int byread = data.Length-countTemp*1024;
            for (int i = 0; i < byread; i++)
            {
                bytes[i] = data[j * 1024 + i];
            }
            stream.Write(bytes, 0, byread);
            stream.Flush();
        
        }
        System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1, 1);
        //hàm chạy trong tiểu trình
        private void bwSender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command cmd = (Command)e.Argument;
            byte[] buffer = new byte[4];
            byte[] metaBuffer;
            byte[] data;
            byte[] dataPicture;
            int lenght;
            semaphor.WaitOne();
            if (cmd.CommandType == CommandType_.Message)
            {
                if (cmd.commandBody == null || cmd.commandBody == "")
                    cmd.commandBody = "\n";
                metaBuffer = Encoding.ASCII.GetBytes(cmd.commandBody);

                //gởi thông điệp là tin nhắn cho bên nhận biết
                buffer = BitConverter.GetBytes((int)CommandType_.Message);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                //gởi nội dung tin nhắn
                buffer = BitConverter.GetBytes(metaBuffer.Length);
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
            if (cmd.CommandType == CommandType_.MessageFriend)
            {
                if (cmd.commandBody == null || cmd.commandBody == "")
                    cmd.commandBody = "\n";
                metaBuffer = Encoding.ASCII.GetBytes(cmd.commandBody);

                //gởi thông điệp là tin nhắn cho bên nhận biết
                buffer = BitConverter.GetBytes((int)CommandType_.MessageFriend);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Username);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                //gởi nội dung tin nhắn
                buffer = BitConverter.GetBytes(metaBuffer.Length);
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
            if (cmd.CommandType == CommandType_.LoginSuccess)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.LoginSuccess);//gởi tin nhắn là đã chấp nhận kết nối
                stream.Write(buffer, 0, 4);
                stream.Flush();

                //gởi tên user qua cho client
                data = new byte[cmd.Username.Length];
                buffer = BitConverter.GetBytes(cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Username);
                stream.Write(data, 0, cmd.Username.Length);
                stream.Flush();


                //gởi avatar cho user

                dataPicture = (byte[])cmd.Image_;
                buffer = BitConverter.GetBytes(dataPicture.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                SendLargeFile(dataPicture, stream);
                //stream.Write(dataPicture, 0, dataPicture.Length);
                stream.Flush();

                //gởi list danh sách bạn

                
            }
            if(cmd.CommandType==CommandType_.ListFriend)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.ListFriend);//gởi tin nhắn là đã chấp nhận kết nối
                stream.Write(buffer, 0, 4);
                stream.Flush();

                int _CountTemp;//lưu số lượng friend của user
                _CountTemp = cmd.Dt.Rows.Count;
                buffer = BitConverter.GetBytes(_CountTemp);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                for (int i = 0; i < _CountTemp; i++)
                {
                    //gởi tên userFriend
                    buffer = BitConverter.GetBytes(cmd.Dt.Rows[i][0].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = new byte[cmd.Dt.Rows[i][0].ToString().Length];
                    data = Encoding.ASCII.GetBytes(cmd.Dt.Rows[i][0].ToString());
                    stream.Write(data, 0, cmd.Dt.Rows[i][0].ToString().Length);
                    stream.Flush();


                    //gởi avatar cho user

                    dataPicture = (byte[])cmd.Dt.Rows[i][1];
                    buffer = BitConverter.GetBytes(dataPicture.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    SendLargeFile(dataPicture, stream);
                    //stream.Write(dataPicture, 0, dataPicture.Length);
                    stream.Flush();


                    ClientManager cmTemp;
                    //gởi trạng thái của friend
                    if ((cmTemp = IsOnline(cmd.Dt.Rows[i][0].ToString())) != null)
                    {
                        buffer = BitConverter.GetBytes((int)CommandType_.Online);
                        stream.Write(buffer, 0, 4);
                        stream.Flush();
                        Command _cmd = new Command(CommandType_.Online, this.userName);
                        cmTemp.SendCommand(_cmd);

                    }
                    else
                    {
                        buffer = BitConverter.GetBytes((int)CommandType_.Offline);
                        stream.Write(buffer, 0, 4);
                        stream.Flush();
                    }
                }
            }
            if (cmd.CommandType == CommandType_.NameExists)
            {
                //client này đã kết nối ,gởi tin nhắn đăng nhập đã tồn tại
                buffer = BitConverter.GetBytes((int)CommandType_.NameExists);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.Failure)
            {
                //nếu tài khoản hoặc mật khẩu không đúng
                buffer = BitConverter.GetBytes((int)CommandType_.Failure);//gởi tin nhắn là kết nối ko thành công
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.Register)
            {

            }
            if (cmd.CommandType == CommandType_.RegisterSuccess)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.RegisterSuccess);//gởi tin nhắn là đăng kí thành công
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.RegisterFailure)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.RegisterFailure);//gởi tin nhắn là đăng kí thất bại
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.Online)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.Online);//gởi tin nhắn là đăng kí thất bại
                stream.Write(buffer, 0, 4);
                stream.Flush();

                buffer = BitConverter.GetBytes(cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = new byte[cmd.Username.Length];
                data = Encoding.ASCII.GetBytes(cmd.Username);
                stream.Write(data, 0, cmd.Username.Length);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.Offline)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.Offline);//gởi tin nhắn là đăng kí thất bại
                stream.Write(buffer, 0, 4);
                stream.Flush();

                buffer = BitConverter.GetBytes(cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = new byte[cmd.Username.Length];
                data = Encoding.ASCII.GetBytes(cmd.Username);
                stream.Write(data, 0, cmd.Username.Length);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.Found)
            {
                //gởi thông điệp là tin nhắn cho bên nhận biết
                buffer = BitConverter.GetBytes((int)CommandType_.Found);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                //gởi tên username
                data = new byte[cmd.Username.Length];
                buffer = BitConverter.GetBytes(cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Username);
                stream.Write(data, 0, cmd.Username.Length);
                stream.Flush();

                //gởi email
                data = new byte[cmd.Email.Length];
                buffer = BitConverter.GetBytes(cmd.Email.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Email);
                stream.Write(data, 0, cmd.Email.Length);
                stream.Flush();

                //gởi avatar 

                dataPicture = (byte[])cmd.Image_;
                buffer = BitConverter.GetBytes(dataPicture.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                SendLargeFile(dataPicture, stream);
                //stream.Write(dataPicture, 0, dataPicture.Length);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.NotFound)
            {
                //gởi thông điệp là tin nhắn cho bên nhận biết
                buffer = BitConverter.GetBytes((int)CommandType_.NotFound);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.LoadNotice)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.LoadNotice);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                DataTable dt = cmd.Dt;
                buffer = BitConverter.GetBytes(dt.Rows.Count);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    //stt
                    buffer = BitConverter.GetBytes((int)dt.Rows[i][0]);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();

                    //userPrimary
                    data = new byte[dt.Rows[i][1].ToString().Length];
                    buffer = BitConverter.GetBytes(dt.Rows[i][1].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = Encoding.ASCII.GetBytes(dt.Rows[i][1].ToString());
                    stream.Write(data, 0, dt.Rows[i][1].ToString().Length);
                    stream.Flush();

                    data = new byte[dt.Rows[i][2].ToString().Length];
                    buffer = BitConverter.GetBytes(dt.Rows[i][2].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = Encoding.ASCII.GetBytes(dt.Rows[i][2].ToString());
                    stream.Write(data, 0, dt.Rows[i][2].ToString().Length);
                    stream.Flush();

                    data = new byte[dt.Rows[i][3].ToString().Length];
                    buffer = BitConverter.GetBytes(dt.Rows[i][3].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = Encoding.ASCII.GetBytes(dt.Rows[i][3].ToString());
                    stream.Write(data, 0, dt.Rows[i][3].ToString().Length);
                    stream.Flush();

                    data = new byte[dt.Rows[i][4].ToString().Length];
                    buffer = BitConverter.GetBytes(dt.Rows[i][4].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = Encoding.ASCII.GetBytes(dt.Rows[i][4].ToString());
                    stream.Write(data, 0, dt.Rows[i][4].ToString().Length);
                    stream.Flush();

                    data = new byte[dt.Rows[i][5].ToString().Length];
                    buffer = BitConverter.GetBytes(dt.Rows[i][5].ToString().Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = Encoding.ASCII.GetBytes(dt.Rows[i][5].ToString());
                    stream.Write(data, 0, dt.Rows[i][5].ToString().Length);
                    stream.Flush();

                }
            }
            if (cmd.CommandType == CommandType_.DeleteNoticeSuccess)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.DeleteNoticeSuccess);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.AddNoticeSuccess)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.AddNoticeSuccess);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.AddNoticeFailure)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.AddNoticeFailure);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            semaphor.Release();
        }

    }
}
