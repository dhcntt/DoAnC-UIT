using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_UIT
{
    public partial class Message1 : UserControl
    {
        string _image_icon;
        public Message1( string content,Font temp)
        {
            InitializeComponent();
            //lbl_content.Font = temp;
            ////lbl_user.Text = user;
            //lbl_content.Text = content;
            //Size size = TextRenderer.MeasureText(lbl_content.Text, lbl_content.Font);
            //if (size.Width > 300)
            //{
            //    int count = size.Width / 300;
            //    int lenght = content.Length / (count + 1);
            //    int tile = size.Width / content.Length;
            //    int sizeText = 300 / tile;
            //    for (int i = 0; i < count; i++)
            //    {
            //        content = content.Insert((i + 1) * sizeText , "\n");
            //    }
            //    this.Width = 300 + 30;
            //    lbl_content.Text = content;
            //    Size size1 = TextRenderer.MeasureText(lbl_content.Text, lbl_content.Font);
            //    this.Height = size1.Height/(count+1)*count + 15+Math.Abs(size.Height/2-size1.Height/(count+1));
            //}
            //else
            //{
            //    if (size.Width+30 > this.Width)
            //    {
            //        this.Width = size.Width+30;
            //    }
            //    lbl_content.Text = content;
            //}

            ////////////////
            RichTextBox rtb = new RichTextBox();
            rtb.BorderStyle = BorderStyle.None;
            rtb.Multiline = true;
            int _width = this.Size.Width;
            this.Size = new System.Drawing.Size(_width, (int)(content.Length  + 30));
            rtb.Height = this.Size.Height;
            rtb.Width = this.Size.Width;
            rtb.Font = temp;
            
            string chuoi_tam;
            for (int i = 0; i < content.Length; i++)
            {
                chuoi_tam = "";
                if (content[i] == ':' && i+2<content.Length)
                {
                    chuoi_tam += content[i + 1];
                    chuoi_tam += content[i + 2];
                    if (image_name(chuoi_tam))
                    {
                        Bitmap myBitmap = new Bitmap(_image_icon);
                        //// Copy bitmap vào clipboard.
                        Clipboard.SetDataObject(myBitmap);
                        // Lấy định dạng của đối tượng ảnh
                        DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                        // Kiểm tra xem có thể copy định dạng ảnh vào RichTextBox
                        if (rtb.CanPaste(myFormat))
                        {
                            //nếu được thì "add" vào
                            rtb.Paste(myFormat);
                            rtb.Show();
                        }
                        i += 2;
                    }
                    else {
                        string a = "";
                        a += content[i];
                        rtb.AppendText(a);
                    }
                }
                else {
                    string a = "";
                    a += content[i];
                    rtb.AppendText(a);
                }
            }

           // rtb.Text = content;
            this.Controls.Add(rtb);
            rtb.ReadOnly = true;
        }
        public bool image_name(string s)
        {
            _image_icon = "";
            if (s == "01")
                _image_icon = "image\\1.png";
            else if (s == "02")
                _image_icon = "image\\2.png";
            else if (s == "03")
                _image_icon = "image\\3.png";
            else if (s == "04")
                _image_icon = "image\\4.png";
            else if (s == "05")
                _image_icon = "image\\5.png";
            else if (s == "06")
                _image_icon = "image\\6.png";
            else if (s == "07")
                _image_icon = "image\\7.png";
            else if (s == "08")
                _image_icon = "image\\8.png";
            else if (s == "09")
                _image_icon = "image\\9.png";
            else if (s == "10")
                _image_icon = "image\\10.png";
            if (_image_icon != "")
                return true;
            else return false;
        }
        private void Message1_Load(object sender, EventArgs e)
        {

        }
    }
}
