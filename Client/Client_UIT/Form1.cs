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
<<<<<<< HEAD
using _Command;
=======
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e

namespace Client_UIT
{
    public partial class Form1 : Form
    {
        Dangnhap _dangnhapForm;
        string _userName;
<<<<<<< HEAD
        ClientManager client;
        public  List<FriendList> listFriend;
        public Form1(Dangnhap _dangnhapTemp, string _userTemp, Image _imageTemp, ClientManager ClientTemp)
=======
        public Form1(Dangnhap _dangnhapTemp, string _userTemp,Image _imageTemp)
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
        {

            InitializeComponent();
            _dangnhapForm = _dangnhapTemp;
            _userName = _userTemp;
<<<<<<< HEAD
            client = ClientTemp;
            lbl_user.Text = _userName;
            ptb_avatar.Image = _imageTemp;

=======
            lbl_user.Text = _userName;
            ptb_avatar.Image = _imageTemp;
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dangnhapForm.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
<<<<<<< HEAD
            setpoint();
=======
                setpoint();
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
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

        private void ptb_avatar_Click(object sender, EventArgs e)
        {

        }

        private void ptb_avatar_Click_1(object sender, EventArgs e)
        {
<<<<<<< HEAD
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "png file (*.png)|*.png";
            //if(ofd.ShowDialog()==DialogResult.OK)
            //{
            //    ptb_avatar.Image = Image.FromFile(ofd.FileName);

            //}
            Personal_information ps_if = new Personal_information();
            ps_if.Show();
=======
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png file (*.png)|*.png";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                ptb_avatar.Image = Image.FromFile(ofd.FileName);
                
            }
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
        }
        /// <summary>
        /// Friend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
<<<<<<< HEAD
        public delegate void UpDate_listFriend_delegate( bool kt);
        public void update_listFriend(bool kt)
        {
            if (flp_listFriend.InvokeRequired)
            {
                this.Invoke(new UpDate_listFriend_delegate(update_listFriend), kt);
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
                    Friend _friendTemp = new Friend(listFriend[i]._userFriend, listFriend[i].Image, listFriend[i].Status, client);
                    flp_listFriend.Controls.Add(_friendTemp);
                    //listFriend.Add(_friendTemp);
                }
            }
        }

        private void bbt_addfriend_Click(object sender, EventArgs e)
        {
            FindFriend ff = new FindFriend(client,_userName);
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
=======
        public delegate void UpDate_listFriend_delegate(string _userFriend,Image _imageTemp);
        public void update_listFriend(string _userFriend,Image _imageTemp)
        {
            if(flp_listFriend.InvokeRequired)
            {
                this.Invoke(new UpDate_listFriend_delegate(update_listFriend),_userFriend,_imageTemp);
            }
            else
            {
                Friend _friendTemp=new Friend( _userFriend,_imageTemp);
                flp_listFriend.Controls.Add(_friendTemp);
            }
        }
        
        private void bbt_addfriend_Click(object sender, EventArgs e)
        {

        }

        private void lbThongTin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Persional_Ìmormation thongtin = new Persional_Ìmormation();
            thongtin.Show();
            
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
        }
    }
}
