using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using AR.Drone.Client;
using AR.Drone.Client.Command;
using AR.Drone.Client.Configuration;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;
using AR.Drone.Data.Navigation.Native;
using AR.Drone.Media;
using AR.Drone.Video;

using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Math.Geometry;


namespace A.R.Drone.Main
{

    class DroneControl : IObservable
    {
        private IObserver iObserver;

        private readonly VideoPacketDecoderWorker videoPacketDecoderWorker;
        private DroneClient droneClient;
        private NavigationData navigationData;
        private NavigationPacket navigationPacket;
        private PacketRecorder packetRecorderWorker = null;
        private NavdataBag navdataBag;
        private VideoFrame frame;
        private Bitmap frameBitmap;

        private int posCrossX = 0;
        private int posCrossY = 0;
        private Rectangle rectRangeDetec;
        private Rectangle rectDetected1;
        // private Rectangle rectDetected2;
        private int rectWidth = 120;
        private int rectHeight = 90;
        private double ratioRectRange = 1.0;
        private int airMaxRange = 12500;
        private int airMinRange = 9150;

        private Thread updateDataDrone;
        private Thread updateVideoDrone;
        private bool runnigUpDataDrone;
        private bool runnigUpVideoDrone;

        private AutoResetEvent waitVideo = new AutoResetEvent(false);
        private AutoResetEvent waitNavData = new AutoResetEvent(false);

        private EuclideanColorFiltering filter = new EuclideanColorFiltering();
        private BlobCounter blobCounter = new BlobCounter();
        private Color colorToDetecd = Color.Red;

        private bool histogramEqual = false;
        private bool tracking = false;
        private bool joyControlOn = false;
        private int radius = 100;


        private SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

        public DroneControl()
        {

            this.updateDataDrone = new Thread(new ThreadStart(LoopData));
            this.updateDataDrone.Name = "updateDataDrone";
            this.updateVideoDrone = new Thread(new ThreadStart(LoopVideo));
            this.updateVideoDrone.Name = "updateVideoDrone";

            blobCounter.MinWidth = 5;
            blobCounter.MaxWidth = 5;
            this.runnigUpDataDrone = true;
            this.runnigUpVideoDrone = true;

            this.videoPacketDecoderWorker = new VideoPacketDecoderWorker(AR.Drone.Video.PixelFormat.BGR24,
              true, this.OnVideoPacketDecoded);
            videoPacketDecoderWorker.Start();
            //Init Network Drone
            this.droneClient = new DroneClient("192.168.1.1");
            this.droneClient.NavigationPacketAcquired += this.OnNavigationPacketAcquired;
            this.droneClient.VideoPacketAcquired += this.OnVideoPacketAcquired;
            this.droneClient.NavigationDataAcquired += data => navigationData = data;

        }

        public Color ColorToDetect
        {
            set { this.colorToDetecd = value; }
        }

        public bool HistogramEqual
        {
            get { return this.histogramEqual; }
            set { this.histogramEqual = value; }
        }

        public int Radius
        {
            set { this.radius = value; }
        }

        public bool Tracking
        {
            get { return this.tracking; }
            set { this.tracking = value; }
        }
        public bool JoyControlOn
        {
            get { return this.joyControlOn; }
            set { this.joyControlOn = value; }
        }

        public Point PosImgXY
        {
            get { return new Point(this.posCrossX, this.posCrossY); }
        }
        public NavigationData navData
        {
            get { return this.navigationData; }
            set { this.navigationData = value; }
        }
        public NavigationPacket NavPacket
        {
            get { return this.navigationPacket; }
            set { this.navigationPacket = value; }
        }
        public NavdataBag NavDataBag()
        {

            if (this.navigationPacket.Data != null)
            {
                NavdataBagParser.TryParse(ref navigationPacket, out navdataBag);
                return navdataBag;
            }
            return navdataBag;
        }
        public int AirMaxRangeDetect
        {
            get { return this.airMaxRange; }
            set { this.airMaxRange = value; }
        }
        public int AirMinRangeDetect
        {
            get { return this.airMinRange; }
            set { this.airMinRange = value; }
        }
        public double RatioRectDetecRange
        {
            get {return this.ratioRectRange;}
            set
            {
                this.rectWidth = Convert.ToInt32(120 * value);
                this.rectHeight = Convert.ToInt32(90 * value);
                this.ratioRectRange = value;
            }
        }

