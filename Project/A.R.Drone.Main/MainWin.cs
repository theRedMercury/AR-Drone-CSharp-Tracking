using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;

using AR.Drone.Client;
using AR.Drone.Client.Configuration;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;
using AR.Drone.Data.Navigation.Native;
using A.R.Drone.Main.UIClass;
using A.R.Drone.Main.Wifi;
using AR.Drone.Media;
using AR.Drone.Video;
using UI.LedControl;

using Simple_HUD;
using SlimDX.DirectInput;
using System.Globalization;
using OculusDrone;


namespace A.R.Drone.Main
{

    public partial class MainWin : Form, IObserver
    {
        private DroneControl droneControl;
        private IContainer components = null;
        private WinFullScreen winFullScreenDrone = null;
        private OculusWin winOculusDrone = null;
        private HUD_Graphic hudDrone;

        private OculusRiftDrone hdmOculus;

        private JoystickDrone joyControl;
        

        private List<double> xData = new List<double>();
        private List<double> yData = new List<double>();
        private List<double> zData = new List<double>();

        private List<double> yawData = new List<double>();
        private List<double> pitchData = new List<double>();
        private List<double> rollData = new List<double>();

        private bool pickColor = false;
        private bool manualComIsShow = false;
        private StreamWriter fileData = new StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath)+"\\flight data.txt");
       
        public MainWin()
        {

            string lines = String.Format("{0:dddd, d/M/yyyy HH:mm:ss}", DateTime.Now) + "\n-------------------------" +
                "\nYaw\t\tPitch\t\tRoll";
            this.fileData.WriteLine(lines);

            this.droneControl = new DroneControl();
            this.droneControl.AddObserver(this);

            this.joyControl = new JoystickDrone(this);
            this.hdmOculus = new OculusRiftDrone();

            InitializeComponent();
           
            //Run to High Priority
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            this.panelManualControl.Hide();
            foreach (Control c in this.panelManualControl.Controls)
            {
                c.Enabled = false;
               
            }

            this.ScrollBarRectRange.Value = Convert.ToInt32(this.droneControl.RatioRectDetecRange*10);
            this.hScrollAirMin.Value = this.droneControl.AirMinRangeDetect;
            this.hScrollAirMax.Value = this.droneControl.AirMaxRangeDetect;
            this.labAireMin.Text = this.hScrollAirMin.Value.ToString();
            this.labAireMax.Text = this.hScrollAirMax.Value.ToString();

            this.ovalShapAirActu.Size = new Size(0,0);
            this.ovalShapAirActu.Location = new Point(70,70);


            this.checkHistoEqual.Checked = this.droneControl.HistogramEqual;
            /*
            JoystickDroneWin wJ = new JoystickDroneWin();
            wJ.ShowDialog();*/
            //Led UI
            this.ledFly.setText("FLY");
            this.ledFly.setStatut(LedControl.statutLed.Off);

            this.ledLand.setText("LAND");
            this.ledLand.setStatut(LedControl.statutLed.Error);

            this.ledTracking.setText("TRACK");
            this.ledTracking.setStatut(LedControl.statutLed.Warning);
            //-----
            //Level Engine Init
            this.engineLevel1.setLevelEngine(0);
            this.engineLevel2.setLevelEngine(25);
            this.engineLevel3.setLevelEngine(80);
            this.engineLevel4.setLevelEngine(100);

            this.batLevel1.setBatLevel(50);

            this.label1.Text = "X";

            // Simple_HUD.dll
            this.hudDrone = new HUD_Graphic();
            this.hudDrone.Location = new System.Drawing.Point(0, 46);
            this.hudDrone.Size = new System.Drawing.Size(400, 450);
            this.hudDrone.BrushAlpha = 75;
            this.hudDrone.BrushTextBackgroundAlpha = 255;
            //this.hudDrone.ClientSize = new System.Drawing.Size(400, 450);
            this.panelMainDataControl.Controls.Add(this.hudDrone);

            this.butMasterTakeOff.Enabled = false;

            this.consolDataDrone.Text = ">";

            //Init color Detect Drone and Data
            this.panelColor.BackColor = Color.FromArgb(215,0,0);
            this.droneControl.ColorToDetect = this.panelColor.BackColor;
            this.trackBarRadius.Value = 100;
            this.labRad.Text = "Radius : " + this.trackBarRadius.Value.ToString();
            this.droneControl.Radius = this.trackBarRadius.Value;
            this.droneControl.Tracking = true;

            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanInterface in client.Interfaces)
            {  
                this.toolStripWifiName.Text = "Wifi : " + GetStringForSSID(wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid);
                this.toolStripWifiLenght.Value = (int)wlanInterface.CurrentConnection.wlanAssociationAttributes.wlanSignalQuality;
            }
        }
        private string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        public double[] XPlot
        {
            get { return this.xData.ToArray(); }
        }
        public double[] YPlot
        {
            get { return this.yData.ToArray(); }
        }
        public double[] ZPlot
        {
            get { return this.zData.ToArray(); }
        }

        public double[] HeadDat
        {
            get { lock (this) { return this.yawData.ToArray(); } }
        }
        public double[] PitchDat
        {
            get {  lock (this) {return this.pitchData.ToArray();} }
        }
        public double[] RollDat
        {
            get { lock (this) { return this.rollData.ToArray(); } }
        }

        public void quitWinFullScreen()
        {
            this.winFullScreenDrone = null;
            this.droneControl.SwitchCameraH(true);
            this.droneControl.JoyControlOn = false;
        }
        public void quitWinOculus()
        {
            this.winOculusDrone = null;
            this.droneControl.SwitchCameraH(true);
            this.droneControl.JoyControlOn = false;
        }

        public void UpdateJoyControl(JoystickState state)
        {
          
                if ( this.joyControl.IsRunning() &&!this.IsDisposed && !this.labJoyInfo.IsDisposed && state != null)
                {
                    if (this.winFullScreenDrone == null || this.winOculusDrone == null)
                    {
                        try
                        {
                            this.Invoke((Action)(() =>
                            {
                                bool[] buttons = state.GetButtons();
                                string strText = "";
                                for (int b = 0; b < buttons.Length; b++)
                                {
                                    if (buttons[b])
                                        strText += b.ToString("00 ", CultureInfo.CurrentCulture);
                                }
                                int[] pov = state.GetPointOfViewControllers();

                                this.labJoyInfo.Text = "X : " + state.X.ToString(CultureInfo.CurrentCulture) + "\n" +
                                    "Y : " + state.Y.ToString(CultureInfo.CurrentCulture) + "\n" +
                                    "R Z : " + state.RotationZ.ToString(CultureInfo.CurrentCulture) + "\n" +
                                    "POV : " + pov[0].ToString(CultureInfo.CurrentCulture) + "\n" +
                                    "But : " + strText;
                            }));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (this.winFullScreenDrone != null && !this.winFullScreenDrone.IsDisposed)
                    {
                        this.winFullScreenDrone.UpdateJoyControlShow(state);
                    }

                    if (this.winOculusDrone != null && !this.winOculusDrone.IsDisposed)
                    {
                        this.winOculusDrone.UpdateJoyControlShow(state);
                    }
                }
            
        }

        //Observer-----------------------------------
        public void UpdateData(NavigationData navD, NavigationPacket navP, NavdataBag navB)
        {
            if (!this.IsDisposed && navP.Data != null && navD != null)
            {
                if (this.winFullScreenDrone == null && this.winOculusDrone == null)
                {

                    this.Invoke((Action)(() =>
                    {
                        this.hudDrone.Altitude = navB.altitude.altitude_vision - 238;//238 Aprox :p
                        this.hudDrone.Heading = (Convert.ToInt32((navD.Yaw) * 180.0 / Math.PI) + 180);
                        this.hudDrone.Pitch = (float)(navD.Pitch * 180.0 / Math.PI);
                        this.hudDrone.Roll = -(float)(navD.Roll * 180.0 / Math.PI);
                        this.hudDrone.Airspeed = 0;
                        this.hudDrone.Draw();

                        this.batLevel1.setBatLevel((int)navD.Battery.Percentage);

                        this.engineLevel1.setLevelEngine((int)(((int)navB.pwm.motor1 / 255.0) * 100));
                        this.engineLevel2.setLevelEngine((int)(((int)navB.pwm.motor2 / 255.0) * 100));
                        this.engineLevel3.setLevelEngine((int)(((int)navB.pwm.motor3 / 255.0) * 100));
                        this.engineLevel4.setLevelEngine((int)(((int)navB.pwm.motor4 / 255.0) * 100));

                        var ctrl_state = (CTRL_STATES)(navB.demo.ctrl_state >> 0x10);
                        switch (ctrl_state)
                        {
                            case CTRL_STATES.CTRL_LANDED:
                                this.ledFly.setStatut(LedControl.statutLed.Warning);
                                break;
                            case CTRL_STATES.CTRL_FLYING:
                                this.ledFly.setStatut(LedControl.statutLed.On);
                                break;
                            default:
                                this.ledFly.setStatut(LedControl.statutLed.Error);
                                break;
                        }

                        var flying_state = (FLYING_STATES)(navB.demo.ctrl_state & 0xffff);
                        switch (Convert.ToString(flying_state))
                        {
                            case "FLYING_OK":
                                this.ledLand.setStatut(LedControl.statutLed.On);
                                break;
                            default:
                                this.ledLand.setStatut(LedControl.statutLed.Warning);
                                break;
                        }


                        if (this.droneControl.CrossInRect())
                        {
                            this.ledTracking.setStatut(LedControl.statutLed.On);
                        }
                        else
                        {
                            this.ledTracking.setStatut(LedControl.statutLed.Warning);
                        }
                        if (!this.droneControl.Tracking)
                        {
                            this.ledTracking.setStatut(LedControl.statutLed.Error);
                        }


                        this.label1.Text = "X : " + navD.Magneto.Rectified.X.ToString("0.000") +
                        "  Y : " + navD.Magneto.Rectified.Y.ToString("0.000") +
                        "  Z : " + navD.Magneto.Rectified.Z.ToString("0.000") +
                        "\nYaw : " + (navD.Yaw * (180.0 / Math.PI) + 180).ToString("0.000") +
                        "\nAlti : " + navB.altitude.altitude_vision +
                        "\nBat : " + navD.Battery.Percentage +
                            //"     - V X = " + navdataBag.raw_measures.+

                        "\nState : " + navD.State +
                        "\nFrame Size : " + navB.video_stream.frame_size
                        ;




                        this.tvInfo.Invoke(new MethodInvoker(delegate
                        {
                            tvInfo.BeginUpdate();

                            TreeNode node = tvInfo.Nodes.GetOrCreate("Navigation Data");
                            if (navD != null) DumpBranch(node.Nodes, navD);

                            node = tvInfo.Nodes.GetOrCreate("Configuration");
                            //if (this.droneControl.Se != null) DumpBranch(node.Nodes, settings);

                            TreeNode vativeNode = tvInfo.Nodes.GetOrCreate("Native");
                            DumpBranch(node.Nodes, navB);

                            tvInfo.EndUpdate();
                        }));

                        this.Update();
                    }));
                    lock (this)
                    {
                        if (this.xData.Count > 1000)
                        {
                            this.xData.Clear();
                            this.yData.Clear();
                            this.zData.Clear();
                            //
                            this.yawData.Clear();
                            this.pitchData.Clear();
                            this.rollData.Clear();

                        }


                        this.xData.Add(Convert.ToDouble(navB.magneto.magneto_rectified.x));
                        this.yData.Add(Convert.ToDouble(navB.magneto.magneto_rectified.y));
                        this.zData.Add(Convert.ToDouble(navB.magneto.magneto_rectified.z));

                        this.yawData.Add(((navD.Yaw) * 180.0 / Math.PI) + 180);
                        this.pitchData.Add((navD.Pitch * 180.0 / Math.PI));
                        this.rollData.Add((navD.Roll * 180.0 / Math.PI));
                    }
                    string lines = Convert.ToString(((navD.Yaw) * 180.0 / Math.PI) + 180) + "\t\t" +
                        Convert.ToString((navD.Pitch * 180.0 / Math.PI)) + "\t\t" +
                        Convert.ToString((navD.Roll * 180.0 / Math.PI));
                    this.fileData.WriteLine(lines);
                }
                if (this.winFullScreenDrone != null && !this.winFullScreenDrone.IsDisposed)
                {
                    this.winFullScreenDrone.updateData(navD, navB);
                }
            }
           
        }

        public void UpdateVideo(Bitmap img)
        {
            if (this.winFullScreenDrone == null && this.winOculusDrone == null)
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((Action)(() =>
                    {
                        //if (!this.picVideoImg.IsDisposed )
                        //{
                            this.picVideoImg.BackgroundImage = img;
                        //}
                    }));
                }
            }
            if (this.winFullScreenDrone != null && !this.winFullScreenDrone.IsDisposed)
            {
                this.winFullScreenDrone.updateVideo(img);
            }
            if (this.winOculusDrone != null && !this.winOculusDrone.IsDisposed)
            {
                this.winOculusDrone.updateVideo(img);
            }
        }

        public void UpdateControl(float pitchV, float yawV, float gazV, float rollV, int airDetecV)
        {
             this.Invoke((Action)(() =>
             {
                this.shapeGaz.Location = new System.Drawing.Point(-15, (int)(((gazV) * 140) + 58));
                this.shapeYawPitch.Location = new System.Drawing.Point((int)(((yawV) * 140) + 58), (int)(((pitchV) * 140) + 58));
                this.shapeGaz.Update();
                this.shapeYawPitch.Update();
                this.labDataCorrect.Text = "Pitch : " + pitchV.ToString() +
                                           "\nYaw : " + yawV.ToString() +
                                           "\nGaz : " + gazV.ToString();
                this.labAireActu.Text = airDetecV.ToString();


                this.ovalShapAirActu.Size = new Size(Convert.ToInt32((airDetecV / 1000) * (5.4)),
                    Convert.ToInt32((airDetecV / 1000) * (5.4)));
                this.ovalShapAirActu.Location = new Point((140 - this.ovalShapAirActu.Height) / 2, (140 - this.ovalShapAirActu.Width) / 2);
                //this.ovalShapAirMin.Update();
                this.ovalShapAirActu.Update();
                                            
             }));
        }

        //-------------------------------------------

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //MainWin_FormClosed
            this.winFullScreenDrone = null;

            this.winOculusDrone = null;


            this.joyControl.Stop();
            this.fileData.Close();
            this.droneControl.ExitDrone();
            Thread.Sleep(50);
            this.Dispose();

            Application.ExitThread();

        }

        private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.winFullScreenDrone=null;
                this.winOculusDrone = null;
            
                this.joyControl.Stop();
                this.fileData.Close();
                this.droneControl.ExitDrone();
                this.Dispose();
            
            Application.ExitThread();
        }

      
        //CODE FOR DRONE --------------------------------------------------------

        private void connectDroneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!this.statutConnect.Text.Equals("Statut : Connect"))
            {
                this.droneControl.ConnectDrone();
                statutConnect.Text = "Statut : Wait Connections...";
                this.consolDataDrone.Text += "Wait Connections...\n>";
                //Init interface
                this.engineLevel1.setLevelEngine(0);
                this.engineLevel2.setLevelEngine(0);
                this.engineLevel3.setLevelEngine(0);
                this.engineLevel4.setLevelEngine(0);
                this.ledFly.blinking(true);
            }
            //Very useless... UDP server broadcast everywhere :)
            if (this.droneControl.CheckDroneConnect())
            {
                statutConnect.Text = "Statut : Connected";
                this.consolDataDrone.Text += "Connected\n>";
                //this.timeUpdateData.Enabled = true;
               // this.timeUpdateVideo.Enabled = true;
                this.butMasterTakeOff.Text = "Take Off";
                this.butMasterTakeOff.Enabled = true;

                this.ledFly.blinking(false);
            }
        }

        private void resetEmergencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.droneControl.ResetEmergencyDrone();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutARDrone win = new AboutARDrone();
            win.ShowDialog();
        }

        private void butMasterEmergency_Click(object sender, EventArgs e)
        {
            this.droneControl.ResetEmergencyDrone();
        }

        private void butMasterTakeOff_Click(object sender, EventArgs e)
        {
            this.consolDataDrone.Text += "> TakeOff\n>";
            this.droneControl.TakeOffDrone();
        }

        private void butLand_Click(object sender, EventArgs e)
        {
            this.consolDataDrone.Text += "> Land\n>";
            this.droneControl.LandingProcessDrone();
        }

        public void SendToConsol(String msg)
        {
            this.Invoke((Action)(() =>
            {
                this.consolDataDrone.Text += "> "+msg+"\n>";
            }));
        }

        public void WinDroneAllControlDrone(float yawV, float gazV, float pitchV, float rollV)
        {
            //this.consolDataDrone.Text += "> JoyControl\n>";
            this.droneControl.AllMouvementDrone( yawV,  gazV,  pitchV,  rollV);
        }
        public void WinDroneBlinkingLed()
        {
            this.droneControl.LedBlickingDrone();
        }

        public void WinDroneTakeOff()
        {
            /*this.Invoke((Action)(() =>
            {
                this.consolDataDrone.Text += "> TakeOff\n>";
            }));*/
            this.droneControl.TakeOffDrone();
        }

        public void WinDroneLanding()
        {
            /*this.Invoke((Action)(() =>
            {
                this.consolDataDrone.Text += "> Land\n>";
            }));*/
            this.droneControl.LandingDrone();
        }

        public void WinSwitchCameraDrone(bool h)
        {
            this.droneControl.SwitchCameraH(h);
        }

        public void WinDroneForward()
        {
            this.droneControl.ForwardDrone();
            this.consolDataDrone.Text += "> Forward\n>";   
        }

        public void WinDroneLeft()
        {
            this.consolDataDrone.Text += "> Left\n>";
            this.droneControl.TurnLeftdDrone();
        }

        public void WinDroneRight()
        {
            this.consolDataDrone.Text += "> Right\n>";
            this.droneControl.TurnRightdDrone();
        }

        public void WinDroneBack()
        {
            this.consolDataDrone.Text += "> Back\n>";
            this.droneControl.BackDrone();
        }

        public void WinDroneHover()
        {
            this.consolDataDrone.Text += "> Hover\n>";
            this.droneControl.HoverDrone();
        }
        public void WinDroneRollLeft()
        {
            this.consolDataDrone.Text += "> Roll Left\n>";
            this.droneControl.RollLeftDrone();
        }

        public void WinDroneRollRight()
        {
            this.consolDataDrone.Text += "> Roll Right\n>";
            this.droneControl.RollRighDrone();
        }


        public void WinDroneAltiUp()
        {
            this.consolDataDrone.Text += "> Alti Up\n>";
            this.droneControl.UpAltiDrone();
        }

        public void WinDroneAltiDown()
        {
            this.consolDataDrone.Text += "> Alti Down\n>";
            this.droneControl.DownAltiDrone();
        }


        private void joystickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.joyControl.IsCreate())
            {
                try
                {
                    this.joyControl.CreateDevice();
                }
                catch (DroneException er)
                {
                    this.consolDataDrone.Text += "> " + er.Message + "\n>";
                }
            }
            /*
            JoystickDroneWin wJ = new JoystickDroneWin();
            wJ.ShowDialog();*/
        }

        private void consolDataDrone_TextChanged(object sender, EventArgs e)
        {
            this.consolDataDrone.SelectionStart = this.consolDataDrone.Text.Length; //Set the current caret position at the end
            this.consolDataDrone.ScrollToCaret(); //Now scroll it automatically
        }

        private void DumpBranch(TreeNodeCollection nodes, object o)
        {
            Type type = o.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                TreeNode node = nodes.GetOrCreate(fieldInfo.Name);
                object value = fieldInfo.GetValue(o);

                DumpValue(fieldInfo.FieldType, node, value);
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                TreeNode node = nodes.GetOrCreate(propertyInfo.Name);
                object value = propertyInfo.GetValue(o, null);

                DumpValue(propertyInfo.PropertyType, node, value);
            }
        }

        private void DumpValue(Type type, TreeNode node, object value)
        {
            if (value == null)
                node.Text = node.Name + ": null";
            else
            {
                if (type.Namespace.StartsWith("System") || type.IsEnum)
                    node.Text = node.Name + ": " + value;
                else
                    DumpBranch(node.Nodes, value);
            }
        }

        private void dPlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Win3DPlot win3D = new Win3DPlot(this.xData.ToArray(), this.yData.ToArray(), this.zData.ToArray(), this);
            win3D.Show();
        }

        private void manualCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.manualComIsShow)
            {
                this.panelManualControl.Hide();
                this.manualComIsShow = false;
                foreach (Control c in this.panelManualControl.Controls)
                {
                    c.Enabled = false;

                }
            }
            else
            {
                this.panelManualControl.Show();
                this.manualComIsShow = true;
                foreach (Control c in this.panelManualControl.Controls)
                {
                    c.Enabled = true;

                }
            }
        }

        private void butTrack_Click(object sender, EventArgs e)
        {
            this.droneControl.HoverDrone();
        }

        private void grapHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphHistory winGraph = new GraphHistory(this.yawData.ToArray(), this.pitchData.ToArray(), this.rollData.ToArray(), this);
            winGraph.ShowDialog();
        }

        private void resetTrimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.droneControl.FlatTrimeDrone();
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("ar.drone_user-guide_uk.pdf");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.droneControl.Tracking = false;
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.FullOpen = true;
            DialogResult result = colorDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                this.panelColor.BackColor = colorDialog1.Color;
                
            }
            this.droneControl.ColorToDetect = this.panelColor.BackColor;
            if (this.butTracking.Text == "Tracking ON")
            {
                this.droneControl.Tracking = true;
            }
        }

        private void picVideoImg_Click(object sender, EventArgs e)
        {

            if (this.pickColor && this.picVideoImg.BackgroundImage != null)
            {

                Point position = this.picVideoImg.PointToClient(Cursor.Position);
                try
                {
                    Bitmap img = new Bitmap(this.picVideoImg.BackgroundImage);

                    ColorDialog colorDialog1 = new ColorDialog();
                    colorDialog1.FullOpen = true;
                    colorDialog1.Color = img.GetPixel(position.X, position.Y);
                    DialogResult result = colorDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        this.panelColor.BackColor = colorDialog1.Color;

                    }
                    this.droneControl.ColorToDetect = this.panelColor.BackColor;
                }
                catch (Exception et)

                {
                    Console.WriteLine("Error : "+et.Message);
                }
                this.pickColor = false;
                this.picVideoImg.Cursor = Cursors.Default;

            }
            if (this.butTracking.Text == "Tracking ON")
            {
                this.droneControl.Tracking = true;
            }
            this.picVideoImg.Cursor = Cursors.Default;
        }

       
        private void butTracking_Click(object sender, EventArgs e)
        {
            if (this.butTracking.Text == "Tracking ON")
            {
                this.droneControl.Tracking = false;
                this.butTracking.BackColor = System.Drawing.Color.Black;
                this.butTracking.Text = "Tracking OFF";
            }
            else
            {
                this.droneControl.Tracking = true;
                this.butTracking.BackColor = System.Drawing.Color.FromArgb(47, 47, 47);
                this.butTracking.Text = "Tracking ON";
            }
        }

        private void picColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.picVideoImg.Cursor = Cursors.Cross;
            this.droneControl.Tracking = false;
            this.pickColor = true;
        }

        private void trackBarRadius_ValueChanged(object sender, EventArgs e)
        {
            this.labRad.Text = "Radius : "+this.trackBarRadius.Value.ToString();
            this.droneControl.Radius = this.trackBarRadius.Value;
        }

        private void butForward_Click(object sender, EventArgs e)
        {
            this.WinDroneForward();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            this.WinDroneBack();
        }

        private void butLeft_Click(object sender, EventArgs e)
        {
            this.WinDroneLeft();
        }

        private void butRight_Click(object sender, EventArgs e)
        {
            this.WinDroneRight();
        }

        private void butRollLeft_Click(object sender, EventArgs e)
        {
            this.WinDroneRollLeft();
        }

        private void butRollRight_Click(object sender, EventArgs e)
        {
            this.WinDroneRollRight();
        }

        private void butMid_Click(object sender, EventArgs e)
        {
            this.WinDroneHover();
        }

        private void butAltiUp_Click(object sender, EventArgs e)
        {
            this.WinDroneAltiUp();
        }

        private void butAltiDown_Click(object sender, EventArgs e)
        {
            this.WinDroneAltiDown();
        }

        private void checkHistoEqual_Click(object sender, EventArgs e)
        {
            this.droneControl.HistogramEqual = this.checkHistoEqual.Checked;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.joyControl.IsCreate())
            {
                try
                {
                    this.joyControl.CreateDevice();
                    if (this.winFullScreenDrone == null)
                    {
                        this.winFullScreenDrone = new WinFullScreen(this);
                        this.droneControl.Tracking = false;
                        this.droneControl.JoyControlOn = true;
                        this.winFullScreenDrone.Show();
                        
                    }
                }
                catch (DroneException er)
                {
                    this.consolDataDrone.Text += "> " + er.Message + "\n>";
                }
            }
            if (this.winFullScreenDrone == null)
            {
                this.winFullScreenDrone = new WinFullScreen(this);
                this.droneControl.Tracking = false;
                this.droneControl.JoyControlOn = true;
                this.winFullScreenDrone.Show();
               
            }
                 
        }

        private void calibrateJoystickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "rundll32.exe";
            process.StartInfo.Arguments = "shell32.dll,Control_RunDLL joy.cpl";
            process.Start();
        }

        private void oculusRiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.joyControl.IsCreate())
            {
                try
                {
                    this.joyControl.CreateDevice();
                    this.hdmOculus.CreateDevice();
                    if (this.winOculusDrone == null)
                    {
                        this.winOculusDrone = new OculusWin(this, this.hdmOculus);
                        this.droneControl.Tracking = false;
                        this.droneControl.JoyControlOn = true;
                        this.winOculusDrone.Show();
                    }
                }
                catch (Exception er)
                {
                    this.consolDataDrone.Text += "> " + er.Message + "\n>";
                }
            }
            if (this.winOculusDrone == null)
            {
                this.winOculusDrone = new OculusWin(this, this.hdmOculus);
                this.droneControl.Tracking = false;
                this.droneControl.JoyControlOn = true;
                this.winOculusDrone.Show();
            }
        }

        private void joystickControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form joyWinHelp = new Form();
            joyWinHelp.ShowIcon = false;           
            joyWinHelp.ShowInTaskbar = false;
            joyWinHelp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            joyWinHelp.MaximizeBox = false;
            joyWinHelp.MinimizeBox = false;
            joyWinHelp.Name = "HelpJoyControl";
            joyWinHelp.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            joyWinHelp.BackgroundImage = Properties.Resources.joyHelp;
            joyWinHelp.BackgroundImageLayout = ImageLayout.Stretch;
            joyWinHelp.Size = new Size(640, 550);
            joyWinHelp.ShowDialog();
        }

        private void howToRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form howToWin = new Form();
            howToWin.ShowIcon = false;
            howToWin.ShowInTaskbar = false;
            howToWin.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            howToWin.MaximizeBox = false;
            howToWin.MinimizeBox = false;
            howToWin.Name = "WowToRun";
            howToWin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            howToWin.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Label labTex = new Label();
            labTex.AutoSize = false;
            labTex.Size = new Size(320, 275);
            labTex.Location = new Point(0,0);
            labTex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labTex.TextAlign = ContentAlignment.TopCenter;
            labTex.ForeColor = System.Drawing.Color.Gold;
            try
            {
                System.IO.StreamReader myFile = new System.IO.StreamReader("readme.txt");
                labTex.Text = myFile.ReadToEnd();
                myFile.Close();
            }
            catch (Exception)
            {
                labTex.Text = "Mmmm... no file found (readme.txt)";
            }
            labTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
            howToWin.Controls.Add(labTex);
            howToWin.Size = new Size(640, 550);
            howToWin.ShowDialog();
        }

     

        private void ScrollBarRectRange_ValueChanged(object sender, EventArgs e)
        {
            this.droneControl.RatioRectDetecRange = this.ScrollBarRectRange.Value / 10.0;
        }

        private void hScrollAirMin_ValueChanged(object sender, EventArgs e)
        {

            this.droneControl.AirMinRangeDetect = this.hScrollAirMin.Value;
            if (this.droneControl.AirMaxRangeDetect < this.hScrollAirMin.Value)
            {
                this.droneControl.AirMinRangeDetect = this.droneControl.AirMaxRangeDetect - 1000;
            }
            this.hScrollAirMin.Value = this.droneControl.AirMinRangeDetect;
            this.labAireMin.Text = this.hScrollAirMin.Value.ToString();

            this.ovalShapAirMin.Size = new Size(Convert.ToInt32((this.droneControl.AirMinRangeDetect / 1000) * (5.4)),
               Convert.ToInt32((this.droneControl.AirMinRangeDetect / 1000) * (5.4)));

            this.ovalShapAirMin.Location = new Point((140 - this.ovalShapAirMin.Height) / 2, (140 - this.ovalShapAirMin.Width) / 2);
        }

        private void hScrollAirMax_ValueChanged(object sender, EventArgs e)
        {
            this.droneControl.AirMaxRangeDetect = this.hScrollAirMax.Value;
            if (this.droneControl.AirMinRangeDetect > this.hScrollAirMax.Value)
            {
                this.droneControl.AirMaxRangeDetect = this.droneControl.AirMinRangeDetect + 1000;
            }
            this.hScrollAirMax.Value = this.droneControl.AirMaxRangeDetect;
            this.labAireMax.Text = this.hScrollAirMax.Value.ToString(); 

            //7000 - 17000

            this.ovalShapAirMax.Size = new Size(Convert.ToInt32((this.droneControl.AirMaxRangeDetect / 1000) * (5.4)),
                Convert.ToInt32((this.droneControl.AirMaxRangeDetect / 1000) * (5.4)));

            this.ovalShapAirMax.Location = new Point((140-this.ovalShapAirMax.Height ) / 2, (140-this.ovalShapAirMax.Width) / 2);
        }
    }
}

