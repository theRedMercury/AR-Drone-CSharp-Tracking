using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tux.Controls;
using A.R.Drone.Main.Instrument;
using AR.Drone.Data.Navigation;
using AR.Drone.Data;
using AR.Drone.Data.Navigation.Native;
using SlimDX.DirectInput;
using System.IO;
using System.Text.RegularExpressions;

namespace A.R.Drone.Main.UIClass
{
    public partial class WinFullScreen : Form
    {
        private MainWin win;
        private ArtificalHorizont hud;
        private double correctJoy = 2000.0;
        private int comptImg = 0;
        private Bitmap imgToSave;

        public WinFullScreen(MainWin w)
        {
            InitializeComponent();
            
           
            this.win = w;
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Win_KeyDown);
            // Simple_HUD.dll
            this.hud = new ArtificalHorizont();
            this.hud.Location = new System.Drawing.Point(0, 0);
            this.hud.Size = new System.Drawing.Size(300, 280);
            this.panel3.Controls.Add(this.hud);



            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Focus();

            this.imgToSave = new Bitmap(640,360);
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"\\Photos";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] filePaths = Directory.GetFiles(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Photos\\", "*.png");
            if (filePaths.Count() != 0)
            {
                try
                {
                    var regex = new Regex(@"([0-9]+)");
                    var matches = regex.Matches(filePaths[filePaths.Count()-1].ToString());
                    this.comptImg = Convert.ToInt32(matches[matches.Count-1].Value.ToString());

                }
                catch (Exception er)
                {
                    Console.WriteLine("Coucou "+er.Message);
                    this.comptImg = 0;
                }
            }
            
        }

        public void updateData(NavigationData navD,  NavdataBag navB)
        {
            lock (this)
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)(() =>
                    {
                        this.hud.Roll = -(float)(navD.Roll * 180.0 / Math.PI);
                        this.hud.Pitch = (float)(navD.Pitch * 180.0 / Math.PI);
                        this.headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters((Convert.ToInt32((navD.Yaw) * 180.0 / Math.PI) + 180));

                        this.labAlti.Text = (navB.altitude.altitude_vision - 238).ToString();//238 Aprox :p
                        this.labSpeed.Text = (navB.wind_speed.wind_speed).ToString();
                        this.labbat.Text = (navD.Battery.Percentage).ToString();

                        this.engineLevel1.setLevelEngine((int)(((int)navB.pwm.motor1 / 255.0) * 100));
                        this.engineLevel2.setLevelEngine((int)(((int)navB.pwm.motor2 / 255.0) * 100));
                        this.engineLevel3.setLevelEngine((int)(((int)navB.pwm.motor3 / 255.0) * 100));
                        this.engineLevel4.setLevelEngine((int)(((int)navB.pwm.motor4 / 255.0) * 100));
                    }));
                }
            }
        }

        public void updateVideo(Bitmap img)
        {
            lock (this)
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)(() =>
                    {
                        lock (this.imgToSave)
                        {
                            Graphics g = Graphics.FromImage(this.imgToSave);
                            g.DrawImage(img, 0, 0);
                        }
                        this.picVideoImg.BackgroundImage = img;//this.ScaleImage(img, this.picVideoImg.Width, this.picVideoImg.Height);
                    }));
                }
            }
        }


        private void WinFullScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
           
           // this.win.quitWinFullScreen();
            
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
        public void UpdateJoyControlShow(JoystickState state)
        {
            float gazV = (float)0.0;
            lock (this)
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)(() =>
                    {
                        this.ovalShapXY.Location = new Point((int)(((state.X) / 20) + 46), (int)(((state.Y) / 20) + 46));
                        this.ovalShapZ.Location = new Point((int)(((state.RotationZ) / 20) + 46), 93);
                        this.labJoyInfo.Text = "X : " + (state.X / this.correctJoy).ToString("0.000") +
                                                "\nY : " + (state.Y / this.correctJoy).ToString("0.000") +
                                                "\nZ : " + (state.RotationZ / 1500.0).ToString("0.000");

                        //Pov
                        this.panelAltiUp.BackColor = Color.Black;
                        this.panelAltiDown.BackColor = Color.Black;

                        if (state.GetPointOfViewControllers()[0] == 0)
                        {
                            this.panelAltiUp.BackColor = Color.Green;
                            gazV = (float)0.25;
                        }
                        if (state.GetPointOfViewControllers()[0] == 18000)
                        {
                            this.panelAltiDown.BackColor = Color.Green;
                            gazV = (float)-0.25;
                        }



                        //Butt
                        this.labTakeOff.BackColor = Color.Black;
                        this.labLanding.BackColor = Color.Black;
                        this.labPhoto.BackColor = Color.Black;
                        if (state.GetButtons()[2])
                        {
                            this.labTakeOff.BackColor = Color.Green;
                            this.win.WinDroneTakeOff();
                        }
                        if (state.GetButtons()[3])
                        {
                            this.labLanding.BackColor = Color.Green;
                            this.win.WinDroneLanding();
                        }
                        if (state.GetButtons()[0])
                        {
                            this.win.WinDroneBlinkingLed();
                        }
                        if (state.GetButtons()[1])
                        {
                            try
                            {
                                
                                this.imgToSave.Save(System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"\\Photos\\img" + this.comptImg.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                                this.comptImg += 1;
                                this.labPhoto.BackColor = Color.Green;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error : "+ex.Message);
                            }
                        }
                        this.ovalShapXY.Update();
                        this.ovalShapZ.Update();
                    }));
                    //this.win.WinDroneAllControlDrone((float)(state.RotationZ / this.correctJoy), gazV, (float)(state.Y / this.correctJoy), (float)(state.X / this.correctJoy));

                    this.win.WinDroneAllControlDrone((float)(state.RotationZ / 1500.0), gazV, (float)(state.Y / this.correctJoy), (float)(state.X / this.correctJoy));

                }
            }
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        { 
           
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                this.Hide();
                this.Parent = null;
                this.win.quitWinFullScreen();
            }
        }

        private void butMasterTakeOff_Click(object sender, EventArgs e)
        {
            this.win.WinDroneTakeOff();
        }

        private void butLand_Click(object sender, EventArgs e)
        {
            this.win.WinDroneLanding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.win.WinDroneHover();
            this.Dispose();
            this.win.quitWinFullScreen();
        }

       

        
    }
}
