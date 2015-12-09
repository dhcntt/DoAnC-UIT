namespace Client_UIT
{
    partial class Chat
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
            this.rTB_content = new System.Windows.Forms.RichTextBox();
            this.flp_messeage = new System.Windows.Forms.FlowLayoutPanel();
            this.bbt_gui = new System.Windows.Forms.Button();
            this.bbt_font = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rTB_content
            // 
            this.rTB_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTB_content.Location = new System.Drawing.Point(12, 252);
            this.rTB_content.Name = "rTB_content";
            this.rTB_content.Size = new System.Drawing.Size(516, 96);
            this.rTB_content.TabIndex = 0;
            this.rTB_content.Text = "";
            // 
            // flp_messeage
            // 
            this.flp_messeage.AutoScroll = true;
            this.flp_messeage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flp_messeage.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_messeage.Location = new System.Drawing.Point(12, 12);
            this.flp_messeage.Name = "flp_messeage";
            this.flp_messeage.Size = new System.Drawing.Size(516, 209);
            this.flp_messeage.TabIndex = 1;
            this.flp_messeage.WrapContents = false;
            // 
            // bbt_gui
            // 
            this.bbt_gui.Location = new System.Drawing.Point(410, 354);
            this.bbt_gui.Name = "bbt_gui";
            this.bbt_gui.Size = new System.Drawing.Size(75, 23);
            this.bbt_gui.TabIndex = 2;
            this.bbt_gui.Text = "Gửi";
            this.bbt_gui.UseVisualStyleBackColor = true;
            this.bbt_gui.Click += new System.EventHandler(this.bbt_gui_Click);
            // 
            // bbt_font
            // 
            this.bbt_font.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbt_font.Location = new System.Drawing.Point(12, 227);
            this.bbt_font.Name = "bbt_font";
            this.bbt_font.Size = new System.Drawing.Size(28, 23);
            this.bbt_font.TabIndex = 3;
            this.bbt_font.Text = "A";
            this.bbt_font.UseVisualStyleBackColor = true;
            this.bbt_font.Click += new System.EventHandler(this.bbt_font_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(114, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "A";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(80, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "A";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(46, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "A";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 389);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bbt_font);
            this.Controls.Add(this.bbt_gui);
            this.Controls.Add(this.flp_messeage);
            this.Controls.Add(this.rTB_content);
            this.Name = "Chat";
            this.Text = "Chat";
<<<<<<< HEAD
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chat_FormClosed);
=======
>>>>>>> 254841375a781fe47587c9cc588e7372e753005e
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTB_content;
        private System.Windows.Forms.FlowLayoutPanel flp_messeage;
        private System.Windows.Forms.Button bbt_gui;
        private System.Windows.Forms.Button bbt_font;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}