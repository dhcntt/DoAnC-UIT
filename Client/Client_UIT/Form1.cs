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

namespace Client_UIT
{
    public partial class Form1 : Form
    {
        Dangnhap _dangnhapForm;
        string _userName;
        public Form1(Dangnhap _dangnhapTemp, string _userTemp,Image _imageTemp)
        {

            InitializeComponent();
            _dangnhapForm = _dangnhapTemp;
            _userName = _userTemp;
            lbl_user.Text = _userName;
            ptb_avatar.Image = _imageTemp;
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

        private void ptb_avatar_Click(object sender, EventArgs e)
        {

        }

        private void ptb_avatar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png file (*.png)|*.png";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                ptb_avatar.Image = Image.FromFile(ofd.FileName);
                
            }
        }
        /// <summary>
        /// Friend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            
        }
    }
}
