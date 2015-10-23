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

namespace Client_UIT
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
        public Form1 _frmMain;
        public Chat chatForm = null;
        public Dangnhap dangnhapForm = null;
        public Socket socket;//kết nối giữa client-server
        private NetworkStream stream;//dùng để nhận và gởi tin
        private BackgroundWorker bw_receive;//thread dùng để nhận tin nhắn từ
        public ClientManager(Dangnhap _dangnhap,Socket _temp)
        {
            dangnhapForm = _dangnhap;
            socket = _temp;
            this._Port = ((IPEndPoint)this.socket.RemoteEndPoint).Port;
            this._ipAdress = ((IPEndPoint)this.socket.RemoteEndPoint).Address;
            stream = new NetworkStream(socket);
            bw_receive = new BackgroundWorker();
            bw_receive.DoWork += bw_receive_DoWork;
            bw_receive.RunWorkerAsync();

        }
        public void bw_receive_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[4];

            while (socket.Connected)
            {
                try
                {
                    //đọc thông điệp server chuyễn đến
                    stream.Read(buffer, 0, 4);
                    CommandType_ cmt = (CommandType_)BitConverter.ToInt32(buffer, 0);
                    if (cmt == CommandType_.Message)
                    {

                        string cmdMetaData = "";
                        buffer = new byte[4];
                        //đọc nội dung tin nhắn
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
                        MemoryStream s = new MemoryStream(metaBuffer);
                        BinaryFormatter bf = new BinaryFormatter();
                        Font temp = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
                        temp = (Font)bf.Deserialize(s);
                        _frmMain.Invoke(new Action(delegate()
                            {
                                if (chatForm == null || chatForm.IsDisposed)
                                {
                                    chatForm = new Chat(this);
                                    chatForm.Text = "Server";
                                    chatForm.Show();
                                }
                            }));

                        chatForm.Receive(cmdMetaData, temp);
                    }//end message
                    if (cmt == CommandType_.LoginSuccess)
                    {
                        byte[] data;
                        byte[] dataPicture;
                        //đọc tên username
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string username = Encoding.ASCII.GetString(data);
                        this._userName=username;
                        
                        
                        //đọc avatar
                        Image image;
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        dataPicture = new byte[lenght];
                        stream.Read(dataPicture, 0, lenght);
                        MemoryStream mem = new MemoryStream(dataPicture);
                        image = Image.FromStream(mem);
                        

                        //Đăng nhập thành công
                        //Khởi tạo form chính
                        dangnhapForm.Invoke(new Action(delegate()
                        {

                            {
                                _frmMain = new Form1(dangnhapForm, this._userName, image);
                                _frmMain.Text = "Server";
                                _frmMain.Show();
                                dangnhapForm.Hide();
                            }
                        }));
                        //load list friend
                        //đọc thông tin list Friend

                        //--Đọc số lượng friend của user 
                        stream.Read(buffer, 0, 4);
                        int _CountTemp;
                        _CountTemp = BitConverter.ToInt32(buffer, 0);
                        for (int i = 0; i < _CountTemp;i++ )
                        {
                            stream.Read(buffer, 0, 4);
                           lenght = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lenght];
                            stream.Read(data, 0, lenght);
                            string usernameFriend = Encoding.ASCII.GetString(data);
                            


                            //đọc avatar
                            Image _avatarFriend;
                            stream.Read(buffer, 0, 4);
                            lenght = BitConverter.ToInt32(buffer, 0);
                            dataPicture = new byte[lenght];
                            stream.Read(dataPicture, 0, lenght);
                            MemoryStream memTemp = new MemoryStream(dataPicture);
                            _avatarFriend = Image.FromStream(memTemp);
                            _frmMain.update_listFriend(usernameFriend, _avatarFriend);

                        }
                           
                        
                    }//End LoginSuccess
                    if (cmt == CommandType_.NameExists)
                    {
                        MessageCustom.Show("Tài khoản bạn đã được đang nhập bởi người khác!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                    if (cmt == CommandType_.Failure)
                    {
                        MessageCustom.Show("Tài khoản hoặc mật khẩu không đúng!", "Error", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                    if(cmt==CommandType_.RegisterFailure)
                    {
                        MessageCustom.Show("Tài khoản hoặc tên người dùng đã tồn tại!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                    if (cmt == CommandType_.RegisterSuccess)
                    {
                        MessageCustom.Show("Đăng kí thành công!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                }
                catch
                {
                    MessageCustom.Show("Server đang bảo trì !", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                }
            }//end while
        }
        public void SendCommand(Command cmd)
        {
            if (this.socket != null && this.socket.Connected)
            {
                BackgroundWorker bwSender = new BackgroundWorker();
                bwSender.DoWork += new DoWorkEventHandler(bwSender_DoWork);
                //bwSender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwSender_RunWorkerCompleted);
                bwSender.RunWorkerAsync(cmd);
            }
        }
        private void bwSender_DoWork(object sender, DoWorkEventArgs e)
        {
            Command cmd = (Command)e.Argument;
            if (cmd.commandBody == null || cmd.commandBody == "")
                cmd.commandBody = "\n";
            byte[] metaBuffer = Encoding.ASCII.GetBytes(cmd.commandBody);
            byte[] buffer = new byte[4];
            buffer = BitConverter.GetBytes((int)CommandType_.Message);//gởi tin nhắn là đăng kí thất bại
            stream.Write(buffer, 0, 4);
            stream.Flush();
            buffer = BitConverter.GetBytes(metaBuffer.Length);
            stream.Write(buffer, 0, 4);
            this.stream.Flush();
            this.stream.Write(metaBuffer, 0, cmd.commandBody.Length);
            this.stream.Flush();
            MemoryStream s = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, cmd.Fontsyle);
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
