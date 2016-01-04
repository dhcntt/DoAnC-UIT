using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Command;
using Enum;

namespace Server_UIT
{
    public partial class Chat : Form
    {
        public ClientManager _cm;
        Font text;
        public Chat(ClientManager cm)
        {
            InitializeComponent();
            _cm = cm;
            text = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }

        private void bbt_gui_Click(object sender, EventArgs e)
        {
            if (_cm.socket.Connected)
            {
                if (rTB_content.Text != "")
                {
                    Messeage ms = new Messeage("Server", rTB_content.Text, text);
                    flp_messeage.Controls.Add(ms);
                    text = rTB_content.Font;
                    Command cmd = new Command(Enum.CommandType_.Message,rTB_content.Text,text);
                    rTB_content.Text = "";
                    _cm.SendCommand(cmd);
                }
            }
            else
            {
                MessageBox.Show("Kết nối với client đã bị đóng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        //click chọn font
        private void bbt_font_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog()==DialogResult.OK)
            {
                rTB_content.Font =font.Font;
                text = font.Font;

            }
        }

        //khi nhận tin nhắn đến thì gọi hàm  nhận này thông qua Delagate
        //bởi vì các control không thể gọi trự tiếp trong tiểu trình
        //mà hàm Receive này được gọi chính thức trong tiểu trình nhận tin nhắn của ClientManager
        public delegate void ReceiveDelegate(string _content, Font temp);
        public void Receive(string _content, Font temp)
        {
            if (flp_messeage.InvokeRequired)
            {
                this.Invoke(new ReceiveDelegate(Receive), _content, temp);
            }
            else
            {
                if (_content != "")
                {
                    Messeage ms = new Messeage(_cm.userName, _content, temp);
                    flp_messeage.Controls.Add(ms);
                }
            }
        }
    }
}
