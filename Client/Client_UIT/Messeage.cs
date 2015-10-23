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
    public partial class Messeage : UserControl
    {
        public Messeage(string user, string content,Font temp)
        {
            InitializeComponent();
            lbl_content.Font = temp;
            lbl_user.Text = user;
            lbl_content.Text = content;
        }
        public Messeage(string user, string content)
        {
            InitializeComponent();
           // lbl_content.Font = temp;
            lbl_user.Text = user;
            lbl_content.Text = content;
        }
    }
}
