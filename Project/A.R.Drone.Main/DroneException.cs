using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A.R.Drone.Main
{
    class DroneException : Exception
    {
        public DroneException()
        {
        }
        public DroneException(string message)
            : base(message)
        {
        }
        public DroneException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string Message
        {
            get
            {
                return base.Message;
            }
        }
    }
}
