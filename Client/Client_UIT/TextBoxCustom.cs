using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Client_UIT
{
    class TextBoxCustom : TextBox
    {
        private string _watermarkText = "";
        /// <summary>
        /// Gets or Sets the text that will be presented as the watermak hint
        /// </summary>
        public string WatermarkText
        {
            get { return _watermarkText; }
            set
            {
                _watermarkText = value;

                if (Bpassword)
                    this.PasswordChar = '\0';

                this.Text = value;
            }
        }
        private bool _NullText;

        public bool NullText
        {
            get { return _NullText; }
            set { _NullText = value; }
        }
        private bool _bpassword;

        public bool Bpassword
        {
            get { return _bpassword; }
            set
            {
                _bpassword = value;
            }
        }

        /// <summary>
        /// Whether watermark effect is enabled or not
        /// </summary>
        private bool _watermarkActive = true;
        /// <summary>
        /// Gets or Sets whether watermark effect is enabled or not
        /// </summary>
        public bool WatermarkActive
        {
            get { return _watermarkActive; }
            set { _watermarkActive = value;
            this.Text = _watermarkText;
            }

        }
        public TextBoxCustom()
            : base()
        {
            this._watermarkActive = true;
            this.Text = _watermarkText;
            this.ForeColor = Color.Gray;

            GotFocus += (source, e) =>
            {
                RemoveWatermak();
            };

            LostFocus += (source, e) =>
            {
                ApplyWatermark();
            };
            _lost = new lostFocus(ApplyWatermark);
        }
        public delegate void lostFocus();
        public lostFocus _lost;
        /// <summary>
        /// Remove watermark from the textbox
        /// </summary>
        /// //khi focus vào textbox
        public void RemoveWatermak()
        {
            if (this._watermarkActive)
            {
                if (this.Bpassword == false)
                {
                    this._watermarkActive = false;
                    this.Text = "";
                    this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.ForeColor = Color.Black;
                }
                else
                {
                    this._watermarkActive = false;
                    this.Text = "";
                    this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.ForeColor = Color.Black;
                    this.PasswordChar = '●';
                }
            }
        }

        /// <summary>
        /// Applywatermak immediately
        /// </summary>
        /// 
        //khi ko focus vào textbox
        public void ApplyWatermark()
        {
            if (!this._watermarkActive && string.IsNullOrEmpty(this.Text)
                || ForeColor == Color.Gray)
            {
                if (this.Bpassword == false)
                {
                    this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this._watermarkActive = true;
                    this.Text = _watermarkText;
                    this.ForeColor = Color.Gray;
                    _NullText = false;
                }
                else
                {
                    this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this._watermarkActive = true;
                    this.ForeColor = Color.Gray;
                    this.Text = _watermarkText;
                    _NullText = false;
                    this.PasswordChar = '\0';
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    _NullText = true;
                }
            }
        }

        /// <summary>
        /// Apply watermak to the textbox. 
        /// </summary>
        /// <param name="newText">Text to apply</param>
      

    }

}
