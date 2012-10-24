using PARobot.Core.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Models
{
    public class ResultCreateBuilding:Result
    {
        public List<JsonBuilding> UserBuildings { get; set; }
    }
}
