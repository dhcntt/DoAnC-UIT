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
using System.IO;
using System.Threading;
using _Command;

namespace Client_UIT
{
    public partial class Form1 : Form
    {
        int _stt;
        string _userName;
        string _email;
        string _status;
        Image _image;
        Dangnhap _dangnhapForm;
        ClientManager client;
        public List<FriendList> listFriend;
        public Form1(Dangnhap _dangnhapTemp, int stt, string _userTemp, string Email, Image _imageTemp, string status, ClientManager ClientTemp)
        {

            InitializeComponent();
            _dangnhapForm = _dangnhapTemp;
            _stt = stt;
            _email = Email;
            _userName = _userTemp;
            client = ClientTemp;
            lbl_user.Text = _userName;
            ptb_avatar.Image = _imageTemp;
            _image = _imageTemp;
            _status = status;
            if (status == "\n")
            {
                txt_status.Text = "Bạn đang nghĩ gì.... 	";
            }
            else
                txt_status.Text = status;
            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        public void GetValue(Image _image, string status)
        {
            ptb_avatar.Image = _image;
            txt_status.Text = status;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dangnhapForm.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpoint();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        Point _form = new Point(0, 0);
        Point current_form = new Point(0, 0);
        Point curs = new Point(0, 0);
        void setpoint()
        {
            _form = this.Location;
            curs = Cursor.Position;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            current_form.X = _form.X - curs.X + Cursor.Position.X;
            current_form.Y = _form.Y - curs.Y + Cursor.Position.Y;
            this.Location = new Point(current_form.X, current_form.Y);
        }
        /// <summary>
        /// ptb_close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptb_close_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_close.BackgroundImage = global::Client_UIT.Properties.Resources.close1;
        }

        private void ptb_close_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_close.BackgroundImage = global::Client_UIT.Properties.Resources.close;
        }
        /// <summary>
        /// ptb_minimize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptb_minimize_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_minimize.BackgroundImage = global::Client_UIT.Properties.Resources.minimize1;
        }

        private void ptb_minimize_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_minimize.BackgroundImage = global::Client_UIT.Properties.Resources.minimize2;
        }

        private void ptb_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptb_avatar_Click_1(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "png file (*.png)|*.png";
            //if(ofd.ShowDialog()==DialogResult.OK)
            //{
            //    ptb_avatar.Image = Image.FromFile(ofd.FileName);

            //}
            Personal_information ps_if = new Personal_information(1214325, _userName, _email, _status, _image, client);
            ps_if.MyGetValue = new Personal_information.GetData(this.GetValue);
            ps_if.Show();
        }
        /// <summary>
        /// Friend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        public delegate void UpDate_listFriend_delegate(bool kt);
        public void update_listFriend(bool kt)
        {
            if (flp_listFriend.InvokeRequired)
            {
                this.flp_listFriend.Invoke(new UpDate_listFriend_delegate(update_listFriend), new object[] { kt });
            }
            else
            {
                if (kt)
                {
                    List<Control> listControls = flp_listFriend.Controls.Cast<Control>().ToList();
                    foreach (Control control in listControls)
                    {
                        flp_listFriend.Controls.Remove(control);
                        control.Dispose();
                    }
                }

                for (int i = 0; i < listFriend.Count; i++)
                {
                    Friend _friendTemp = new Friend(listFriend[i]._userFriend, listFriend[i].Image, listFriend[i].Status, client, i, listFriend[i].TextStatus);
                    flp_listFriend.Controls.Add(_friendTemp);

                }
            }
        }

        private void bbt_addfriend_Click(object sender, EventArgs e)
        {
            FindFriend ff = new FindFriend(client, _userName);
            ff.Show();


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Focus();
        }

        private void bbt_notice_Click(object sender, EventArgs e)
        {
            Form_Notice frm_notice = new Form_Notice(client);
            frm_notice.Show();
            client.Notice_frm = frm_notice;
            Command cmd = new Command(Enum.CommandType_.LoadNotice);
            client.SendCommand(cmd);
        }
    }
}
