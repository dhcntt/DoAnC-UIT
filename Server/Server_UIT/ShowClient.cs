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
        public ClientManager _cm;//clientmanager giữ kết nối giữa tab showlient này với socket
        public string _username;//tên của showclient
        public ShowClient(ClientManager cm,string username="",string IP_port="")
        {
            InitializeComponent();
            lbl_username.Text = username;
            _username = username;
            lbl_ip_port.Text = IP_port;
            _cm = cm;
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            //thêm sự kiện doubleClick
            e.Control.DoubleClick += ShowClient_DoubleClick;
            base.OnControlAdded(e);
        }
        public void ShowClient_DoubleClick(object sender, EventArgs e)
        {
            if (_cm == null)
            {
                MessageBox.Show("Client chưa kết nối!", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //khi double click vào tab show lient thì gọi form chat với client đó
                Chat form2 = new Chat(_cm);
                form2.Text = lbl_username.Text;
                form2.Show();
                _cm.Chat = form2;
            }
        }
    }
}
