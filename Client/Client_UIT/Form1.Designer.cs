namespace Client_UIT
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ptb_close = new System.Windows.Forms.PictureBox();
            this.ptb_minimize = new System.Windows.Forms.PictureBox();
            this.ptb_avatar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flp_listFriend = new System.Windows.Forms.FlowLayoutPanel();
            this.bbt_addfriend = new System.Windows.Forms.Button();
            this.lbThongTin = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người dùng:";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.BackColor = System.Drawing.Color.Transparent;
            this.lbl_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(149, 81);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(0, 20);
            this.lbl_user.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // ptb_avatar
            // 
            this.ptb_avatar.BackColor = System.Drawing.SystemColors.Window;
            this.ptb_avatar.Location = new System.Drawing.Point(28, 81);
            this.ptb_avatar.Name = "ptb_avatar";
            this.ptb_avatar.Size = new System.Drawing.Size(79, 79);
            this.ptb_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar.TabIndex = 19;
            this.ptb_avatar.TabStop = false;
            this.ptb_avatar.Click += new System.EventHandler(this.ptb_avatar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Trạng thái";
            // 
            // flp_listFriend
            // 
            this.flp_listFriend.Location = new System.Drawing.Point(153, 222);
            this.flp_listFriend.Margin = new System.Windows.Forms.Padding(0);
            this.flp_listFriend.Name = "flp_listFriend";
            this.flp_listFriend.Size = new System.Drawing.Size(246, 360);
            this.flp_listFriend.TabIndex = 21;
            // 
            // bbt_addfriend
            // 
            this.bbt_addfriend.Location = new System.Drawing.Point(291, 185);
            this.bbt_addfriend.Name = "bbt_addfriend";
            this.bbt_addfriend.Size = new System.Drawing.Size(75, 23);
            this.bbt_addfriend.TabIndex = 22;
            this.bbt_addfriend.Text = "button1";
            this.bbt_addfriend.UseVisualStyleBackColor = true;
            this.bbt_addfriend.Click += new System.EventHandler(this.bbt_addfriend_Click);
            // 
            // lbThongTin
            // 
            this.lbThongTin.AutoSize = true;
            this.lbThongTin.Location = new System.Drawing.Point(28, 185);
            this.lbThongTin.Name = "lbThongTin";
            this.lbThongTin.Size = new System.Drawing.Size(52, 13);
            this.lbThongTin.TabIndex = 23;
            this.lbThongTin.TabStop = true;
            this.lbThongTin.Text = "Thông tin";
            this.lbThongTin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbThongTin_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(400, 584);
            this.Controls.Add(this.lbThongTin);
            this.Controls.Add(this.bbt_addfriend);
            this.Controls.Add(this.flp_listFriend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ptb_avatar);
            this.Controls.Add(this.ptb_minimize);
            this.Controls.Add(this.ptb_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ptb_close;
        private System.Windows.Forms.PictureBox ptb_minimize;
        private System.Windows.Forms.PictureBox ptb_avatar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flp_listFriend;
        private System.Windows.Forms.Button bbt_addfriend;
        private System.Windows.Forms.LinkLabel lbThongTin;
    }
}

