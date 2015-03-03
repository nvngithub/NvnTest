using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NvnTest.Common {
    public class TextCtrl : RichTextBox {
        public TextCtrl() {
            this.BorderStyle = BorderStyle.None;
            this.ReadOnly = true;
            this.BackColor = SystemColors.Window;
            this.Margin = new Padding(0);
        }

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    Graphics gs = Graphics.FromHwnd(this.Handle);
        //    Font f = this.Font;
        //    if (this.Text != "")
        //    {
        //        string[] texts = this.Text.Split('\n');
        //        int hi = 0;
        //        foreach (string text in texts)
        //        {
        //            SizeF sf = gs.MeasureString(text, f);
        //            hi += (int)(sf.Width / (this.Width - SystemInformation.VerticalScrollBarWidth)) + 1;
        //        }
        //        this.Height = Convert.ToInt16(hi * f.Height) + 8;
        //    }

        //    base.OnTextChanged(e);
        //}

        public void ResizeControl() {
            Graphics gs = Graphics.FromHwnd(this.Handle);
            Font f = this.Font;
            if (this.Text != "") {
                string[] texts = this.Text.Split('\n');
                int hi = 0;
                foreach (string text in texts) {
                    SizeF sf = gs.MeasureString(text, f);
                    hi += (int)(sf.Width / (this.Width - SystemInformation.VerticalScrollBarWidth)) + 1;
                }
                this.Height = Convert.ToInt16(hi * f.Height) + 8;
            }
        }

        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }
    }
}