using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Command;
using Enum;

namespace Client_UIT
{
    public partial class FindFriend : Form
    {
        ClientManager client;
        string _username;
        public FindFriend(ClientManager clientTemp, string _userTemp)
        {
            InitializeComponent();
            client = clientTemp;
            client.ff_Form = this;
            _username = _userTemp;
        }
        public delegate void Found_Delegate(string username, string email, Image image);
        
        public void Found(string username, string email, Image image)
        {
            if (ptb_avatar.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                ptb_avatar.Visible = true;
                ptb_avatar.Image = image;
            }
            if (lbl_username.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                lbl_username.Visible = true;
            }
            if (lbl_username1.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                lbl_username1.Visible = true;
                lbl_username1.Text = username;
            }
            if (lbl_email.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                lbl_email.Visible = true;
                
            }
            if (lbl_email1.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                lbl_email1.Visible = true;
                lbl_email1.Text = email;
                }
            if (lbl_find.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                lbl_find.Visible = false;
            }
            if (txt_findFriend.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                txt_findFriend.Visible = false;
            }
            if (bbt_findFriend.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found),username,email, image);
            }
            else
            {
                bbt_findFriend.Visible = false;
            }
            if (bbt_nextfriend.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found), username, email, image);
            }
            else
            {
                bbt_nextfriend.Visible = true;
            }
            if (bbt_addfriend.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found), username, email, image);
            }
            else
            {
                bbt_addfriend.Visible = true;
            }
        }
        public delegate void NotFound_Delegate();
        
        public void Notfound()
        {
            if (lbl_notfound.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                lbl_notfound.Visible = true;
            }
            if (lbl_find.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                lbl_find.Visible = false;
            }
            if (txt_findFriend.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                txt_findFriend.Visible = false;
            }
            if (bbt_nextfriend.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                bbt_nextfriend.Visible = true;
            }
            if ( bbt_findFriend.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                bbt_findFriend.Visible = false;
            }
        }
        private void bbt_findFriend_Click(object sender, EventArgs e)
        {
            if (txt_findFriend.Text == "")
            {
                MessageCustom.Show("Vui lòng nhập Talk ID hay Tên \n người cần kết bạn!", "Thông báo",
                    new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            }
            else
            {
                Command cm = new Command(Enum.CommandType_.FindFriend, txt_findFriend.Text);
                client.SendCommand(cm);
            }
        }
        public delegate void AddNoticeSuccess_delegate();
        public void AddNoticeSuccess()
        {
            if (lbl_notfound.InvokeRequired && ptb_avatar.InvokeRequired && lbl_email.InvokeRequired
                && lbl_email1.InvokeRequired && lbl_username.InvokeRequired
                && lbl_username1.InvokeRequired && bbt_addfriend.InvokeRequired)
            {
                this.Invoke(new AddNoticeSuccess_delegate(AddNoticeSuccess));
            }
            else
            {
                lbl_notfound.Text = "Đã gởi lời mời kết bạn đến người này !";
                ptb_avatar.Visible = false;
                lbl_notfound.Visible = true;
                lbl_email.Visible = false;
                lbl_email1.Visible = false;
                lbl_username.Visible = false;
                lbl_username1.Visible = false;
                bbt_addfriend.Visible = false;
            }

        }
        private void bbt_nextfriend_Click(object sender, EventArgs e)
        {
                lbl_notfound.Visible = false;

                lbl_find.Visible = true;

                txt_findFriend.Visible = true;
            
                bbt_nextfriend.Visible = false;

                bbt_findFriend.Visible = true;
                ptb_avatar.Visible = false;
                lbl_email.Visible = false;
                lbl_email1.Visible = false;
                lbl_username.Visible = false;
                lbl_username1.Visible = false;
                bbt_addfriend.Visible = false;
        }

        private void bbt_addfriend_Click(object sender, EventArgs e)
        {
            //lbl_notfound.Text = "Đã gởi lời mời kết bạn đến người này !";
            //ptb_avatar.Visible = false;
            //lbl_notfound.Visible = true;
            //lbl_email.Visible = false;
            //lbl_email1.Visible = false;
            //lbl_username.Visible = false;
            //lbl_username1.Visible = false;
            //bbt_addfriend.Visible = false;
            Command cmd = new Command(CommandType_.AddNotice, lbl_username1.Text, this._username, "1");
            client.SendCommand(cmd);
        }

        private void FindFriend_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_findFriend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txt_findFriend.Text == "")
                {
                    MessageCustom.Show("Vui lòng nhập Talk ID hay Tên \n người cần kết bạn!", "Thông báo",
                        new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular,
                            System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                }
                else
                {
                    Command cm = new Command(Enum.CommandType_.FindFriend, txt_findFriend.Text);
                    client.SendCommand(cm);
                }
            }
        }
    }
}
