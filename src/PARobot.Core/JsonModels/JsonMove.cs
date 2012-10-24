using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonMove
    {
        //"{\"moves\":[{\"userbuildingid\":{0},\"rectangle\":\"{1},{2};{3},{4}\"}],\"Revolves\":[{\"userbuildingid\":{0},\"showdirection\":0}]}",
        public int userbuildingid { get; set; }

        public string rectangle { get; set; }

    }
}
