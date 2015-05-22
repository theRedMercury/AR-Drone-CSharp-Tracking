using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR.Drone.Data.Navigation;
using AR.Drone.Data;
using AR.Drone.Data.Navigation.Native;
using System.Drawing;

namespace A.R.Drone.Main
{
    interface IObserver
    {
        void UpdateData(NavigationData navD, NavigationPacket navP, NavdataBag navB);
        void UpdateVideo(Bitmap img);
        void UpdateControl(float pitchV, float yawV, float gazV, float rollV, int airDetecV);
    }
}
