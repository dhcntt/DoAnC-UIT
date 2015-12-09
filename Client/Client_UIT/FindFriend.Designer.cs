namespace Client_UIT
{
    partial class FindFriend
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
            this.lbl_find = new System.Windows.Forms.Label();
            this.bbt_findFriend = new System.Windows.Forms.Button();
            this.lbl_notfound = new System.Windows.Forms.Label();
            this.bbt_nextfriend = new System.Windows.Forms.Button();
            this.ptb_avatar = new System.Windows.Forms.PictureBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_username1 = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_email1 = new System.Windows.Forms.Label();
            this.bbt_addfriend = new System.Windows.Forms.Button();
            this.txt_findFriend = new Client_UIT.TextBoxCustom();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_find
            // 
            this.lbl_find.AutoSize = true;
            this.lbl_find.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_find.Location = new System.Drawing.Point(147, 157);
            this.lbl_find.Name = "lbl_find";
            this.lbl_find.Size = new System.Drawing.Size(131, 16);
            this.lbl_find.TabIndex = 1;
            this.lbl_find.Text = "Nhập Talk ID/Tên";
            // 
            // bbt_findFriend
            // 
            this.bbt_findFriend.Location = new System.Drawing.Point(406, 281);
            this.bbt_findFriend.Name = "bbt_findFriend";
            this.bbt_findFriend.Size = new System.Drawing.Size(75, 23);
            this.bbt_findFriend.TabIndex = 2;
            this.bbt_findFriend.Text = "Tìm bạn";
            this.bbt_findFriend.UseVisualStyleBackColor = true;
            this.bbt_findFriend.Click += new System.EventHandler(this.bbt_findFriend_Click);
            // 
            // lbl_notfound
            // 
            this.lbl_notfound.AutoSize = true;
            this.lbl_notfound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_notfound.Location = new System.Drawing.Point(170, 135);
            this.lbl_notfound.Name = "lbl_notfound";
            this.lbl_notfound.Size = new System.Drawing.Size(179, 16);
            this.lbl_notfound.TabIndex = 3;
            this.lbl_notfound.Text = "Không tìm thấy người này";
            this.lbl_notfound.Visible = false;
            // 
            // bbt_nextfriend
            // 
            this.bbt_nextfriend.Location = new System.Drawing.Point(373, 269);
            this.bbt_nextfriend.Name = "bbt_nextfriend";
            this.bbt_nextfriend.Size = new System.Drawing.Size(108, 23);
            this.bbt_nextfriend.TabIndex = 4;
            this.bbt_nextfriend.Text = "Tìm bạn khác";
            this.bbt_nextfriend.UseVisualStyleBackColor = true;
            this.bbt_nextfriend.Visible = false;
            this.bbt_nextfriend.Click += new System.EventHandler(this.bbt_nextfriend_Click);
            // 
            // ptb_avatar
            // 
            this.ptb_avatar.Location = new System.Drawing.Point(134, 110);
            this.ptb_avatar.Name = "ptb_avatar";
            this.ptb_avatar.Size = new System.Drawing.Size(79, 79);
            this.ptb_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar.TabIndex = 5;
            this.ptb_avatar.TabStop = false;
            this.ptb_avatar.Visible = false;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(219, 123);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(85, 16);
            this.lbl_username.TabIndex = 6;
            this.lbl_username.Text = "Tài khoản :";
            this.lbl_username.Visible = false;
            // 
            // lbl_username1
            // 
            this.lbl_username1.AutoSize = true;
            this.lbl_username1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username1.Location = new System.Drawing.Point(302, 123);
            this.lbl_username1.Name = "lbl_username1";
            this.lbl_username1.Size = new System.Drawing.Size(0, 16);
            this.lbl_username1.TabIndex = 7;
            this.lbl_username1.Visible = false;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(223, 158);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(55, 16);
            this.lbl_email.TabIndex = 8;
            this.lbl_email.Text = "Email :";
            this.lbl_email.Visible = false;
            // 
            // lbl_email1
            // 
            this.lbl_email1.AutoSize = true;
            this.lbl_email1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email1.Location = new System.Drawing.Point(298, 158);
            this.lbl_email1.Name = "lbl_email1";
            this.lbl_email1.Size = new System.Drawing.Size(0, 16);
            this.lbl_email1.TabIndex = 9;
            this.lbl_email1.Visible = false;
            // 
            // bbt_addfriend
            // 
            this.bbt_addfriend.Location = new System.Drawing.Point(284, 269);
            this.bbt_addfriend.Name = "bbt_addfriend";
            this.bbt_addfriend.Size = new System.Drawing.Size(75, 23);
            this.bbt_addfriend.TabIndex = 10;
            this.bbt_addfriend.Text = "Thêm bạn";
            this.bbt_addfriend.UseVisualStyleBackColor = true;
            this.bbt_addfriend.Visible = false;
            this.bbt_addfriend.Click += new System.EventHandler(this.bbt_addfriend_Click);
            // 
            // txt_findFriend
            // 
            this.txt_findFriend.Bpassword = false;
            this.txt_findFriend.ForeColor = System.Drawing.Color.Gray;
            this.txt_findFriend.Location = new System.Drawing.Point(284, 152);
            this.txt_findFriend.Name = "txt_findFriend";
            this.txt_findFriend.NullText = false;
            this.txt_findFriend.Size = new System.Drawing.Size(100, 20);
            this.txt_findFriend.TabIndex = 0;
            this.txt_findFriend.WatermarkActive = true;
            this.txt_findFriend.WatermarkText = "";
            this.txt_findFriend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_findFriend_KeyPress);
            // 
            // FindFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 333);
            this.Controls.Add(this.bbt_addfriend);
            this.Controls.Add(this.lbl_email1);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_username1);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.ptb_avatar);
            this.Controls.Add(this.bbt_nextfriend);
            this.Controls.Add(this.lbl_notfound);
            this.Controls.Add(this.bbt_findFriend);
            this.Controls.Add(this.lbl_find);
            this.Controls.Add(this.txt_findFriend);
            this.Name = "FindFriend";
            this.Text = "FindFriend";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindFriend_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxCustom txt_findFriend;
        private System.Windows.Forms.Label lbl_find;
        private System.Windows.Forms.Button bbt_findFriend;
        private System.Windows.Forms.Label lbl_notfound;
        private System.Windows.Forms.Button bbt_nextfriend;
        private System.Windows.Forms.PictureBox ptb_avatar;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_username1;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_email1;
        private System.Windows.Forms.Button bbt_addfriend;

    }
}