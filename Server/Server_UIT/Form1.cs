using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using BUS;
using Enum;

namespace Server_UIT
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();//thread chính  để tiếp nhận các client kết nối
        Socket server;//socket kết nối các client
        private const int BUFFER_SIZE = 1024;
        private static int PORT_NUMBER = 9999;
        static IPAddress address = IPAddress.Parse("127.0.0.1");//địa chỉ IP server
        IPEndPoint ipep = new IPEndPoint(address, PORT_NUMBER);
        //danh sach cac client da kết nối
        public static List<ClientManager> listClient;
        public static List<ShowClient> lstShowClient;//danh sach cac client da kết nối
        static ASCIIEncoding encoding = new ASCIIEncoding();
        Dangnhap f;
        string user;
        ClientManager client;
        public Form1(Dangnhap _f,string _user)
        {
            InitializeComponent();
             f = _f;
             lbl_user.Text = _user;//lấy tên user từ bên khung đăng nhập
            listClient=new List<ClientManager>();
            lstShowClient=new List<ShowClient>();
            bw.DoWork += bw_DoWork;//hàm chính
            bw.RunWorkerAsync();//bắt đầu thread
        }
        public delegate void Form1Load_delegate(object sender, EventArgs e);
        public void Form1_Load(object sender, EventArgs e)
        {
            if (flp_client.InvokeRequired)
            {
                this.Invoke(new Form1Load_delegate(Form1_Load), sender, e);
            }
            else
            {
                DataTable dt = Khachhang_BUS.Loadds();//load tất cả danh sách đã có trong sql server
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShowClient show_client = new ShowClient(null, dt.Rows[i][0].ToString());//tạo show client để đưa lên form server
                    lstShowClient.Add(show_client);//thêm show client vào List để sau này dễ cập nhật khi có thay đổi trong 1 showclient nào đó
                    flp_client.Controls.Add(show_client);//đưa lên form server 
                }
            }

        }
        void rezise(ref string s)
        {
            char[] temp = new char[30 - s.Length];
            for (int i = 0; i < (30 - s.Length); i++)
            {
                temp[i] = ' ';
            }
            String a = new String(temp);
            s+=a;
            
        }
        public delegate void AddShowClient_Delgate(string _userNameTemp);
        public void AddShowClient(string _userNameTemp)
        {
            if (flp_client.InvokeRequired)
            {
                this.Invoke(new AddShowClient_Delgate(AddShowClient),_userNameTemp);
            }
            else
            {
                rezise(ref _userNameTemp);
                    ShowClient show_client = new ShowClient(null,_userNameTemp);//tạo show client để đưa lên form server
                    lstShowClient.Add(show_client);//thêm show client vào List để sau này dễ cập nhật khi có thay đổi trong 1 showclient nào đó
                    flp_client.Controls.Add(show_client);//đưa lên form server 
              }

        }
        System.Threading.Semaphore semaphor = new System.Threading.Semaphore(1, 1);
        public void bw_DoWork(object sender,DoWorkEventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            
            server.Listen(10);
            // 1. listen
            while (true)
            {
                semaphor.WaitOne();
                Socket _socket = server.Accept();//chờ đợi client kết nối đến
                client = new ClientManager(this, _socket);//tạo client giữa server với client vừa kết nối để giữ liên lạc
                // 2. Nhận thông tin tài khoản được gởi đến từ bên client
                semaphor.Release();
            }
          //kết thúc lắng nghe
        }
     
       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Close();  
        }

        private void showClient_Load(object sender, EventArgs e)
        {

        }
    }
}
