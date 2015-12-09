namespace Server_UIT
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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_dangnhap = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_dangnhap = new System.Windows.Forms.Label();
            this.bbt_dangnhap = new System.Windows.Forms.Button();
            this.bbt_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(113, 58);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 1;
            this.txt_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_password_KeyPress);
            // 
            // txt_dangnhap
            // 
            this.txt_dangnhap.Location = new System.Drawing.Point(113, 26);
            this.txt_dangnhap.Name = "txt_dangnhap";
            this.txt_dangnhap.Size = new System.Drawing.Size(100, 20);
            this.txt_dangnhap.TabIndex = 0;
            this.txt_dangnhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_dangnhap_KeyPress);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(22, 58);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(55, 13);
            this.lbl_password.TabIndex = 5;
            this.lbl_password.Text = "Mật khẩu:";
            // 
            // lbl_dangnhap
            // 
            this.lbl_dangnhap.AutoSize = true;
            this.lbl_dangnhap.Location = new System.Drawing.Point(22, 29);
            this.lbl_dangnhap.Name = "lbl_dangnhap";
            this.lbl_dangnhap.Size = new System.Drawing.Size(84, 13);
            this.lbl_dangnhap.TabIndex = 4;
            this.lbl_dangnhap.Text = "Tên đăng nhập:";
            // 
            // bbt_dangnhap
            // 
            this.bbt_dangnhap.Location = new System.Drawing.Point(25, 109);
            this.bbt_dangnhap.Name = "bbt_dangnhap";
            this.bbt_dangnhap.Size = new System.Drawing.Size(75, 23);
            this.bbt_dangnhap.TabIndex = 2;
            this.bbt_dangnhap.Text = "Đăng nhập";
            this.bbt_dangnhap.UseVisualStyleBackColor = true;
            this.bbt_dangnhap.Click += new System.EventHandler(this.bbt_dangnhap_Click);
            // 
            // bbt_exit
            // 
            this.bbt_exit.Location = new System.Drawing.Point(138, 109);
            this.bbt_exit.Name = "bbt_exit";
            this.bbt_exit.Size = new System.Drawing.Size(75, 23);
            this.bbt_exit.TabIndex = 3;
            this.bbt_exit.Text = "Thoát";
            this.bbt_exit.UseVisualStyleBackColor = true;
            this.bbt_exit.Click += new System.EventHandler(this.bbt_exit_Click);
            // 
            // Dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 167);
            this.Controls.Add(this.bbt_exit);
            this.Controls.Add(this.bbt_dangnhap);
            this.Controls.Add(this.lbl_dangnhap);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txt_dangnhap);
            this.Controls.Add(this.txt_password);
            this.Name = "Dangnhap";
            this.Text = "Dangnhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_dangnhap;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_dangnhap;
        private System.Windows.Forms.Button bbt_dangnhap;
        private System.Windows.Forms.Button bbt_exit;
    }
}