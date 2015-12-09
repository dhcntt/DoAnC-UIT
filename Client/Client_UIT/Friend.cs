using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_UIT
{
    public class FriendList
    {
        private bool _status;
        public string _userFriend;
        public bool Status
        {
            get { return _status; }
            set { 
                _status = value;
            }
        }
        private Image _image;

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
        private string _textStatus;

        public string TextStatus
        {
            get { return _textStatus; }
            set { _textStatus = value; }
        }
        public FriendList( string UserFriend, Image _imageTemp, bool status, string TextStatus = "")
        {
            _userFriend = UserFriend;
            _status = status;
            _image = _imageTemp;
            _textStatus = TextStatus;
        }
    }
    //1 user control trong danh sách bạn
    public partial class Friend : UserControl
    {
        private bool _status;
        ClientManager client;
        public string _userFriend;
        public bool Status
        {
            get { return _status; }
            set { 
                _status = value;
                if(_status==true)
                {
                    ptb_status.Image = ptb_status.Image = global::Client_UIT.Properties.Resources.online;
                }
                else
                    ptb_status.Image = global::Client_UIT.Properties.Resources.offline;

            }
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            //thêm sự kiện doubleClick
            e.Control.DoubleClick += ShowClient_DoubleClick;
            base.OnControlAdded(e);
        }
        public void ShowClient_DoubleClick(object sender, EventArgs e)
        {
            {
                //khi double click vào tab show lient thì gọi form chat với client đó
                if (ClientManager.IsShow(_userFriend) == null)
                {
                    Chat form2 = new Chat(client,_userFriend);
                    form2.Text = txt_username.Text ;
                    form2.Show();
                    ClientManager.listFormChat.Add(form2);
                }
            }
        }
        public Friend(string UserFriend, Image _imageTemp,bool status,ClientManager clientTemp,string TextStatus="")
        {
            InitializeComponent();
            _userFriend = UserFriend;
            txt_username.Text = _userFriend;
            client = clientTemp;
            
            ptb_avatar.Image = _imageTemp;
            if (status)
                ptb_status.Image = global::Client_UIT.Properties.Resources.online;
            else
                ptb_status.Image = global::Client_UIT.Properties.Resources.offline;
            if (TextStatus == "")
                this.txt_username.Location = new Point(40, 14);
        }
    }
}
