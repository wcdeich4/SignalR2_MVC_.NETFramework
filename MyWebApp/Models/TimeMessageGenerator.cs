using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace MyWebApp.Models
{
    public class TimeMessageGenerator
    {
        public void run()
        {
            DateTime stopTime = DateTime.Now.AddDays(1);
            while (DateTime.Now < stopTime)
            {
                Thread.Sleep(5000);
                MySignalRHub.ServerToFrontend("TimeMessageGeneratore", "Server Local Time is: " + DateTime.Now.ToLongDateString());
            }
        }
    }
}