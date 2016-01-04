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
    public partial class icon : Form
    {
        Chat _chat;
        int location_x, location_y;
        static int size_y = 119;
        string _image;
        public icon(Chat _fmchat,int x, int y)
        {
            InitializeComponent();
            location_x = x;
            location_y = y;
            _chat = _fmchat;
           
        }

        private void icon_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Location = new System.Drawing.Point(location_x,location_y-size_y);
            this.ResumeLayout();
        }

        private void btn_icon1_Click(object sender, EventArgs e)
        {
            _image = ":01";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon2_Click(object sender, EventArgs e)
        {
            _image = ":02";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon3_Click(object sender, EventArgs e)
        {
            _image = ":03";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon4_Click(object sender, EventArgs e)
        {
            _image = ":04";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon5_Click(object sender, EventArgs e)
        {
            _image = ":05";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon6_Click(object sender, EventArgs e)
        {
            _image = ":06";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon7_Click(object sender, EventArgs e)
        {
            _image = ":07";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon8_Click(object sender, EventArgs e)
        {
            _image = ":08";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon9_Click(object sender, EventArgs e)
        {
            _image = ":09";
            _chat.addtext_rTB(_image);
            this.Close();
        }

        private void btn_icon10_Click(object sender, EventArgs e)
        {
            _image = ":10";
            _chat.addtext_rTB(_image);
            this.Close();
        }
    }
}
