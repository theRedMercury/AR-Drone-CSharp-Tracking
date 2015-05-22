using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AR.Drone.Infrastructure;
using A.R.Drone.Main.UIClass;
using System.Threading;

namespace A.R.Drone.Main
{
    static class Program
    {
        public static SplashScreenDrone splashDrone = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //show splash
            Thread splashThread = new Thread(new ThreadStart(
                delegate
                {
                    splashDrone = new SplashScreenDrone();
                    Application.Run(splashDrone);
                }
                ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            //Very Important for Drone Camera Video
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    string ffmpegPath = string.Format(@"../../../FFmpeg.AutoGen/FFmpeg/bin/windows/{0}", Environment.Is64BitProcess ? "x64" : "x86");
                    InteropHelper.RegisterLibrariesSearchPath(ffmpegPath);
                    break;
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                    string libraryPath = Environment.GetEnvironmentVariable(InteropHelper.LD_LIBRARY_PATH);
                    InteropHelper.RegisterLibrariesSearchPath(libraryPath);
                    break;
            }

            //run form - time taking operation
            MainWin mainForm = new MainWin();
            mainForm.Load += new EventHandler(mainForm_Load);
            
            Application.Run(mainForm);
            
        }
        //For Splash Screen
        static void mainForm_Load(object sender, EventArgs e)
        {
            //close splash
            if (splashDrone == null)
            {
                return;
            }
            splashDrone.Invoke(new Action(splashDrone.Close));
            splashDrone.Dispose();
            splashDrone = null;
        }
    }
}
