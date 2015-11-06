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
    public partial class Persional_Ìmormation : Form
    {
        public Persional_Ìmormation()
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
    }
}
