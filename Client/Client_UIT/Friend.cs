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
using Enum;

namespace Client_UIT
{
    
    //1 user control trong danh sách bạn
    public partial class Friend : UserControl
    {
        private bool _status;
        ClientManager client;
        public string _userFriend;
        public int Position;
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
        string _textStatus;
        public Friend(string UserFriend, Image _imageTemp, bool status, ClientManager clientTemp, int _positionTemp = 0, string TextStatus = "")
        {
            InitializeComponent();
            Position = _positionTemp;
            _userFriend = UserFriend;
            client = clientTemp;
            if (Position % 2 == 0)
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            }
            _textStatus = TextStatus;
            ptb_avatar.Image = _imageTemp;
            if (status)
                ptb_status.Image = global::Client_UIT.Properties.Resources.online;
            else
                ptb_status.Image = global::Client_UIT.Properties.Resources.offline;

        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            //thêm sự kiện doubleClick
           
                e.Control.DoubleClick += Friend_DoubleClick;
                base.OnControlAdded(e);
                e.Control.MouseMove += Friend_MouseMove;
                base.OnControlAdded(e);
                e.Control.MouseLeave += Friend_MouseLeave;
                base.OnControlAdded(e);
                
           
        }
        public void Friend_DoubleClick(object sender, EventArgs e)
        {
            {
                //khi double click vào tab show lient thì gọi form chat với client đó
                if (ClientManager.IsShow(_userFriend) == null)
                {
                    Chat form2 = new Chat(client,_userFriend);
                    form2.Text = _userFriend ;
                    ClientManager.listFormChat.Add(form2);
                    Command cmd = new Command(CommandType_.LoadMessage, _userFriend, 0);
                    client.SendCommand(cmd);
                    form2.Show();
                    
                }
            }
        }
        public void Friend_MouseMove(object sender, EventArgs e)
        {
         
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        }
        public void Friend_MouseLeave(object sender, EventArgs e)
        {
            if (Position % 2 == 0)
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                
            }
        }

        private void Friend_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                if (_textStatus == "\n")
                    e.Graphics.DrawString(_userFriend, myFont, Brushes.Black, new Point(52, 16));
                else
                {
                    e.Graphics.DrawString(_userFriend, myFont, Brushes.Black, new Point(52, 8));
                    e.Graphics.DrawString(_textStatus, new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new Point(52, 25));
                }
            }
        }
      
    }
    public class FriendList
    {
        private bool _status;
        public string _userFriend;
        public bool Status
        {
            get { return _status; }
            set
            {
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
        public FriendList(string UserFriend, Image _imageTemp, bool status, string TextStatus = "")
        {
            _userFriend = UserFriend;
            _status = status;
            _image = _imageTemp;
            _textStatus = TextStatus;
        }
    }
}
