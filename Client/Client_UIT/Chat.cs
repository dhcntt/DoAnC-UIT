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
using System.Collections.Generic;

namespace Client_UIT
{
    public partial class Chat : Form
    {
        public ClientManager _client;
        Font _fontMessage;
        int load = 1;
        public bool _bSend=true;//chưa gởi
        public bool bLoad = true;
        public bool _bTime = false;
        public bool _bRecive = true;//chưa nhận
        public bool _hien_thi = false;//form co chay hay khong
        public string _usernameReference;
        LinkedListNode<MessageText> display;
        public LinkedList<MessageText> listmessage = new System.Collections.Generic.LinkedList<MessageText>();
        public Chat(ClientManager ClientTemp,string userReferrence)
        {
            InitializeComponent();
            _client = ClientTemp;
            //_usernameMain = usermain;
            _usernameReference = userReferrence;
            _fontMessage = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);           
        }

        public delegate void UpDate_message_delegate(bool kt);
        public void update_message(bool kt)
        {
            if (flp_messeage.InvokeRequired)
            {
                this.flp_messeage.Invoke(new UpDate_message_delegate(update_message), new object[] { kt });
            }
            else
            {
                if (kt)
                {
                    List<Control> listControls = flp_messeage.Controls.Cast<Control>().ToList();
                    foreach (Control control in listControls)
                    {
                        flp_messeage.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                _bSend = true;
                _bRecive = true;
                LinkedListNode<MessageText> msTemp = listmessage.First;
                while (msTemp != null)
                {
                    if (_bSend && _bRecive)//chưa gởi và chưa nhận
                    {
                        string _time = DateTime.Now.ToString();
                        Button a = new Button();
                        a.Width = 490;
                        a.Text = _time;
                        a.BackColor = System.Drawing.Color.Transparent;
                        a.Dock = DockStyle.None;
                        a.FlatAppearance.BorderSize = 0;
                        a.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        a.Enabled = false;
                        flp_messeage.Controls.Add(a);
                    }
                    if (msTemp.Value.type==2)
                    {
                        if (_bRecive)
                        {
                            Messeage ms = new Messeage(this.Text, msTemp.Value.content, msTemp.Value.font);
                            ms.Anchor = AnchorStyles.Left;
                            flp_messeage.Controls.Add(ms);

                            if (msTemp.Next == null)
                            {
                                if (load == 1)
                                {
                                    flp_messeage.ScrollControlIntoView(ms);

                                    load++;
                                }
                            }
                            _bSend = true;
                            _bRecive = false;

                        }
                        else
                        {
                            Message1 ms = new Message1(msTemp.Value.content, msTemp.Value.font);
                            ms.Anchor = AnchorStyles.Left;
                            flp_messeage.Controls.Add(ms);
                            if (msTemp.Next == null)
                            {
                                if (load == 1)
                                {
                                    flp_messeage.ScrollControlIntoView(ms);

                                    load++;
                                }
                            }
                        }
                    }
                    if (msTemp.Value.type == 1)
                    {
                        if (_bSend)
                        {
                            Messeage ms = new Messeage(_client.userName,msTemp.Value.content, msTemp.Value.font);
                            ms.Anchor = AnchorStyles.Right;
                            flp_messeage.Controls.Add(ms);
                            _fontMessage = rTB_content.Font;
                            if (msTemp.Next == null)
                            {
                                if (load == 1)
                                {
                                    flp_messeage.ScrollControlIntoView(ms);

                                    load++;
                                }
                            }
                            _bSend = false;//đã send và chưa nhận
                            _bRecive = true;
                           
                        }
                        else
                        {
                            Message1 ms = new Message1(msTemp.Value.content, msTemp.Value.font);
                            ms.Anchor = AnchorStyles.Right;
                            flp_messeage.Controls.Add(ms);
                            _fontMessage = rTB_content.Font;

                            if (msTemp.Next == null)
                            {
                                if (load == 1)
                                {
                                    flp_messeage.ScrollControlIntoView(ms);

                                    load++;
                                }
                            }
                            //int a = flp_messeage.VerticalScroll.Value;
                           
                        }
                    }
                    msTemp = msTemp.Next;
                }
                //flp_messeage.VerticalScroll.Value = 200;
            }
            bLoad = true;
        }
        
        
        public delegate void Receive_delagate(string userFriend,string content,Font _fontTemp);

        public void Receive(string userFriend, string content, Font _fontTemp)
        {
            if (flp_messeage.InvokeRequired)
            {
                this.Invoke(new Receive_delagate(Receive),userFriend,content,_fontTemp);
            }
            else
            {
                if (_bSend && _bRecive)//chưa gởi và chưa nhận
                {
                    string _time = DateTime.Now.ToString();
                    Button a = new Button();
                    a.Width =490 ;
                    a.Text = _time;
                    a.BackColor = System.Drawing.Color.Transparent;
                    a.Dock = DockStyle.None;
                    a.FlatAppearance.BorderSize = 0;
                    a.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    a.Enabled = false;
                    flp_messeage.Controls.Add(a);
                }
                if (_bRecive)
                {
                    Messeage ms = new Messeage(userFriend, content, _fontTemp);
                    ms.Anchor = AnchorStyles.Left;
                    flp_messeage.Controls.Add(ms);
                   flp_messeage.ScrollControlIntoView(ms);
                   _bSend = true;
                   _bRecive = false;
                   MessageText mst = new MessageText(content, _fontTemp, 2);
                   listmessage.AddLast(mst);
                }
                else
                {
                    Message1 ms = new Message1( content, _fontTemp);
                    ms.Anchor = AnchorStyles.Left;
                    flp_messeage.Controls.Add(ms);
                    flp_messeage.ScrollControlIntoView(ms);
                    MessageText mst = new MessageText(content, _fontTemp, 2);
                    listmessage.AddLast(mst);
                }
            }
        }
        void SendMessage()
        {
            if (_client.socket.Connected)
            {
                if (rTB_content.Text != "\n")
                {
                    //chưa gởi hoặc đã nhận thì gởi message
                    if (_bSend && _bRecive)//chưa gởi và chưa nhận
                    {
                        string _time = DateTime.Now.ToString();
                        Button a = new Button();
                        a.Width = 490;
                        a.Text = _time;
                        a.BackColor = System.Drawing.Color.Transparent;
                        a.Dock = DockStyle.None;
                        a.FlatAppearance.BorderSize = 0;
                        a.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        a.Enabled = false;
                        flp_messeage.Controls.Add(a);


                    }
                    if (_bSend )
                    {
                        Messeage ms = new Messeage(_client.userName, rTB_content.Text, _fontMessage);
                        ms.Anchor = AnchorStyles.Right;
                        flp_messeage.Controls.Add(ms);
                        _fontMessage = rTB_content.Font;
                        flp_messeage.ScrollControlIntoView(ms);
                        _bSend = false;//đã send và chưa nhận
                        _bRecive = true;
                        MessageText mst = new MessageText(rTB_content.Text, _fontMessage, 1);
                        listmessage.AddLast(mst);
                    }
                    else
                    {
                        Message1 ms = new Message1( rTB_content.Text, _fontMessage);
                        ms.Anchor = AnchorStyles.Right;
                        flp_messeage.Controls.Add(ms);
                        _fontMessage = rTB_content.Font;
                        flp_messeage.ScrollControlIntoView(ms);
                        //int a = flp_messeage.VerticalScroll.Value;
                        MessageText mst = new MessageText(rTB_content.Text, _fontMessage, 1);
                        listmessage.AddLast(mst);
                    }
                    if (_usernameReference == "Server")
                    {
                        Command cmd = new Command(Enum.CommandType_.Message, rTB_content.Text, _fontMessage);
                        _client.SendCommand(cmd);
                    }
                    else
                    {
                        Command cmd = new Command(Enum.CommandType_.MessageFriend, this._usernameReference, rTB_content.Text, _fontMessage);
                        _client.SendCommand(cmd);
                    }
                    rTB_content.Text = "";
                }
                else
                {
                    rTB_content.Text = "";
                }
            }
            else
            {
                MessageCustom.Show("Kết nối với client đã bị đóng!", "Thông báo", new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            }
        }

        private Button Button()
        {
            throw new NotImplementedException();
        }
        private void bbt_gui_Click(object sender, EventArgs e)
        {
            SendMessage();   
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
        

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            var formchat=ClientManager.IsShow(_usernameReference);
            ClientManager.listFormChat.Remove(formchat);
        }

        private void rTB_content_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
            {
                SendMessage();
            }
        }

        private void Chat_Resize(object sender, EventArgs e)
        {
        }

        private void flp_messeage_Scroll(object sender, ScrollEventArgs e)
        {
            if (bLoad)
            {
                if (flp_messeage.VerticalScroll.Value / 30 <= flp_messeage.Controls.Count / 5)
                {
                    Command cmd = new Command(Enum.CommandType_.LoadMessage, _usernameReference, listmessage.Count);
                    _client.SendCommand(cmd);
                    //flp_messeage.ScrollControlIntoView(flp_messeage.Controls[flp_messeage.Controls.Count - 1]);
                    bLoad = false;
                }
            }
        }

        private void flp_messeage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_icon_Click(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            icon _icon = new icon(this, x,y);
            _icon.ShowDialog();
            
        }
        public void addtext_rTB(string _str)
        {
            rTB_content.AppendText(_str);
        }
        private void rTB_content_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            _hien_thi = true;
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hien_thi = false;
        }
        
    }
    public class MessageText
    {
        public string content;
        public Font font;
        public int type;

        public MessageText(string _contentTemp, Font _fontTemp, int _typeTemp)
        {
            content = _contentTemp;
            font = _fontTemp;
            type = _typeTemp;
        }
    }
}
