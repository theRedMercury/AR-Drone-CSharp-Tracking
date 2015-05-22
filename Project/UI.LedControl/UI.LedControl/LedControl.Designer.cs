using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Threading;

namespace UI.LedControl
{
    partial class LedControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        

        public enum statutLed
        {
            [Description("#95a5a6")]//#f1f1f1
            Off = 1,
            [Description("#27ae60")]//#00ff00
            On = 2,
            [Description("#d35400")]//#ff6804
            Warning = 3,
            [Description("#c0392b")]//#ff0000
            Error = 4
            
        }

        private System.Windows.Forms.Timer timer = null;
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
        public void setText(string t)
        {
            this.label1.Text = t;
            
        }

        public void changColor(Color col)
        {
            this.label1.ForeColor = col;
            this.rectangleShape1.BorderColor = col;
        }

        public string ToDescriptionString(statutLed val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public void setStatut(statutLed stl)
        {
            lock (this)
            {
                this.label1.ForeColor = ColorTranslator.FromHtml(this.ToDescriptionString(stl));
                this.rectangleShape1.BorderColor = ColorTranslator.FromHtml(this.ToDescriptionString(stl));

            }
                    
        }

        public void blinking(bool blink)
        {
            if (this.timer == null)
            {
                this.timer = new System.Windows.Forms.Timer();
                this.timer.Interval = 500;
                this.timer.Enabled = false;
            }
            if (!this.timer.Enabled && blink)
            {
                this.timer.Enabled = blink;
                this.timer.Start();

                if (blink)
                    timer.Tick += new EventHandler(timer_Tick);
            }
            if (!blink)
            {
                this.timer.Stop();
            }
          

            
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (this.label1.ForeColor == ColorTranslator.FromHtml("#f1f1f1"))
            {
                this.label1.ForeColor = ColorTranslator.FromHtml("#f10000");
                this.rectangleShape1.BorderColor = ColorTranslator.FromHtml("#f10000");
            }
            else
            {
                this.label1.ForeColor = ColorTranslator.FromHtml("#f1f1f1");
                this.rectangleShape1.BorderColor = ColorTranslator.FromHtml("#f1f1f1");
            }
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(90, 40);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.rectangleShape1.BorderWidth = 2;
            this.rectangleShape1.Location = new System.Drawing.Point(5, 5);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(80, 30);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(90, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label label1;
    }
}
