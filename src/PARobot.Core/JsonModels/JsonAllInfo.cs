using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonAllInfo
    {
        public List<JsonBuilding> UserBuildings { get; set; }

        public JsonUser User { get; set; }
    }
}
