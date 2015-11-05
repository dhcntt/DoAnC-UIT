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
    public partial class MessageCustom : Form
    {
        
        string CaptionTemp;
        public MessageCustom(string _Text,string _caption,Font _font)
        {
            InitializeComponent();
            Text.Text = _Text;
            CaptionTemp = _caption;
            Text.Font = _font;
        }
        Point _form = new Point(0, 0);
        Point current_form = new Point(0, 0);
        Point curs = new Point(0, 0);
        void setpoint()
        {
            _form = this.Location;
            curs = Cursor.Position;
        }
        static DialogResult Result;
      

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Result = DialogResult.OK;
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            current_form.X = _form.X - curs.X + Cursor.Position.X;
            current_form.Y = _form.Y - curs.Y + Cursor.Position.Y;
            this.Location = new Point(current_form.X, current_form.Y);
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpoint();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void bbt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.bbt_close.BackgroundImage = global::Client_UIT.Properties.Resources.close1;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.bbt_close.BackgroundImage = global::Client_UIT.Properties.Resources.close;
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                e.Graphics.DrawString(CaptionTemp, myFont, Brushes.White, new Point(13, 12));
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))
            {
                e.Graphics.DrawString("Xác nhận", myFont, Brushes.White, new Point(2, 5));
            }
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_ok1;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_ok;
        }
        public static DialogResult Show(string text,string Caption,Font _font)
        {
             MessageCustom ms = new MessageCustom(text, Caption,_font);
            ms.ShowDialog();
            
            return Result;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
