
namespace Client_UIT
{
    partial class Dangnhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dangnhap));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ptb_title = new System.Windows.Forms.PictureBox();
            this.ptb_close = new System.Windows.Forms.PictureBox();
            this.ptb_minimize = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_dangnhap = new Client_UIT.TextBoxCustom();
            this.txt_password = new Client_UIT.TextBoxCustom();
            this.ptb_dangki = new System.Windows.Forms.PictureBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptb_dangnhap = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangnhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ptb_title
            // 
            this.ptb_title.BackColor = System.Drawing.Color.Transparent;
            this.ptb_title.ErrorImage = null;
            this.ptb_title.InitialImage = null;
            this.ptb_title.Location = new System.Drawing.Point(-2, -1);
            this.ptb_title.Name = "ptb_title";
            this.ptb_title.Size = new System.Drawing.Size(402, 50);
            this.ptb_title.TabIndex = 2;
            this.ptb_title.TabStop = false;
            this.ptb_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.ptb_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ptb_close
            // 
            this.ptb_close.BackColor = System.Drawing.Color.Transparent;
            this.ptb_close.BackgroundImage = global::Client_UIT.Properties.Resources.close;
            this.ptb_close.Location = new System.Drawing.Point(368, -1);
            this.ptb_close.Name = "ptb_close";
            this.ptb_close.Size = new System.Drawing.Size(32, 27);
            this.ptb_close.TabIndex = 17;
            this.ptb_close.TabStop = false;
            this.ptb_close.Click += new System.EventHandler(this.ptb_close_Click);
            this.ptb_close.MouseLeave += new System.EventHandler(this.ptb_close_MouseLeave);
            this.ptb_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_close_MouseMove);
            // 
            // ptb_minimize
            // 
            this.ptb_minimize.BackColor = System.Drawing.Color.Transparent;
            this.ptb_minimize.BackgroundImage = global::Client_UIT.Properties.Resources.minimize1;
            this.ptb_minimize.Location = new System.Drawing.Point(335, -1);
            this.ptb_minimize.Name = "ptb_minimize";
            this.ptb_minimize.Size = new System.Drawing.Size(32, 27);
            this.ptb_minimize.TabIndex = 18;
            this.ptb_minimize.TabStop = false;
            this.ptb_minimize.Click += new System.EventHandler(this.ptb_minimize_Click);
            this.ptb_minimize.MouseLeave += new System.EventHandler(this.ptb_minimize_MouseLeave);
            this.ptb_minimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_minimize_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txt_dangnhap);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.ptb_dangnhap);
            this.panel1.Controls.Add(this.ptb_dangki);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Location = new System.Drawing.Point(35, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 466);
            this.panel1.TabIndex = 21;
            // 
            // txt_dangnhap
            // 
            this.txt_dangnhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dangnhap.Bpassword = false;
            this.txt_dangnhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dangnhap.ForeColor = System.Drawing.Color.Gray;
            this.txt_dangnhap.Location = new System.Drawing.Point(65, 127);
            this.txt_dangnhap.Name = "txt_dangnhap";
            this.txt_dangnhap.NullText = false;
            this.txt_dangnhap.Size = new System.Drawing.Size(200, 19);
            this.txt_dangnhap.TabIndex = 25;
            this.txt_dangnhap.Text = "Nhập tài khoản của bạn";
            this.txt_dangnhap.WatermarkActive = true;
            this.txt_dangnhap.WatermarkText = "Nhập tài khoản của bạn";
            this.txt_dangnhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dangnhap_KeyPress);
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Bpassword = true;
            this.txt_password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Gray;
            this.txt_password.Location = new System.Drawing.Point(65, 192);
            this.txt_password.Name = "txt_password";
            this.txt_password.NullText = false;
            this.txt_password.Size = new System.Drawing.Size(200, 19);
            this.txt_password.TabIndex = 26;
            this.txt_password.Text = "Nhập mật khẩu của bạn";
            this.txt_password.WatermarkActive = true;
            this.txt_password.WatermarkText = "Nhập mật khẩu của bạn";
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // ptb_dangki
            // 
            this.ptb_dangki.BackColor = System.Drawing.Color.Transparent;
            this.ptb_dangki.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
            this.ptb_dangki.Location = new System.Drawing.Point(64, 334);
            this.ptb_dangki.Name = "ptb_dangki";
            this.ptb_dangki.Size = new System.Drawing.Size(200, 44);
            this.ptb_dangki.TabIndex = 25;
            this.ptb_dangki.TabStop = false;
            this.ptb_dangki.Click += new System.EventHandler(this.ptb_dangki_Click);
            this.ptb_dangki.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_dangki_Paint);
            this.ptb_dangki.MouseLeave += new System.EventHandler(this.ptb_dangki_MouseLeave);
            this.ptb_dangki.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_dangki_MouseMove);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Location = new System.Drawing.Point(170, 241);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(122, 17);
            this.checkBox3.TabIndex = 23;
            this.checkBox3.Text = "Tự động đăng nhập";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Location = new System.Drawing.Point(47, 242);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(93, 17);
            this.checkBox4.TabIndex = 99;
            this.checkBox4.Text = "Nhớ mật khẩu";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Client_UIT.Properties.Resources.oie_transparent;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(49, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 70);
            this.pictureBox2.TabIndex = 98;
            this.pictureBox2.TabStop = false;
            // 
            // ptb_dangnhap
            // 
            this.ptb_dangnhap.BackColor = System.Drawing.Color.Transparent;
            this.ptb_dangnhap.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
            this.ptb_dangnhap.Location = new System.Drawing.Point(64, 270);
            this.ptb_dangnhap.Name = "ptb_dangnhap";
            this.ptb_dangnhap.Size = new System.Drawing.Size(200, 44);
            this.ptb_dangnhap.TabIndex = 0;
            this.ptb_dangnhap.TabStop = false;
            this.ptb_dangnhap.Click += new System.EventHandler(this.ptb_dangnhap_Click);
            this.ptb_dangnhap.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_dangnhap_Paint);
            this.ptb_dangnhap.MouseLeave += new System.EventHandler(this.ptb_dangnhap_MouseLeave);
            this.ptb_dangnhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_dangnhap_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::Client_UIT.Properties.Resources.oie_transparent;
            this.pictureBox4.ErrorImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(49, 167);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(231, 70);
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Location = new System.Drawing.Point(24, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 466);
            this.panel2.TabIndex = 22;
            this.panel2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(64, 198);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client_UIT.Properties.Resources._400x585;
            this.ClientSize = new System.Drawing.Size(400, 585);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptb_minimize);
            this.Controls.Add(this.ptb_close);
            this.Controls.Add(this.ptb_title);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(430, 120);
            this.Name = "Dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frozen";
            this.Load += new System.EventHandler(this.Dangnhap_Load);
            this.Click += new System.EventHandler(this.Dangnhap_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangnhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ptb_title;
        private System.Windows.Forms.PictureBox ptb_close;
        private System.Windows.Forms.PictureBox ptb_minimize;
        private System.Windows.Forms.Panel panel1;
        private TextBoxCustom txt_dangnhap;
        private System.Windows.Forms.PictureBox pictureBox4;
        private TextBoxCustom txt_password;
        private System.Windows.Forms.PictureBox ptb_dangki;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ptb_dangnhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
      
    }
}