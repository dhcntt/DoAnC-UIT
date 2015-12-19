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
        public Message1( string content,Font temp)
        {
            InitializeComponent();
            lbl_content.Font = temp;
            //lbl_user.Text = user;
            lbl_content.Text = content;
            Size size = TextRenderer.MeasureText(lbl_content.Text, lbl_content.Font);
            if (size.Width > 300)
            {
                int count = size.Width / 300;
                int lenght = content.Length / (count + 1);
                int tile = size.Width / content.Length;
                int sizeText = 300 / tile;
                for (int i = 0; i < count; i++)
                {
                    content = content.Insert((i + 1) * sizeText , "\n");
                }
                this.Width = 300 + 30;
                lbl_content.Text = content;
                Size size1 = TextRenderer.MeasureText(lbl_content.Text, lbl_content.Font);
                this.Height = size1.Height/(count+1)*count + 15+Math.Abs(size.Height/2-size1.Height/(count+1));
            }
            else
            {
                if (size.Width+30 > this.Width)
                {
                    this.Width = size.Width+30;
                }
                lbl_content.Text = content;
            }
        }
    }
}
