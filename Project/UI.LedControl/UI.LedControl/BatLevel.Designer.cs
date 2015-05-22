using System.Drawing;
using System.Windows.Forms;

namespace UI.LedControl
{
    partial class BatLevel
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

        public void setBorderColor(Color col)
        {
            this.rectangleShape1.BorderColor = col;
            this.rectangleShape2.BorderColor = col;
            this.rectangleShape2.BackColor = col;
        }
        // en %
        public void setBatLevel(int lev)
        {
            
            this.batRectLevel.Location = new Point(4, (int)(52.0 - ((lev / 100.0) * 36.0)));

            this.batRectLevel.Size = new Size(22, (int)((lev / 100.0) * 36.0) + 1);
            if (lev == 0)
                this.batRectLevel.Size = new Size(22, 0);
           
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.batRectLevel = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.batRectLevel,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(32, 57);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // batRectLevel
            // 
            this.batRectLevel.BackColor = System.Drawing.Color.Red;
            this.batRectLevel.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.batRectLevel.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.batRectLevel.Location = new System.Drawing.Point(4, 16);
            this.batRectLevel.Name = "batRectLevel";
            this.batRectLevel.Size = new System.Drawing.Size(22, 36);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.White;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.BorderColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(6, 1);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(18, 10);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.White;
            this.rectangleShape1.BorderWidth = 4;
            this.rectangleShape1.Location = new System.Drawing.Point(2, 14);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(26, 40);
            // 
            // BatLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.shapeContainer1);
            this.Name = "BatLevel";
            this.Size = new System.Drawing.Size(32, 57);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape batRectLevel;
    }
}