        //Observable--------------------------------
        public void AddObserver(IObserver obs)
        {
            this.iObserver = obs;
        }
        public void DelObserver(IObserver obs)
        {
            this.iObserver = null;
        }
        public void UpdateObserverData()
        {

        }
        public void UpdateObserverVideo()
        {
            this.iObserver.UpdateVideo(this.VideoDrone());
        }
        public void UpdateControl()
        {
        }
        //-------------------------------------------

        public void ConnectDrone()
        {

            //videoPacketDecoderWorker.UnhandledException += UnhandledException;
            this.droneClient.Start();
           
            var settings = new Settings();
            settings.Leds.LedAnimation = new LedAnimation(LedAnimationType.BlinkOrange, 2.0f, 3);
            settings.Video.Channel = VideoChannelType.Horizontal;
            settings.Video.Codec = VideoCodecType.H264_360P_SLRS;

            this.droneClient.Send(settings);

            if (!this.updateDataDrone.IsAlive && !this.updateDataDrone.IsAlive)
            {
                this.updateDataDrone.Start();
                this.updateVideoDrone.Start();
            }

        }
        public bool CheckDroneConnect()
        {
            return this.droneClient.IsAlive;
        }

        public void DisconnectDrone()
        {
            this.droneClient.Stop();
            this.droneClient.Dispose();
        }

        public void TakeOffDrone()
        {
            this.droneClient.AckControlAndWaitForConfirmation();
            this.droneClient.Takeoff();
          
        }

        public void LandingDrone()
        {
            this.droneClient.Land();
        }

        public void FlatTrimeDrone()
        {
            this.droneClient.FlatTrim();
        }

        public void LoopData()
        {
            int comp = 0;
            while (this.runnigUpDataDrone)
            {
                waitNavData.WaitOne();
                comp += 1;
                if (comp >= 10)
                {
                    this.iObserver.UpdateData(this.navData, this.NavPacket, this.NavDataBag());
                    comp = 0;
                }
            }
        }

        public void LoopVideo()
        {
            while (this.runnigUpVideoDrone)
            {
                waitVideo.WaitOne();
                this.iObserver.UpdateVideo(this.VideoDrone());
            }
        }


        public void LandingProcessDrone()
        {
            ushort loop = 0; //Compt loop for security
            this.droneClient.Progress(FlightMode.Progressive, gaz: -0.5f);
            while (this.NavDataBag().altitude.altitude_vision > 300 && loop < 15)
            {
                Thread.Sleep(100);
                loop += 1;
            }
            this.droneClient.Progress(FlightMode.Progressive, gaz: -0.25f);
            Thread.Sleep(750);

            this.LandingDrone();
        }

        public bool CrossInRect()
        {
            return (this.posCrossX > this.rectRangeDetec.X &&
                this.posCrossX < this.rectRangeDetec.X + this.rectWidth &&
                this.posCrossY > this.rectRangeDetec.Y &&
                this.posCrossY < this.rectRangeDetec.Y + this.rectHeight);
        }

        public void SwitchCameraH(bool h) //True = Horizon -- False = Verti
        {
            var settings = new Settings();
            if (h)
            {
                settings.Video.Channel = VideoChannelType.Horizontal;
            }
            else
            {
                settings.Video.Channel = VideoChannelType.Vertical;
            }
            this.droneClient.Send(settings);
        }

