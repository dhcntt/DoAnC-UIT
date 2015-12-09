namespace Client_UIT
{
    partial class Friend
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_username = new System.Windows.Forms.Label();
            this.txt_status = new System.Windows.Forms.Label();
            this.ptb_avatar = new System.Windows.Forms.PictureBox();
            this.ptb_status = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_status)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_username
            // 
            this.txt_username.AutoSize = true;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.Location = new System.Drawing.Point(52, 8);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(0, 16);
            this.txt_username.TabIndex = 1;
            // 
            // txt_status
            // 
            this.txt_status.AutoSize = true;
            this.txt_status.Location = new System.Drawing.Point(53, 28);
            this.txt_status.Name = "txt_status";
            this.txt_status.Size = new System.Drawing.Size(0, 13);
            this.txt_status.TabIndex = 2;
            // 
            // ptb_avatar
            // 
            this.ptb_avatar.Location = new System.Drawing.Point(199, 6);
            this.ptb_avatar.Name = "ptb_avatar";
            this.ptb_avatar.Size = new System.Drawing.Size(35, 33);
            this.ptb_avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_avatar.TabIndex = 3;
            this.ptb_avatar.TabStop = false;
            // 
            // ptb_status
            // 
            this.ptb_status.Location = new System.Drawing.Point(12, 12);
            this.ptb_status.Name = "ptb_status";
            this.ptb_status.Size = new System.Drawing.Size(25, 25);
            this.ptb_status.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_status.TabIndex = 0;
            this.ptb_status.TabStop = false;
            // 
            // Friend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ptb_avatar);
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.ptb_status);
            this.Name = "Friend";
            this.Size = new System.Drawing.Size(238, 48);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_status;
        private System.Windows.Forms.Label txt_username;
        private System.Windows.Forms.Label txt_status;
        private System.Windows.Forms.PictureBox ptb_avatar;
    }
}
