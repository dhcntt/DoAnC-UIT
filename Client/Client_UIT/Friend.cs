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
    //1 user control trong danh sách bạn
    public partial class Friend : UserControl
    {
        public Friend(string _userFriend, Image _imageTemp)
        {
            InitializeComponent();
            txt_username.Text = _userFriend;
            ptb_avatar.Image = _imageTemp;
        }
    }
}
