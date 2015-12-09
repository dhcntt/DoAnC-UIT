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
using System.Net;
using System.Net.Sockets;

namespace Client_UIT
{
    public partial class Chat : Form
    {
        public ClientManager _client;
        Font _fontMessage;
       // public string _usernameMain;
        public string _usernameReference;
        public Chat(ClientManager ClientTemp,string userReferrence)
        {
            InitializeComponent();
            _client = ClientTemp;
            //_usernameMain = usermain;
            _usernameReference = userReferrence;
            _fontMessage = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
        }

        private void bbt_gui_Click(object sender, EventArgs e)
        {
            if (_client.socket.Connected)
            {
                if (rTB_content.Text != "")
                {
                    Messeage ms = new Messeage(_client.userName, rTB_content.Text, _fontMessage);
                    flp_messeage.Controls.Add(ms);
                    _fontMessage = rTB_content.Font;
                    if (_usernameReference == "Server")
                    {
                        Command cmd = new Command(Enum.CommandType_.Message, rTB_content.Text, _fontMessage);
                        _client.SendCommand(cmd);
                    }
                    else
                    {
                        Command cmd = new Command(Enum.CommandType_.MessageFriend,this._usernameReference, rTB_content.Text, _fontMessage);
                        _client.SendCommand(cmd);
                    }
                    rTB_content.Text = "";
                }
            }
            else
            {
                MessageCustom.Show("Kết nối với client đã bị đóng!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            }
        }


        private void bbt_font_Click(object sender, EventArgs e)
        {
            FontDialog fontTemp = new FontDialog();
            if (fontTemp.ShowDialog() == DialogResult.OK)
            {
                rTB_content.Font = fontTemp.Font;
                _fontMessage = fontTemp.Font;

            }
        }
        public delegate void ReceiveDelegate(string _content,Font temp);
        public void Receive(string _content,Font temp)
        {
            if (flp_messeage.InvokeRequired)
            {
                this.Invoke(new ReceiveDelegate(Receive), _content,temp);
            }
            else
            {
                if (_content != "")
                {
                    Messeage ms = new Messeage(_usernameReference, _content,temp);
                    flp_messeage.Controls.Add(ms);
                }
            }
        }

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formchat=ClientManager.IsShow(_usernameReference);
            ClientManager.listFormChat.Remove(formchat);
        }
    }
}
