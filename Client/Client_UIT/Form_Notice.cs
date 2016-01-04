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
    public partial class Form_Notice : Form
    {
        ClientManager client;
        public List<Notice_List> listNotice = new List<Notice_List>();
        public Form_Notice(ClientManager ClientTemp)
        {
            InitializeComponent();
            client = ClientTemp;
            
        }
        
        public delegate void UpDate_Notice_delegate(bool kt);
        public void update_Notice(bool kt)
        {
            if (flp_notice.InvokeRequired)
            {
                this.Invoke(new UpDate_Notice_delegate(update_Notice), kt);
            }
            else
            {
                //clear();
                if (kt)
                {
                    List<Control> listControls = flp_notice.Controls.Cast<Control>().ToList();
                    foreach (Control control in listControls)
                    {
                        flp_notice.Controls.Remove(control);
                        control.Dispose();
                    }
                }
                for (int i = 0; i < listNotice.Count; i++)
                {
                    Notice noticeTemp = new Notice(listNotice[i]._stt, listNotice[i]._userPrimary, listNotice[i]._userReference, listNotice[i]._type, listNotice[i]._time, client);
                    flp_notice.Controls.Add(noticeTemp);
                }
            }
        }
    }
}
