using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_UIT
{
    public partial class Personal_information : Form
    {
        public Personal_information()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            txtboxDiaChi.ReadOnly = false;
            txtboxGioiTinh.ReadOnly = false;
            txtboxHoTen.ReadOnly = false;
            txtboxNgaySinh.ReadOnly = false;
        }

        private void Persional_Ìmormation_Load(object sender, EventArgs e)
        {

        }

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

        private void ptb_null_Click(object sender, EventArgs e)
        {

        }
    }
}
