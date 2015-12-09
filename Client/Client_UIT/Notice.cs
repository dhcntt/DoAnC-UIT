using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Command;

namespace Client_UIT
{
    public partial class Notice : UserControl
    {
        public int _stt;
        public string _userPrimary;
        public string _userReference;
        public string _type;
        //public string _content;
        //public string _time;

        ClientManager client;
        
        public Notice(int stt, string userPrimary, string userReference, string type, string time, ClientManager _clientTemp)
        {
            InitializeComponent();
            _userPrimary = userPrimary;
            _userReference = userReference;
            client = _clientTemp;
            _stt = stt;
            lbl_time.Text = time;
            _type = type;
            if (_type == "1")
                lbl_content.Text = userReference.Trim() + " đã gởi lời mời kết bạn!";
            if (_type == "2")
            {
                lbl_content.Text = userReference.Trim() + " đã đồng ý kết bạn!";
                bbt_ok.Visible = false;
            }
            if (_type == "3")
            {
                lbl_content.Text = userReference.Trim() + " đã gởi cho bạn 1 tin nhắn!";
                bbt_ok.Visible = false;
            }
        }

        private void bbt_ok_Click(object sender, EventArgs e)
        {
            Command cmd = new Command(Enum.CommandType_.AddFriend,_userPrimary,_userReference);
            client.SendCommand(cmd);
            cmd = new Command(Enum.CommandType_.ListFriend);
            client.SendCommand(cmd);
        }

        private void bbt_cancel_Click(object sender, EventArgs e)
        {
            Command cmd = new Command(Enum.CommandType_.DeleteNotice,_userPrimary,_userReference);
            client.SendCommand(cmd);
        }
    }
}
