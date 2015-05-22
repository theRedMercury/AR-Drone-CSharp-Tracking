using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX.DirectInput;
using OculusDrone;

namespace A.R.Drone.Main.UIClass
{
    public partial class OculusWin : Form
    {
        private MainWin win;
        private OculusRiftDrone hdmOculus;
        private bool camH = true;
        private double correctJoy = 2000.0;
        private double switchViewOcculus = 0.0;
        private int distCropImg = 50;
        private int sizeWImg = 400;

        public OculusWin(MainWin w, OculusRiftDrone oc)
        {
            InitializeComponent();

            this.win = w;
            this.hdmOculus = oc;

            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Focus();

            this.picVideoImgL.Width = (this.Width / 2) - 10;
            this.picVideoImgR.Width = (this.Width / 2) - 10;
        }

        public void updateVideo(Bitmap img)
        {
           
            lock (this)
            {
                //img = new Bitmap(img, new Size(this.sizeWImg, 280));
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                Bitmap nb = new Bitmap((img.Width - this.distCropImg), img.Height);
                Graphics g = Graphics.FromImage(nb);
                g.DrawImage(img, this.distCropImg, 0);

                Bitmap nb2 = new Bitmap((img.Width + this.distCropImg), img.Height);
                Graphics g2 = Graphics.FromImage(nb2);
                g2.DrawImage(img, -this.distCropImg, 0);

           
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)(() =>
                    {
                        //Bitmap i = ImageEffectOculus.BarrelDistortion(img, 2.0,true,Color.Black);
                        this.picVideoImgL.BackgroundImage = nb;// ImageEffectOculus.BarrelDistortion(img, 2.0);
                        this.picVideoImgR.BackgroundImage = nb2;// ImageEffectOculus.BarrelDistortion(img, 2.0);//this.ScaleImage(img, this.picVideoImg.Width, this.picVideoImg.Height);
                    }));
                }
            }
        }

        public void UpdateJoyControlShow(JoystickState state)
        {

            float gazV = (float)0.0;
            if (this.hdmOculus.IsConnected())
            {
                if (this.hdmOculus.GetOrientation()[1] < this.switchViewOcculus && this.camH)
                {
                    this.camH = false;
                    this.win.WinSwitchCameraDrone(this.camH);
                }
                if (this.hdmOculus.GetOrientation()[1] > this.switchViewOcculus && !this.camH)
                {
                    this.camH = true;
                    this.win.WinSwitchCameraDrone(this.camH);
                }

            }
            this.Invoke((Action)(() =>
            {
                this.label1.Text = this.hdmOculus.GetOrientation()[0].ToString("0.00") + "\n" +
               this.hdmOculus.GetOrientation()[1].ToString("0.00") + "\n" +
               this.hdmOculus.GetOrientation()[2].ToString("0.00") + "\n" +
               this.hdmOculus.GetOrientation()[3].ToString("0.00") + "\n" +

               this.hdmOculus.GetAcceleration()[0].ToString("0.000") + "\n" +
               this.hdmOculus.GetAcceleration()[1].ToString("0.000") + "\n" +
               this.hdmOculus.GetAcceleration()[2].ToString("0.000") + "\n";
            }));
           
            lock (this)
            {
                if (!this.IsDisposed)
                {
                    
                    if (state.GetPointOfViewControllers()[0] == 0)
                    {
                        gazV = (float)0.25;
                    }
                    if (state.GetPointOfViewControllers()[0] == 18000)
                    {
                        gazV = (float)-0.25;
                    }
                    //Butt

                    if (state.GetButtons()[2])
                    {
                        this.win.WinDroneTakeOff();
                    }
                    if (state.GetButtons()[3])
                    {

                        this.win.WinDroneLanding();
                    }
                    if (state.GetButtons()[0])
                    {
                        this.win.WinDroneBlinkingLed();
                    }

                    //this.win.WinDroneAllControlDrone((float)(state.RotationZ / this.correctJoy), gazV, (float)(state.Y / this.correctJoy), (float)(state.X / this.correctJoy));

                    this.win.WinDroneAllControlDrone((float)(state.RotationZ / 1500.0), gazV, (float)(state.Y / this.correctJoy), (float)(state.X / this.correctJoy));

                }
            }
        }

        private void OculusWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.distCropImg += 1;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.distCropImg -= 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.sizeWImg += 1;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.sizeWImg -= 1;
            }
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                this.Hide();
                this.Parent = null;
                this.win.quitWinOculus();
            }
        }

        private void OculusWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

       

       

       
    }
}
