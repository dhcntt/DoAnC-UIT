namespace Client_UIT
{
    partial class Notice
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
            this.lbl_content = new System.Windows.Forms.Label();
            this.bbt_cancel = new System.Windows.Forms.Button();
            this.bbt_ok = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_content
            // 
            this.lbl_content.AutoSize = true;
            this.lbl_content.Location = new System.Drawing.Point(20, 31);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(0, 13);
            this.lbl_content.TabIndex = 0;
            // 
            // bbt_cancel
            // 
            this.bbt_cancel.Location = new System.Drawing.Point(318, 59);
            this.bbt_cancel.Name = "bbt_cancel";
            this.bbt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bbt_cancel.TabIndex = 1;
            this.bbt_cancel.Text = "Hủy";
            this.bbt_cancel.UseVisualStyleBackColor = true;
            this.bbt_cancel.Click += new System.EventHandler(this.bbt_cancel_Click);
            // 
            // bbt_ok
            // 
            this.bbt_ok.Location = new System.Drawing.Point(222, 59);
            this.bbt_ok.Name = "bbt_ok";
            this.bbt_ok.Size = new System.Drawing.Size(75, 23);
            this.bbt_ok.TabIndex = 2;
            this.bbt_ok.Text = "Xác nhận";
            this.bbt_ok.UseVisualStyleBackColor = true;
            this.bbt_ok.Click += new System.EventHandler(this.bbt_ok_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(20, 5);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(0, 13);
            this.lbl_time.TabIndex = 3;
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.bbt_ok);
            this.Controls.Add(this.bbt_cancel);
            this.Controls.Add(this.lbl_content);
            this.Name = "Notice";
            this.Size = new System.Drawing.Size(426, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_content;
        private System.Windows.Forms.Button bbt_cancel;
        private System.Windows.Forms.Button bbt_ok;
        private System.Windows.Forms.Label lbl_time;
    }
}
