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
    }
}
