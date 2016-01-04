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
    public partial class Dangnhap : Form
    {
        public Socket socket=null;//kết nối giữa client-server
        NetworkStream stream;
        ClientManager client = null;
        IPEndPoint IPep;
        public Dangnhap()
        {
            InitializeComponent();
            //int a=2;
           
        }
        BackgroundWorker backgroundWorker;
        void Click_dangnhap()
        {
            panel1.Visible = false;
            panel2.Visible = true;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            //backgroundWorker = new BackgroundWorker();
            //backgroundWorker.DoWork+=backgroundWorker_DoWork;
            //backgroundWorker.WorkerReportsProgress = true;
            //backgroundWorker.WorkerSupportsCancellation = true;
            //backgroundWorker.ProgressChanged+=backgroundWorker_ProgressChanged;
            //backgroundWorker.RunWorkerAsync();
            this.txt_password._lost();
            this.txt_dangnhap._lost();
            if (txt_password.NullText == false || txt_dangnhap.NullText == false)
            {
                MessageCustom.Show("Vui lòng nhập tài khoản và mật khẩu \n chính xác  để đăng nhập! ","Thông báo đăng nhập",new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                
            }
            else
            {
                try
                {
                    if ( client == null)
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                        socket.Connect(IPep);
                        client = new ClientManager(this, socket);
                        stream = new NetworkStream(socket);
                    }

                    byte[] buffer = new byte[4];
                    buffer = BitConverter.GetBytes((int)CommandType_.Login);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();

                    buffer = BitConverter.GetBytes(txt_dangnhap.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    byte[] data = new byte[txt_dangnhap.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_dangnhap.Text);
                    stream.Write(data, 0, txt_dangnhap.Text.Length);
                    stream.Flush();

                    buffer = BitConverter.GetBytes(txt_password.Text.Length);
                    stream.Write(buffer, 0, 4);
                    stream.Flush();
                    data = new byte[txt_password.Text.Length];
                    data = Encoding.ASCII.GetBytes(txt_password.Text);
                    stream.Write(data, 0, txt_password.Text.Length);
                    stream.Flush();
                }
                catch
                {
                    MessageCustom.Show("Server đang bảo trì. \nVui lòng đăng nhập lại sau. ", "Thông báo đăng nhập", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
                    panel1.Visible = true;
                    panel2.Visible = false;
                }
            }
        }
        public void KillThreard()
        {
            backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();
        }
        public delegate void ChangPanel_delegate();
        public void ChangePanel()
        {
            if (panel1.InvokeRequired && panel2.InvokeRequired)
            {
                this.Invoke(new ChangPanel_delegate(ChangePanel));
            }
            else
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
        }
        /// <summary>
        /// ptb_dangnhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                //Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
        }
        private void ptb_dangnhap_Click(object sender, EventArgs e)
        {
            
            
            Click_dangnhap();
        }
        private void ptb_dangnhap_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_dangnhap.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap1;
        }

        private void ptb_dangnhap_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_dangnhap.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
        }
        private void ptb_dangnhap_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                e.Graphics.DrawString("Đăng nhập", myFont, Brushes.White, new Point(53, 11));
            }
        }
        /// <summary>
        /// ptb_dangki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ptb_dangki_Click(object sender, EventArgs e)
        {

            try
            {
                if (client==null)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                    socket.Connect(IPep);
                    stream = new NetworkStream(socket);
                    client = new ClientManager(this, socket);
                }
                Register dangki = new Register(socket);
                dangki.Show();
            }
            catch
            {
                MessageCustom.Show("Server đang bảo trì. \nBạn không thể đăng kí lúc này. ", "Thông báo đăng nhập", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            }
        }
        private void ptb_dangki_MouseLeave(object sender, EventArgs e)
        {
            this.ptb_dangki.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
        }

        private void ptb_dangki_MouseMove(object sender, MouseEventArgs e)
        {
            this.ptb_dangki.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap1;
        }
        private void ptb_dangki_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                e.Graphics.DrawString("Đăng kí", myFont, Brushes.White, new Point(65, 11));
            }
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
        /// <summary>
        /// 
        /// </summary>
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

       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpoint();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }
        private void Dangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                txt_dangnhap.Focus();
            }
        }

        private void txt_dangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
               txt_dangnhap.Focus();
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                Click_dangnhap();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
              //  txt_dangnhap.Focus();
                
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                Click_dangnhap();
            }
        }
        private void Dangnhap_Click(object sender, EventArgs e)
        {
            this.ptb_title.Focus();
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {
            //int a = 2;
        }

        private void ptb_title_Click(object sender, EventArgs e)
        {

        }
    }
}
