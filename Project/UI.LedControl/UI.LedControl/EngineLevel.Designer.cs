using System;
using System.Drawing;
using System.Windows.Forms;
namespace UI.LedControl
{
    partial class EngineLevel
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

        public void setLevelEngine(int perCent)
        {
           
            this.labLevelEng.Text = Convert.ToString(perCent);
            //25 - 105
            this.recLitLevelEng.Location = new Point(11, (int)(105.0 - ((perCent / 100.0) * 80)));
            this.recLevelEng.Location = new Point(15, (int)(105.0 - ((perCent / 100.0) * 80)) + 2);      
            
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.recLitLevelEng = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.recLevelEng = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.labLevelEng = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.recLitLevelEng,
            this.recLevelEng,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(42, 112);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // recLitLevelEng
            // 
            this.recLitLevelEng.BackColor = System.Drawing.Color.Maroon;
            this.recLitLevelEng.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.recLitLevelEng.BorderColor = System.Drawing.Color.Maroon;
            this.recLitLevelEng.Location = new System.Drawing.Point(11, 100);
            this.recLitLevelEng.Name = "recLitLevelEng";
            this.recLitLevelEng.Size = new System.Drawing.Size(19, 2);
            // 
            // recLevelEng
            // 
            this.recLevelEng.BackColor = System.Drawing.Color.White;
            this.recLevelEng.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.recLevelEng.BorderColor = System.Drawing.Color.White;
            this.recLevelEng.FillColor = System.Drawing.Color.White;
            this.recLevelEng.Location = new System.Drawing.Point(15, 27);
            this.recLevelEng.Name = "recLevelEng";
            this.recLevelEng.Size = new System.Drawing.Size(13, 82);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.White;
            this.rectangleShape2.BorderWidth = 2;
            this.rectangleShape2.FillColor = System.Drawing.Color.White;
            this.rectangleShape2.Location = new System.Drawing.Point(14, 26);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(14, 85);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.Black;
            this.rectangleShape1.BorderColor = System.Drawing.Color.White;
            this.rectangleShape1.BorderWidth = 2;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.White;
            this.rectangleShape1.Location = new System.Drawing.Point(1, 1);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(40, 20);
            // 
            // labLevelEng
            // 
            this.labLevelEng.BackColor = System.Drawing.Color.Transparent;
            this.labLevelEng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labLevelEng.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLevelEng.ForeColor = System.Drawing.Color.White;
            this.labLevelEng.Location = new System.Drawing.Point(4, 2);
            this.labLevelEng.Name = "labLevelEng";
            this.labLevelEng.Size = new System.Drawing.Size(36, 18);
            this.labLevelEng.TabIndex = 1;
            this.labLevelEng.Text = "100%";
            this.labLevelEng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EngineLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labLevelEng);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "EngineLevel";
            this.Size = new System.Drawing.Size(42, 112);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recLitLevelEng;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape recLevelEng;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label labLevelEng;
    }
}
