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
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Enum;

namespace Client_UIT
{
    public class Notice_List
    {
        public int _stt;
        public string _userPrimary;
        public string _userReference;
        public string _type;
        public string _content;
        public string _time;

       

        public Notice_List(int stt, string userPrimary, string userReference, string type, string time)
        {

            _userPrimary = userPrimary;
            _userReference = userReference;

            _stt = stt;
            _type = type;
        }
    }
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
        public static List<Chat> listFormChat = new List<Chat>();
        public Dangnhap dangnhapForm = null;
        public FindFriend ff_Form = null;
        public Form_Notice Notice_frm = null;
        public Socket socket;//kết nối giữa client-server
        private NetworkStream stream;//dùng để nhận và gởi tin
        private BackgroundWorker bw_receive;//thread dùng để nhận tin nhắn từ
        public bool _check = true;
        BinaryFormatter bf = new BinaryFormatter();
        public ClientManager(Dangnhap _dangnhap, Socket _temp)
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
        void ReadBigData(NetworkStream stream, int lenght, ref byte[] dataPicture)
        {
            byte[] bytes = new byte[1024];
            int count = lenght / 1024;
            int j = 0;
            int countTemp = count;
            while (count != 0)
            {
                stream.Read(bytes, 0, 1024);
                for (int i = 0; i < 1024; i++)
                {
                    dataPicture[j * 1024 + i] = bytes[i];
                }
                j++;
                count--;
            }
            int byread = stream.Read(bytes, 0, lenght - countTemp * 1024);
            for (int i = 0; i < byread; i++)
            {
                dataPicture[j * 1024 + i] = bytes[i];
            }
        }
        public static Chat IsShow(string userForm)
        {
            foreach (var s in listFormChat)
            {
                if (s._usernameReference == userForm)
                {
                    return s;
                }
            }
            return null;
        }
        public void bw_receive_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[4];
            byte[] data = null;
            string usernameTemp;
            bool check_addMessage = false;
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
                        Chat chatForm = null;
                        _frmMain.Invoke(new Action(delegate()
                        {
                            if ((chatForm = IsShow("Server")) == null)
                            {
                                chatForm = new Chat(this, "Server");
                                chatForm.Text = "Server";
                                chatForm.Show();
                                listFormChat.Add(chatForm);
                            }
                        }));
                        chatForm.Receive("Server", cmdMetaData, temp);
                    }//end message

                    if (cmt == CommandType_.LoadMessage)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int count = BitConverter.ToInt16(buffer, 0);
                        if (count > 0)
                        {
                            buffer = new byte[4];
                            stream.Read(buffer, 0, 4);
                            int lengh = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lengh];
                            stream.Read(data, 0, lengh);
                            usernameTemp = Encoding.ASCII.GetString(data);
                            LinkedList<MessageText> listmessageTemp = new System.Collections.Generic.LinkedList<MessageText>();
                            for (int i = 0; i < count; i++)
                            {
                                buffer = new byte[4];
                                stream.Read(buffer, 0, 4);
                                lengh = BitConverter.ToInt32(buffer, 0);
                                data = new byte[lengh];
                                stream.Read(data, 0, lengh);
                                string content = Encoding.ASCII.GetString(data);


                                stream.Read(buffer, 0, 4);
                                int lenght = BitConverter.ToInt32(buffer, 0);
                                data = new byte[lenght];
                                stream.Read(data, 0, lenght);
                                MemoryStream s = new MemoryStream(data);
                                s.Position = 0;
                                BinaryFormatter bf = new BinaryFormatter();
                                Font temp = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
                                temp = (Font)bf.Deserialize(s);

                                buffer = new byte[4];
                                stream.Read(buffer, 0, 4);
                                int type = BitConverter.ToInt16(buffer, 0);
                                MessageText mst = new MessageText(content, temp, type);

                                listmessageTemp.AddLast(mst);

                            }
                            foreach (var s in listmessageTemp)
                            {
                                IsShow(usernameTemp).listmessage.AddFirst(s);
                            }
                            IsShow(usernameTemp).update_message(true);

                        }
                    }
                    if (cmt == CommandType_.MessageFriend)
                    {
                        buffer = new byte[4];
                        stream.Read(buffer, 0, 4);
                        int lengh = BitConverter.ToInt32(buffer, 0);
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
                        cmdMetaData = Encoding.UTF8.GetString(metaBuffer);
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
                        Chat chatForm = null;
                        _frmMain.Invoke(new Action(delegate()
                        {
                            if ((chatForm = IsShow(usernameTemp)) == null)
                            {
                                chatForm = new Chat(this, usernameTemp);
                                chatForm.Text = usernameTemp;
                                //Command cmd = new Command(CommandType_.LoadMessage, usernameTemp, 0);
                                // this.SendCommand(cmd);
                                chatForm.Show();
                                listFormChat.Add(chatForm);
                            }
                        }));
                        chatForm.Receive(usernameTemp, cmdMetaData, temp);
                    }
                    if (cmt == CommandType_.LoginSuccess)
                    {
                        stream.Read(buffer, 0, 4);
                        int stt = BitConverter.ToInt32(buffer, 0);

                        byte[] dataPicture;
                        //đọc tên username
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string username = Encoding.ASCII.GetString(data);
                        this._userName = username;


                        //nhận email
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string email = Encoding.ASCII.GetString(data);


                        //đọc avatar
                        Image image;
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        dataPicture = new byte[lenght];
                        ReadBigData(stream, lenght, ref dataPicture);
                        MemoryStream mem = new MemoryStream(dataPicture);
                        image = Image.FromStream(mem);

                        //đọc status
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        ReadBigData(stream, lenght, ref data);
                        string status = Encoding.UTF8.GetString(data);

                        //Đăng nhập thành công
                        //Khởi tạo form chính
                        //dangnhapForm.KillThreard();
                        if (_frmMain == null)
                        {
                            dangnhapForm.Invoke(new Action(delegate()
                            {

                                {
                                    _frmMain = new Form1(dangnhapForm, 1, this._userName, email, image, status, this);
                                    _frmMain.Text = "Frozen";
                                    _frmMain.Show();
                                    dangnhapForm.Hide();
                                }
                            }));

                        }
                        Command cmd = new Command(CommandType_.ListFriend, this._userName);
                        this.SendCommand(cmd);
                        //load list friend
                        //đọc thông tin list Friend
                        //Thread.Sleep(2000);
                        //--Đọc số lượng friend của user 



                    }//End LoginSuccess
                    if (cmt == CommandType_.ListFriend)
                    {
                        stream.Read(buffer, 0, 4);
                        int _CountTemp;
                        _CountTemp = BitConverter.ToInt32(buffer, 0);
                        _frmMain.listFriend = new List<FriendList>();
                        for (int i = 0; i < _CountTemp; i++)
                        {
                            //đọc useer friend
                            //int a = _abc;
                            stream.Read(buffer, 0, 4);
                            int lenght = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lenght];
                            stream.Read(data, 0, lenght);
                            string usernameFriend = Encoding.ASCII.GetString(data);



                            //đọc avatar friend
                            Image _avatarFriend;
                            stream.Read(buffer, 0, 4);
                            lenght = BitConverter.ToInt32(buffer, 0);
                            byte[] dataPicture = new byte[lenght];
                            ReadBigData(stream, lenght, ref dataPicture);
                            MemoryStream memTemp = new MemoryStream(dataPicture);
                            _avatarFriend = Image.FromStream(memTemp);


                            stream.Read(buffer, 0, 4);
                            lenght = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lenght];
                            ReadBigData(stream, lenght, ref data);
                            string _status = Encoding.UTF8.GetString(data);

                            //đọc trạng thái của friend này
                            stream.Read(buffer, 0, 4);
                            CommandType_ status = (CommandType_)BitConverter.ToInt32(buffer, 0);
                            FriendList friendTemp;
                            if (status == CommandType_.Online)
                            {
                                friendTemp = new FriendList(usernameFriend, _avatarFriend, true, _status);
                            }
                            else
                            {
                                friendTemp = new FriendList(usernameFriend, _avatarFriend, false, _status);
                            }
                            _frmMain.listFriend.Add(friendTemp);
                        }
                        _frmMain.update_listFriend(true);
                    }
                    if (cmt == CommandType_.Found)
                    {
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string username = Encoding.ASCII.GetString(data);


                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string email = Encoding.ASCII.GetString(data);

                        byte[] dataPicture;
                        //đọc avatar
                        Image image;
                        stream.Read(buffer, 0, 4);
                        lenght = BitConverter.ToInt32(buffer, 0);
                        dataPicture = new byte[lenght];
                        ReadBigData(stream, lenght, ref dataPicture);
                        MemoryStream mem = new MemoryStream(dataPicture);
                        image = Image.FromStream(mem);
                        ff_Form.Found(username, email, image);
                    }
                    if (cmt == CommandType_.NotFound)
                    {
                        ff_Form.Notfound();
                    }
                    if (cmt == CommandType_.NameExists)
                    {
                        MessageCustom.Show("Tài khoản bạn đã được đang nhập bởi người khác!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        dangnhapForm.ChangePanel();
                    }
                    if (cmt == CommandType_.Failure)
                    {
                        MessageCustom.Show("Tài khoản hoặc mật khẩu không đúng!", "Error", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        dangnhapForm.ChangePanel();
                    }
                    if (cmt == CommandType_.RegisterFailure)
                    {
                        MessageCustom.Show("Tài khoản hoặc tên người dùng đã tồn tại!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                    if (cmt == CommandType_.RegisterSuccess)
                    {
                        MessageCustom.Show("Đăng kí thành công!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    }
                    if (cmt == CommandType_.Online)
                    {
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string usernameFriend = Encoding.ASCII.GetString(data);
                        foreach (var s in _frmMain.listFriend)
                        {
                            if (s._userFriend == usernameFriend)
                            {
                                s.Status = true;
                            }
                        }
                        _frmMain.update_listFriend(true);
                    }
                    if (cmt == CommandType_.Offline)
                    {
                        stream.Read(buffer, 0, 4);
                        int lenght = BitConverter.ToInt32(buffer, 0);
                        data = new byte[lenght];
                        stream.Read(data, 0, lenght);
                        string usernameFriend = Encoding.ASCII.GetString(data);
                        foreach (var s in _frmMain.listFriend)
                        {
                            if (s._userFriend == usernameFriend)
                            {
                                s.Status = false;
                            }
                        }
                        _frmMain.update_listFriend(true);
                    }
                    //load toàn bộ thông báo
                    if (cmt == CommandType_.LoadNotice)
                    {
                        stream.Read(buffer, 0, 4);
                        int count = BitConverter.ToInt32(buffer, 0);
                        for (int i = 0; i < count; i++)
                        {

                            stream.Read(buffer, 0, 4);
                            int _stt = BitConverter.ToInt32(buffer, 0);

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

                            stream.Read(buffer, 0, 4);
                            lenght = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lenght];
                            stream.Read(data, 0, lenght);
                            string _content = Encoding.ASCII.GetString(data);

                            stream.Read(buffer, 0, 4);
                            lenght = BitConverter.ToInt32(buffer, 0);
                            data = new byte[lenght];
                            stream.Read(data, 0, lenght);
                            string _time = Encoding.ASCII.GetString(data);
                            Notice_List noticeTemp = new Notice_List(_stt, _userPrimary, _userReference, _type, _time);
                            Notice_frm.listNotice.Add(noticeTemp);
                        }
                        Notice_frm.update_Notice(false);
                    }
                    if (cmt == CommandType_.DeleteNoticeSuccess)
                    {
                        Notice_frm.update_Notice(true);
                    }
                    if (cmt == CommandType_.AddNoticeSuccess)
                    {
                        ff_Form.AddNoticeSuccess();
                    }
                    if (cmt == CommandType_.AddNoticeFailure)
                    {
                        ff_Form.AddNoticeFailure();
                    }
                    if (cmt == CommandType_.AddFriendFailure)
                    {
                        ff_Form.AddFriendFailure();
                    }
                }
                catch
                {
                    if (_check)
                    {
                        MessageCustom.Show("Server đang bảo trì !", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                        socket.Close();
                        dangnhapForm.Client = null;
                    }
                }
            }//end while
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
        System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1, 1);
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
            if (cmd.CommandType == CommandType_.LoadMessage)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.LoadMessage);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                buffer = BitConverter.GetBytes(cmd.commandBody.Length);
                stream.Write(buffer, 0, 4);
                this.stream.Flush();
                metaBuffer = Encoding.ASCII.GetBytes(cmd.commandBody);
                this.stream.Write(metaBuffer, 0, cmd.commandBody.Length);
                this.stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.count);
                stream.Write(buffer, 0, 4);
                stream.Flush();
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
            if (cmd.CommandType == CommandType_.ListFriend)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.ListFriend);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.ChangeInformation)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.ChangeInformation);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.Email.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Email);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                //gởi avatar cho user

                dataPicture = (byte[])cmd.Image_;
                buffer = BitConverter.GetBytes(dataPicture.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                SendLargeFile(dataPicture, stream);
                stream.Flush();

                //gởi status
               
                    data =Encoding.UTF8.GetBytes( cmd.Status);
                buffer = BitConverter.GetBytes(data.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                SendLargeFile(data, stream);
                stream.Flush();
            }
            //gởi thông điệp lên server kiểm tra xem tên này có trong CSDL ko
            if (cmd.CommandType == CommandType_.FindFriend)
            {

                metaBuffer = Encoding.ASCII.GetBytes(cmd.Username);

                //gởi thông điệp là tin nhắn cho bên nhận biết
                buffer = BitConverter.GetBytes((int)CommandType_.FindFriend);
                stream.Write(buffer, 0, 4);
                stream.Flush();

                //gởi nội dung tin nhắn
                buffer = BitConverter.GetBytes(cmd.Username.Length);
                stream.Write(buffer, 0, 4);
                this.stream.Flush();
                this.stream.Write(metaBuffer, 0, cmd.Username.Length);
                this.stream.Flush();
            }
            if (cmd.CommandType == CommandType_.LoadNotice)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.LoadNotice);
                stream.Write(buffer, 0, 4);
                stream.Flush();
            }
            if (cmd.CommandType == CommandType_.AddNotice)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.AddNotice);
                stream.Write(buffer, 0, 4);
                stream.Flush();


                buffer = BitConverter.GetBytes((int)cmd.UserPrimary.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserPrimary);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.UserReference.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserReference);
                stream.Write(data, 0, data.Length);
                stream.Flush();


                buffer = BitConverter.GetBytes((int)cmd.Type.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.Type);
                stream.Write(data, 0, data.Length);
                stream.Flush();

            }
            if (cmd.CommandType == CommandType_.AddFriend)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.AddFriend);
                stream.Write(buffer, 0, 4);
                stream.Flush();


                buffer = BitConverter.GetBytes((int)cmd.UserPrimary.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserPrimary);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.UserReference.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserReference);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                for (int i = 0; i < Notice_frm.listNotice.Count; i++)
                {
                    if (Notice_frm.listNotice[i]._userPrimary == cmd.UserPrimary && Notice_frm.listNotice[i]._userReference == cmd.UserReference)
                    {
                        Notice_frm.listNotice.Remove(Notice_frm.listNotice[i]);
                    }
                }
            }
            if (cmd.CommandType == CommandType_.DeleteNotice)
            {
                buffer = BitConverter.GetBytes((int)CommandType_.DeleteNotice);
                stream.Write(buffer, 0, 4);
                stream.Flush();


                buffer = BitConverter.GetBytes((int)cmd.UserPrimary.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserPrimary);
                stream.Write(data, 0, data.Length);
                stream.Flush();

                buffer = BitConverter.GetBytes((int)cmd.UserReference.Length);
                stream.Write(buffer, 0, 4);
                stream.Flush();
                data = Encoding.ASCII.GetBytes(cmd.UserReference);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                for (int i = 0; i < Notice_frm.listNotice.Count; i++)
                {
                    if (Notice_frm.listNotice[i]._userPrimary == cmd.UserPrimary && Notice_frm.listNotice[i]._userReference == cmd.UserReference)
                    {
                        Notice_frm.listNotice.Remove(Notice_frm.listNotice[i]);
                    }
                }
            }
            semaphor.Release();
        }
    }
}
