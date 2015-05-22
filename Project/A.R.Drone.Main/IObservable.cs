using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR.Drone.Data.Navigation;
using AR.Drone.Data;
using AR.Drone.Data.Navigation.Native;

namespace A.R.Drone.Main
{
    interface IObservable
    {
        void AddObserver(IObserver obs);
        void DelObserver(IObserver obs);
        void UpdateObserverData();
        void UpdateObserverVideo();
        void UpdateControl();
    }
}
