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
using Enum;

namespace Client_UIT
{
    public partial class Register : Form
    {
        public Socket socket;
        public Register(Socket _socket)
        {
            InitializeComponent();
            socket = _socket;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void bbt_register_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != txt_confirm.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    NetworkStream stream = new NetworkStream(socket);
                    byte[] buffer = new byte[4];
                    //sen command type
                    buffer = BitConverter.GetBytes((int)CommandType_.Register);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    //send username
                    buffer = BitConverter.GetBytes(txt_username.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    byte[] data = new byte[txt_username.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_username.Text);
                    stream.Write(data, 0, txt_username.Text.Length);
                    stream.Flush();
                    //send account
                    buffer = BitConverter.GetBytes(txt_account.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = new byte[txt_account.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_account.Text);
                    stream.Write(data, 0, txt_account.Text.Length);
                    stream.Flush();
                    //send password
                    buffer = BitConverter.GetBytes(txt_password.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = new byte[txt_password.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_password.Text);
                    stream.Write(data, 0, txt_password.Text.Length);
                    stream.Flush();
                    //sen email
                    buffer = BitConverter.GetBytes(txt_email.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = new byte[txt_email.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_email.Text);
                    stream.Write(data, 0, txt_email.Text.Length);
                    stream.Flush();

                }
                catch
                {
                    MessageBox.Show("Server đang bảo trì,không thể đăng kí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_account_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_mini_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.minimize2;
        }

        private void ptb_mini_rgt_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_mini_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.minimize1;
        }

        private void ptb_canel_rgt_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_canel_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.close;
        }

        private void ptb_canel_rgt_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_canel_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.close1;
        }


        private void ptb_dk_rgt_Paint_1(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                e.Graphics.DrawString("Đăng kí", myFont, Brushes.White, new Point(30, 11));
            }
        }

        private void ptb_dk_rgt_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_dk_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dk1;
        }

        private void ptb_dk_rgt_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_dk_rgt.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dk;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void ptb_dk_rgt_Click(object sender, EventArgs e)
        {
            bbt_register_Click(sender, e);
        }


    }
}
