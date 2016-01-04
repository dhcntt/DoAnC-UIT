using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_UIT
{

    //Messeage là 1 thẻ user control.
    //nó bao gồm thông tin người gởi(hoặc nhận) và tin nhắn
    public partial class Messeage : UserControl
    {
        Font font_style;
        public Messeage(string user,string content,Font temp)
        {
            InitializeComponent();
            font_style = temp;
            lbl_user.Text = user;
            lbl_content.Font = font_style;
            lbl_content.Text = content;
        }
    }
}
