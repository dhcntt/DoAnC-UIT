namespace Client_UIT
{
    partial class Form_Notice
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
            this.flp_notice = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_notice
            // 
            this.flp_notice.AutoScroll = true;
            this.flp_notice.BackColor = System.Drawing.Color.Transparent;
            this.flp_notice.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_notice.Location = new System.Drawing.Point(1, 2);
            this.flp_notice.Name = "flp_notice";
            this.flp_notice.Size = new System.Drawing.Size(527, 332);
            this.flp_notice.TabIndex = 26;
            this.flp_notice.WrapContents = false;
            // 
            // Form_Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 336);
            this.Controls.Add(this.flp_notice);
            this.Name = "Form_Notice";
            this.Text = "Form_Notice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_notice;
    }
}