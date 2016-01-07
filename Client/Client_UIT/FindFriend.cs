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
        Form1 frm_main;
        ClientManager client;
        string _username;
        public FindFriend(ClientManager clientTemp, string _userTemp,Form1 frm_mainTemp)
        {
            InitializeComponent();
            client = clientTemp;
            client.ff_Form = this;
            _username = _userTemp;
            frm_main = frm_mainTemp;
        }
        public delegate void Found_Delegate(string username, string email, Image image);
        
        public void Found(string username, string email, Image image)
        {
            if(panel1.InvokeRequired&&panel2.InvokeRequired&&panel3.InvokeRequired)
            {
                this.Invoke(new Found_Delegate(Found), username, email, image);
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                lbl_email1.Text = email;
                lbl_username1.Text = username;
                ptb_avatar.Image = image;
            }
        }
        public delegate void NotFound_Delegate();
        
        public void Notfound()
        {
            if (panel1.InvokeRequired && panel2.InvokeRequired && panel3.InvokeRequired)
            {
                this.Invoke(new NotFound_Delegate(Notfound));
            }
            else
            {
                lbl_notfound.Text = "Không tìm thấy người này!";
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;

            }
        }
        public delegate void AddNoticeFailure_Delegate();

        public void AddNoticeFailure()
        {
            if (panel1.InvokeRequired && panel2.InvokeRequired && panel3.InvokeRequired)
            {
                this.Invoke(new AddNoticeFailure_Delegate(AddNoticeFailure));
            }
            else
            {
                lbl_notfound.Text = "Bạn đã gửi lời mời kết bạn đến người này.\nKhông thể gởi thêm nữa!";
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;

            }
        }
        public delegate void AddFriendFailure_Delegate();

        public void AddFriendFailure()
        {
            if (panel1.InvokeRequired && panel2.InvokeRequired && panel3.InvokeRequired)
            {
                this.Invoke(new AddFriendFailure_Delegate(AddFriendFailure));
            }
            else
            {
                lbl_notfound.Text = "Bạn và người này đã là bạn của nhau.\nKhông thể gởi thêm nữa!";
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;

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
            if (panel1.InvokeRequired && panel2.InvokeRequired && panel3.InvokeRequired)
            {
                this.Invoke(new AddNoticeSuccess_delegate(AddNoticeSuccess));
            }
            else
            {
                lbl_notfound.Text = "Gởi thành công lời mời kết bạn đến người này !";
                panel3.Visible = true;
                panel2.Visible = false;
                panel1.Visible = false;
                
            }

        }
        private void bbt_nextfriend_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void bbt_addfriend_Click(object sender, EventArgs e)
        {
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

        private void FindFriend_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_main.ff = null;
        }
    }
}