        public bool ExitDrone()
        {
            this.HoverDrone();
            this.droneClient.Land();

            this.runnigUpDataDrone = false;
            this.runnigUpVideoDrone = false;

            waitNavData.Close();
            waitVideo.Close();

            this.updateDataDrone.Abort();
            this.updateVideoDrone.Abort();

            this.videoPacketDecoderWorker.Stop();
            //
            this.droneClient.Stop();
            return true;
        }

        //Control Mouvement Drone----------------------------------------------------------------------
        public void AllMouvementDrone(float yawV, float gazV, float pitchV, float rollV)
        {
            this.droneClient.Progress(FlightMode.Progressive, yaw: (yawV), gaz: (gazV), pitch: (pitchV), roll: (rollV));
        }
        public void LedBlickingDrone()
        {
            var settings = new Settings();
            settings.Leds.LedAnimation = new LedAnimation(LedAnimationType.DoubleMissile, 5.0f, 1);
            this.droneClient.Send(settings);
        }
        public void ForwardDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, pitch: -0.05f);
            Console.WriteLine("DEBUG : FlightMode.Progressive, pitch: -0.05f FORWARD");
        }
        public void ForwardDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, pitch: (-0.05f - comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, pitch: -0.05f - comDrone");
        }

        public void BackDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, pitch: 0.05f);
            Console.WriteLine("DEBUG : FlightMode.Progressive, pitch: 0.05f BACK");
        }
        public void BackDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, pitch: (0.05f + comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, pitch: 0.05f + comDrone");
        }

        public void TurnLeftdDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, yaw: 0.25f); //trop petit donc on avance
            Console.WriteLine("DEBUG : FlightMode.Progressive, yaw: 0.25f)");
        }
        public void TurnLeftdDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, yaw: (0.25f + comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, yaw:(0.25f + comDrone");
        }

        public void TurnRightdDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, yaw: -0.25f);
            Console.WriteLine("DEBUG : FlightMode.Progressive,  yaw: -0.25f");
        }
        public void TurnRightdDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, yaw: (-0.25f - comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, yaw: (-0.25f - comDrone)");
        }

        public void UpAltiDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, gaz: 0.25f);
            Console.WriteLine("DEBUG : FlightMode.Progressive,gaz: 0.25f");
        }
        public void UpAltiDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, gaz: (0.25f + comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, gaz: (0.25f + comDrone)");
        }

        public void DownAltiDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, gaz: -0.25f);
            Console.WriteLine("DEBUG : FlightMode.Progressive, gaz: -0.25f");
        }
        public void DownAltiDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, gaz: (-0.25f - comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, gaz: (-0.25f - comDrone)");
        }

        public void RollRighDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, roll: 0.05f);
            Console.WriteLine("DEBUG : FlightMode.Progressive, roll: 0.05f");
        }
        public void RollRighDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, roll: (0.05f + comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive,  roll: (0.05f + comDrone)");
        }

        public void RollLeftDrone()
        {
            this.droneClient.Progress(FlightMode.Progressive, roll: -0.05f);
            Console.WriteLine("DEBUG : FlightMode.Progressive, roll: -0.05f");
        }
        public void RollLeftDrone(float comDrone)
        {
            this.droneClient.Progress(FlightMode.Progressive, roll: (-0.05f - comDrone));
            Console.WriteLine("DEBUG : FlightMode.Progressive, roll: (-0.05f - comDrone)");
        }

        public void HoverDrone()
        {
            this.droneClient.Hover();
            Console.WriteLine("DEBUG : Hover");
        }

        public void ResetEmergencyDrone()
        {
            this.droneClient.ResetEmergency();
        }


        /// <summary>
        /// Critical control Drone 
        /// </summary>
        /// <returns></returns>
        private Bitmap VideoDrone()
        {

            if (frame == null)
            {

                if (frameBitmap != null)
                {
                    return frameBitmap;
                }
                return null;
            }
            this.rectRangeDetec = new Rectangle(new Point(this.frame.Width / 2 - (rectWidth / 2), this.frame.Height / 2 - (rectHeight / 2)),
                       new Size(rectWidth, rectHeight));
            if (frameBitmap == null)
            {
                frameBitmap = VideoHelper.CreateBitmap(ref frame);
                
            }
            else
            {
                BitmapData data = frameBitmap.LockBits(new Rectangle(0, 0, frame.Width, frame.Height),
                                    ImageLockMode.WriteOnly, frameBitmap.PixelFormat);
                Marshal.Copy(frame.Data, 0, data.Scan0, frame.Data.Length);
                frameBitmap.UnlockBits(data);
            }




            Bitmap mImage = (Bitmap)this.frameBitmap.Clone();

            //Filtre AForge : http://www.aforgenet.com/framework/docs/html/63a5a088-1a4e-9e04-9c78-2997b69cb88a.htm
            if (this.histogramEqual)
            {
                HistogramEqualization filtreHist = new HistogramEqualization();
                filtreHist.ApplyInPlace(mImage);
            }
            float pitchV = 0.0f;
            float gazV = 0.0f;
            float yawV = 0.0f;
            float rollV = 0.0f;
            if (!this.joyControlOn)
            {
                //Red----------
                //filter.CenterColor = new AForge.Imaging.RGB(sMin, 0, 0); ;
                filter.CenterColor = new AForge.Imaging.RGB(this.colorToDetecd.R, this.colorToDetecd.G, this.colorToDetecd.B);

                filter.Radius = (short)this.radius;
                Bitmap objectsImage = this.frameBitmap;
                filter.ApplyInPlace(objectsImage);
                

                BitmapData objectsData = objectsImage.LockBits(new Rectangle(0, 0, mImage.Width, mImage.Height),
                ImageLockMode.ReadOnly, mImage.PixelFormat);
                UnmanagedImage grayImage = Grayscale.CommonAlgorithms.BT709.Apply(new UnmanagedImage(objectsData));
                objectsImage.UnlockBits(objectsData);

                blobCounter.ProcessImage(grayImage);

                Rectangle[] rects = blobCounter.GetObjectsRectangles();
                /* bool [] bb = new bool[rects.Length];
            
                 for (int i =0; i< bb.Length; i++){
                     bb[i] = false;
                 }*/
               
                if (rects.Length >= 1)//rects.Length > 0 &&
                {

                    Size recMax1 = rects[0].Size;
                    this.rectDetected1 = rects[0];
                    int j = 0;
                    foreach (Rectangle re in rects)
                    {
                        if (recMax1.Height <= re.Size.Height && recMax1.Width <= re.Size.Width)
                        {
                            recMax1 = re.Size;
                            this.rectDetected1 = re;
                            //bb[j] = true;
                        }
                        j += 1;
                        /*
                        Graphics t = Graphics.FromImage(mImage);
                        using (Pen pen = new Pen(Color.FromArgb(160, 255, 160), 3))
                        {
                            t.DrawRectangle(pen, re);
                       
                        }
                        t.Dispose();
                       */
                    }

                    /*
                    Size recMax2 = rects[0].Size;
                    this.rectDetected2 = rects[0];
                    int k = 0;
                    foreach (Rectangle re in rects)
                    {
                        if (bb[k] != true &&
                            recMax2.Height <= re.Size.Height && recMax2.Width <= re.Size.Width &&
                            Math.Sqrt(Math.Pow(((this.rectDetected2.X + this.rectDetected2.Width / 2) - (this.rectDetected1.X + this.rectDetected1.Width / 2)), 2) +
                         Math.Pow(((this.rectDetected2.Y + this.rectDetected2.Height / 2) - (this.rectDetected1.Y + this.rectDetected1.Height / 2)), 2)) > 20)
                        {
                            recMax2 = re.Size;
                            this.rectDetected2 = re;
                        }
                        k += 1;
                    }

                
                    this.posCrossX = ((this.rectDetected1.X + this.rectDetected1.Width / 2)+(this.rectDetected2.X + this.rectDetected2.Width / 2)) / 2;
                    this.posCrossY = ((this.rectDetected1.Y + this.rectDetected1.Height / 2) + (this.rectDetected2.Y + this.rectDetected2.Height / 2)) / 2;


                    double distBetweenRect = Math.Sqrt(Math.Pow(((this.rectDetected2.X + this.rectDetected2.Width / 2)-(this.rectDetected1.X + this.rectDetected1.Width / 2)),2) + 
                         Math.Pow(((this.rectDetected2.Y + this.rectDetected2.Height / 2)-(this.rectDetected1.Y + this.rectDetected1.Height / 2)),2) );
                    */

                    this.posCrossX = (this.rectDetected1.X + (this.rectDetected1.Width / 2));
                    this.posCrossY = (this.rectDetected1.Y + (this.rectDetected1.Height / 2));

                    Graphics g = Graphics.FromImage(mImage);

                    using (Pen pen = new Pen(Color.FromArgb(0, 128, 255), 2))
                    {
                        g.DrawRectangle(pen, this.rectDetected1);
                        //g.DrawRectangle(pen, this.rectDetected2);

                        g.DrawRectangle(Pens.Beige, this.rectRangeDetec);
                        g.DrawLine(pen, new Point(this.posCrossX, this.posCrossY + 10), new Point(this.posCrossX, this.posCrossY - 10));
                        g.DrawLine(pen, new Point(this.posCrossX - 10, this.posCrossY), new Point(this.posCrossX + 10, this.posCrossY));
                        g.DrawLine(Pens.Green, this.posCrossX, this.posCrossY, (this.rectRangeDetec.X + (this.rectRangeDetec.Width / 2)), (this.rectRangeDetec.Y + (this.rectRangeDetec.Height / 2)));
                    }
                    g.Dispose();

                    int airDetected = this.rectDetected1.Height * this.rectDetected1.Width;
                    //Code for control Tracking
                   
                    // Console.WriteLine("Dist : " +( this.rectDetected1.Height * this.rectDetected1.Width));
                    if (airDetected > 3500 && this.tracking)
                    {
                        //Left Right Yaw
                        if (this.posCrossX < this.rectRangeDetec.X)
                        {
                            yawV = -(0.2f + ((this.rectRangeDetec.X - this.posCrossX) * 3.0f) / 1000.0f);
                            //this.TurnRightdDrone();
                        }
                        else if (this.posCrossX > (this.rectRangeDetec.X + this.rectWidth))
                        {
                            yawV = -(0.2f + (((this.rectRangeDetec.X + this.rectWidth) - this.posCrossX) * 3.0f) / 1000.0f);
                            //this.TurnLeftdDrone();
                        }


                        //Up Down (Gaz)
                        if (this.posCrossY < this.rectRangeDetec.Y)
                        {
                            gazV = ((this.rectRangeDetec.Y - this.posCrossY) * 2.8f) / 1000.0f;
                            //this.UpAltiDrone((float)0.2);
                        }
                        if (this.posCrossY > this.rectRangeDetec.Y + this.rectHeight)
                        {
                            gazV = (((this.rectRangeDetec.Y + this.rectHeight) - this.posCrossY) * 2.8f) / 1000.0f;
                            //this.DownAltiDrone((float)0.2);
                        }

                        //Forawr Back
                        /*
                        if (distBetweenRect > 150)
                        {
                            pitchV = (float)((distBetweenRect - 150) * 0.2f) / 100.0f;   
                        }
                        if (distBetweenRect < 80)
                        {
                            pitchV = (float)((distBetweenRect - 80) * 0.2f) / 100.0f;
                        }
                        if (pitchV > 0.1f || pitchV < -0.1f)
                        {
                            pitchV = 0.0f;
                        }*/
                        //OLD CODE F-B

                        if (airDetected > this.airMaxRange)
                        {
                            pitchV = (((airDetected) - this.airMaxRange) * 0.22f) / 100000.0f;
                            //this.BackDrone();
                        }
                        if (airDetected < this.airMinRange)
                        {
                            pitchV = (((airDetected) - this.airMinRange) * 0.16f) / 10000.0f;
                            //this.ForwardDrone();
                        }
                        if (pitchV > 1.0f || pitchV < -1.0f)
                        {
                            pitchV = 0.0f;
                        }

                        //pitchV = 0.0f;
                        //gazV = 0.0f;
                        Console.WriteLine("ECHO : pitchV : {0} -  yawV : {1} -  gazV : {2} - roll : {3} -- {4}", pitchV, yawV, gazV, rollV, this.rectDetected1.Height * this.rectDetected1.Width);
                        this.iObserver.UpdateControl(pitchV, yawV, gazV, rollV, airDetected);
                        this.droneClient.Progress(FlightMode.Progressive, yaw: (yawV), gaz: (gazV), pitch: (pitchV));
                    }
                    else
                    {
                        //Console.WriteLine("ECHO : pitchV : {0} -  yawV : {1} -  gazV : {2} - roll : {3}", pitchV, yawV, gazV, rollV);
                        this.iObserver.UpdateControl(pitchV, yawV, gazV, rollV, airDetected);
                        this.droneClient.Progress(FlightMode.Progressive, yaw: (yawV));
                    }
                }
                
            }
            else
            {
                this.iObserver.UpdateControl(pitchV, yawV, gazV, rollV,0);
                //this.droneClient.Progress(FlightMode.Progressive, yaw: (yawV));
            }
            return (mImage);
        }


        private void OnVideoPacketDecoded(VideoFrame frame)
        {
            this.frame = frame;
            waitVideo.Set();
        }
        private void OnNavigationPacketAcquired(NavigationPacket packet)
        {
            if (packetRecorderWorker != null && packetRecorderWorker.IsAlive)
                packetRecorderWorker.EnqueuePacket(packet);

            navigationPacket = packet;
            waitNavData.Set();

        }
        private void OnVideoPacketAcquired(VideoPacket packet)
        {
            if (packetRecorderWorker != null && packetRecorderWorker.IsAlive)
                packetRecorderWorker.EnqueuePacket(packet);
            if (videoPacketDecoderWorker.IsAlive)
                videoPacketDecoderWorker.EnqueuePacket(packet);
        }


        //OLD CODE////////////////////////////////////////////////////////////////////
        private void DrawCross()
        {
            Graphics g = Graphics.FromImage(this.frameBitmap);
            g.DrawLine(Pens.Red, new Point(this.posCrossX, this.posCrossY + 10), new Point(this.posCrossX, this.posCrossY - 10));
            g.DrawLine(Pens.Red, new Point(this.posCrossX - 10, this.posCrossY), new Point(this.posCrossX + 10, this.posCrossY));
        }

        private void DrawRectangle(int width, int height)
        {
            Graphics g = Graphics.FromImage(this.frameBitmap);
            g.DrawRectangle(new Pen(Color.FromArgb(0, 255, 0), 1),
                   this.rectRangeDetec);
        }

        private double DiagonalRect(int h, int w)
        {
            return (Math.Sqrt((h * h) + (w * w)));
        }

        private bool RectProximitie(Rectangle rect1, Rectangle rect2)
        {
            return ((rect1.X + rect1.Width / 2) + 10 > (rect2.X + rect2.Width / 2) ||
                (rect1.Y + rect1.Height / 2) + 10 > (rect2.Y + rect2.Height / 2) ||
                (rect1.X + rect1.Width / 2) - 10 < (rect2.X + rect2.Width / 2) ||
                (rect1.Y + rect1.Height / 2) - 10 < (rect2.Y + rect2.Height / 2));
        }
    }
}
