
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ptb_title = new System.Windows.Forms.PictureBox();
            this.ptb_account = new System.Windows.Forms.PictureBox();
            this.ptb_password = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.ptb_dangnhap = new System.Windows.Forms.PictureBox();
            this.ptb_dangki = new System.Windows.Forms.PictureBox();
            this.ptb_close = new System.Windows.Forms.PictureBox();
            this.ptb_minimize = new System.Windows.Forms.PictureBox();
            this.txt_password = new Client_UIT.TextBoxCustom();
            this.txt_dangnhap = new Client_UIT.TextBoxCustom();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_account)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangnhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).BeginInit();
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
            // ptb_account
            // 
            this.ptb_account.BackColor = System.Drawing.Color.Transparent;
            this.ptb_account.BackgroundImage = global::Client_UIT.Properties.Resources.oie_transparent;
            this.ptb_account.ErrorImage = null;
            this.ptb_account.Location = new System.Drawing.Point(81, 213);
            this.ptb_account.Name = "ptb_account";
            this.ptb_account.Size = new System.Drawing.Size(231, 70);
            this.ptb_account.TabIndex = 6;
            this.ptb_account.TabStop = false;
            // 
            // ptb_password
            // 
            this.ptb_password.BackColor = System.Drawing.Color.Transparent;
            this.ptb_password.BackgroundImage = global::Client_UIT.Properties.Resources.oie_transparent;
            this.ptb_password.ErrorImage = null;
            this.ptb_password.Location = new System.Drawing.Point(81, 280);
            this.ptb_password.Name = "ptb_password";
            this.ptb_password.Size = new System.Drawing.Size(231, 70);
            this.ptb_password.TabIndex = 7;
            this.ptb_password.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(81, 357);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Nhớ mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Location = new System.Drawing.Point(204, 356);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Tự động đăng nhập";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // ptb_dangnhap
            // 
            this.ptb_dangnhap.BackColor = System.Drawing.Color.Transparent;
            this.ptb_dangnhap.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
            this.ptb_dangnhap.Location = new System.Drawing.Point(96, 412);
            this.ptb_dangnhap.Name = "ptb_dangnhap";
            this.ptb_dangnhap.Size = new System.Drawing.Size(200, 44);
            this.ptb_dangnhap.TabIndex = 15;
            this.ptb_dangnhap.TabStop = false;
            this.ptb_dangnhap.Click += new System.EventHandler(this.ptb_dangnhap_Click);
            this.ptb_dangnhap.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_dangnhap_Paint);
            this.ptb_dangnhap.MouseLeave += new System.EventHandler(this.ptb_dangnhap_MouseLeave);
            this.ptb_dangnhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_dangnhap_MouseMove);
            // 
            // ptb_dangki
            // 
            this.ptb_dangki.BackColor = System.Drawing.Color.Transparent;
            this.ptb_dangki.BackgroundImage = global::Client_UIT.Properties.Resources.bbt_dangnhap;
            this.ptb_dangki.Location = new System.Drawing.Point(96, 462);
            this.ptb_dangki.Name = "ptb_dangki";
            this.ptb_dangki.Size = new System.Drawing.Size(200, 44);
            this.ptb_dangki.TabIndex = 16;
            this.ptb_dangki.TabStop = false;
            this.ptb_dangki.Click += new System.EventHandler(this.ptb_dangki_Click);
            this.ptb_dangki.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_dangki_Paint);
            this.ptb_dangki.MouseLeave += new System.EventHandler(this.ptb_dangki_MouseLeave);
            this.ptb_dangki.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb_dangki_MouseMove);
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
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Bpassword = true;
            this.txt_password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Gray;
            this.txt_password.Location = new System.Drawing.Point(96, 305);
            this.txt_password.Name = "txt_password";
            this.txt_password.NullText = false;
            this.txt_password.Size = new System.Drawing.Size(200, 19);
            this.txt_password.TabIndex = 20;
            this.txt_password.Text = "Nhập mật khẩu của bạn";
            this.txt_password.WatermarkActive = true;
            this.txt_password.WatermarkText = "Nhập mật khẩu của bạn";
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // txt_dangnhap
            // 
            this.txt_dangnhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dangnhap.Bpassword = false;
            this.txt_dangnhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dangnhap.ForeColor = System.Drawing.Color.Gray;
            this.txt_dangnhap.Location = new System.Drawing.Point(96, 238);
            this.txt_dangnhap.Name = "txt_dangnhap";
            this.txt_dangnhap.NullText = false;
            this.txt_dangnhap.Size = new System.Drawing.Size(200, 19);
            this.txt_dangnhap.TabIndex = 19;
            this.txt_dangnhap.Text = "Nhập tài khoản của bạn";
            this.txt_dangnhap.WatermarkActive = true;
            this.txt_dangnhap.WatermarkText = "Nhập tài khoản của bạn";
            this.txt_dangnhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dangnhap_KeyPress);
            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client_UIT.Properties.Resources.form;
            this.ClientSize = new System.Drawing.Size(400, 585);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_dangnhap);
            this.Controls.Add(this.ptb_minimize);
            this.Controls.Add(this.ptb_close);
            this.Controls.Add(this.ptb_dangki);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ptb_password);
            this.Controls.Add(this.ptb_account);
            this.Controls.Add(this.ptb_title);
            this.Controls.Add(this.ptb_dangnhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(430, 120);
            this.Name = "Dangnhap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Dangnhap_Load);
            this.Click += new System.EventHandler(this.Dangnhap_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_account)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangnhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_dangki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ptb_title;
        private System.Windows.Forms.PictureBox ptb_account;
        private System.Windows.Forms.PictureBox ptb_password;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.PictureBox ptb_dangnhap;
        private System.Windows.Forms.PictureBox ptb_dangki;
        private System.Windows.Forms.PictureBox ptb_close;
        private System.Windows.Forms.PictureBox ptb_minimize;
        private TextBoxCustom txt_dangnhap;
        private TextBoxCustom txt_password;
      
    }
}