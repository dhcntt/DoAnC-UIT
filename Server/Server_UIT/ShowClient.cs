using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_UIT
{
    //showClient chính là 1 thẻ trong danh sách người dùng trong form chính
    public partial class ShowClient : UserControl
    {
        
        public ClientManager client;//clientmanager giữ kết nối giữa tab showlient này với socket
        public string _username;//tên của showclient
        public bool Online;//trạng thái online hay offline của client này
        public ShowClient(ClientManager ClientTemp,string username="",string IP_address="",int Port=0)
        {
            InitializeComponent();
            lbl_username.Text = username;
            _username = username;
            lbl_ip_port.Text = IP_address;
            client = ClientTemp;
            Online = false;
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            //thêm sự kiện doubleClick
            e.Control.DoubleClick += ShowClient_DoubleClick;
            base.OnControlAdded(e);
        }
        public void ShowClient_DoubleClick(object sender, EventArgs e)
        {
            if (client == null)
            {
                MessageBox.Show("Client chưa kết nối!", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //khi double click vào tab show lient thì gọi form chat với client đó
                Chat form2 = new Chat(client);
                form2.Text = lbl_username.Text;
                form2.Show();
                client.Chat = form2;
            }
        }
    }
}
