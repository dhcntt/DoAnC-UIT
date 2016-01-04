using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_UIT
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }
        void Dang_nhap()
        {
            if (txt_dangnhap.Text == "" && txt_password.Text == "")
            {
                Form1 server = new Form1(this, txt_dangnhap.Text);
                server.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void bbt_dangnhap_Click(object sender, EventArgs e)
        {
            Dang_nhap();
        }

        private void bbt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_dangnhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                Dang_nhap();
            }
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Dang_nhap();
            }
        }
    }
}
