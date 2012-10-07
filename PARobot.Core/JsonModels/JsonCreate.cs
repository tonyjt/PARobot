using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonCreate
    {
        //plan={"creates":[{"buildingid":301,"rectangle":"36,24;4,4","showdirection":0}]}
        public int buildingid { get; set; }

        public string rectangle { get; set; }

        public int showdirection { get; set; }
    }
}
