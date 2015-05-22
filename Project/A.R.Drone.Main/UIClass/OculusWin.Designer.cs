namespace A.R.Drone.Main.UIClass
{
    partial class OculusWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusWin));
            this.picVideoImgL = new System.Windows.Forms.PictureBox();
            this.picVideoImgR = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImgL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImgR)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picVideoImgL
            // 
            this.picVideoImgL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picVideoImgL.BackColor = System.Drawing.Color.Black;
            this.picVideoImgL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picVideoImgL.InitialImage = ((System.Drawing.Image)(resources.GetObject("picVideoImgL.InitialImage")));
            this.picVideoImgL.Location = new System.Drawing.Point(3, 3);
            this.picVideoImgL.Name = "picVideoImgL";
            this.picVideoImgL.Size = new System.Drawing.Size(342, 302);
            this.picVideoImgL.TabIndex = 2;
            this.picVideoImgL.TabStop = false;
            // 
            // picVideoImgR
            // 
            this.picVideoImgR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picVideoImgR.BackColor = System.Drawing.Color.Black;
            this.picVideoImgR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picVideoImgR.InitialImage = ((System.Drawing.Image)(resources.GetObject("picVideoImgR.InitialImage")));
            this.picVideoImgR.Location = new System.Drawing.Point(351, 3);
            this.picVideoImgR.Name = "picVideoImgR";
            this.picVideoImgR.Size = new System.Drawing.Size(343, 302);
            this.picVideoImgR.TabIndex = 3;
            this.picVideoImgR.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picVideoImgL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picVideoImgR, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(697, 308);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Oculus... not here";
            // 
            // OculusWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(697, 308);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OculusWin";
            this.Text = "OculusWin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OculusWin_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OculusWin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImgL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideoImgR)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picVideoImgL;
        private System.Windows.Forms.PictureBox picVideoImgR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}