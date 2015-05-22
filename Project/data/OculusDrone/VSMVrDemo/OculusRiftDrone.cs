using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RiftDotNet;

namespace OculusDrone
{
    public class OculusRiftDrone
    {
        private IHMD ihmd = null;
        private HMDManager hmdManager = null;

        public OculusRiftDrone()
        {

        }
        public static void Main()
        {
        }

        public void CreateDevice()
        {
            if (this.hmdManager == null)
            {
                this.hmdManager = new HMDManager();
            }
            if (this.ihmd == null)
            {
                try
                {
                    this.ihmd = this.hmdManager.AttachedDevice;
                    this.ihmd.IsPredictionEnabled = true;
                }
                catch (Exception)
                {
                    throw new Exception("Oculus not detected !");
                }
                
            }
            
            if (this.ihmd == null)
            {
                //return;
                throw new Exception("Oculus not detected !");
            }
        }

       
        public float[] GetOrientation()
        {
            if (this.ihmd != null)
            {
                float[] o = { this.ihmd.Orientation.W, this.ihmd.Orientation.X, this.ihmd.Orientation.Y, this.ihmd.Orientation.Z };
                return o;
            }
            float[] b = { (float)0.0, (float)0.0, (float)0.0, (float)0.0 };
            return b;

        }
        public float[] GetAcceleration()
        {
            if (this.ihmd != null)
            {
                
                float[] a = { this.ihmd.Acceleration.X, this.ihmd.Acceleration.Y, this.ihmd.Acceleration.Z };
                return a;
            }
            float[] b = { (float)0.0, (float)0.0, (float)0.0, (float)0.0 };
            return b;
        }
        public bool IsConnected()
        {
            return (this.ihmd != null);
        }
       
    }
}
