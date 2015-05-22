using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX.DirectInput;
using SlimDX;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

namespace A.R.Drone.Main
{
    class JoystickDrone
    {
        private DirectInput dinput;
        private Joystick joystick;

        private Thread threadUpdateJoy;
        private bool threadUpdateRun = false;
        private JoystickState state;
        private JoystickState stateChange;
        private MainWin win;

        public JoystickDrone(MainWin w)
        {
            this.win = w;

            this.threadUpdateJoy = new Thread(new ThreadStart(UpdateStateJoy));
            this.threadUpdateJoy.Name = "updateJoyDrone";
            this.state = new JoystickState();
            this.stateChange = new JoystickState();
        }

        public void CreateDevice()
        {
            
            this.dinput = new DirectInput();

            foreach (DeviceInstance device in this.dinput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                // create the device
                try
                {
                    this.joystick = new Joystick(this.dinput, device.InstanceGuid);
                    //joystick.SetCooperativeLevel(this, CooperativeLevel.Exclusive | CooperativeLevel.Foreground);
                    break;
                }
                catch (DirectInputException)
                {
                }
            }

            if (this.joystick == null)
            {
                throw new DroneException("Error : No Joystick detected !");
            }

            foreach (DeviceObjectInstance deviceObject in joystick.GetObjects())
            {
                if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                    this.joystick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-1000, 1000);
            }

            this.joystick.Acquire();
            this.threadUpdateRun = true;
            this.threadUpdateJoy.Start();
        }

        public bool IsCreate()
        {
            return this.joystick != null; 
        }
        public bool IsRunning()
        {
            return this.threadUpdateRun;
        }
        public void Stop()
        {
            this.threadUpdateRun = false;
            if (this.joystick != null)
            {
                this.joystick.Dispose();
            }
            if (this.dinput != null)
            {
                this.dinput.Dispose();
            }
        }
        private void UpdateStateJoy()
        {
            while (this.threadUpdateRun)
            {
                try
                {
                    if (this.joystick.Acquire().IsFailure)
                        return;

                    if (this.joystick.Poll().IsFailure)
                        return;

                    state = this.joystick.GetCurrentState();
                    if (Result.Last.IsFailure)
                        return;
                }
                catch (Exception)
                {
                    this.win.WinDroneHover();
                    this.threadUpdateRun = false;

                    return;
                }
                Thread.Sleep(50);
                if (this.threadUpdateRun)
                {
                    this.win.UpdateJoyControl(this.state);
                }
            }
        }
    }
}
