using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client_UIT
{
    public partial class Personal_information : Form
    {
        int _stt;
        string _account;
        string _email;
        string _status;
        Image _image;
        ClientManager client;
        public Personal_information(int Stt, string account, string Email, string status, Image image_,ClientManager clientTemp)
        {
            InitializeComponent();
            client = clientTemp;
            txt_ID.Text = Stt.ToString();
            txt_username.Text = account;
            txt_email.Text = Email.Trim();
            txt_status.Text = status;
            ptb_avatar.Image = image_;
        }

        //public delegate void UpDate_Information_delegate(int Stt, string account, string Email, string status, Image image_);
        //public void UpDate_Information(int Stt, string account, string Email, string status, Image image_)
        //{
        //    if (txt_ID.InvokeRequired && txt_account.InvokeRequired && txt_email.InvokeRequired && txt_status.InvokeRequired
        //        && ptb_avatar.InvokeRequired)
        //    {
        //        this.Invoke(new UpDate_Information_delegate(UpDate_Information), Stt, account, Email, status, image_);
        //    }
        //    else
        //    {
        //        txt_ID.Text = Stt.ToString();
        //        txt_account.Text = account;
        //        txt_email.Text = Email;
        //        txt_status.Text = status;
        //        ptb_avatar.Image = image_;
        //    }
        //}

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pib_mini_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_mini.BackgroundImage = global::Client_UIT.Properties.Resources.minimize1;
        }

        private void pib_mini_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_mini.BackgroundImage = global::Client_UIT.Properties.Resources.minimize2;
        }

        private void ptb_canel_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_canel.BackgroundImage = global::Client_UIT.Properties.Resources.close;
        }

        private void ptb_canel_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_canel.BackgroundImage = global::Client_UIT.Properties.Resources.close1;
        }

        private void ptb_null_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpoint();
        }

        private void ptb_null_MouseUp(object sender, MouseEventArgs e)
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

        

        private void bbt_changeAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png file (*.png)|*.png";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                ptb_avatar.Image = Image.FromFile(ofd.FileName);
            }
        }
        public delegate void GetData(Image _image, string status);
        public GetData MyGetValue;
        private void bbt_ok_Click(object sender, EventArgs e)
        {
            byte[] dataPicture = new byte[10000];
            MemoryStream ms = new MemoryStream();
            ImageConverter imageConvert = new ImageConverter();
            dataPicture = (byte[])imageConvert.ConvertTo(ptb_avatar.Image, typeof(byte[]));
            _Command.Command cmd = new _Command.Command(Enum.CommandType_.ChangeInformation, txt_username.Text, txt_email.Text, dataPicture, txt_status.Text);
            client.SendCommand(cmd);
            MyGetValue(ptb_avatar.Image, txt_status.Text);
            this.Close();
        }

        private void bbt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
