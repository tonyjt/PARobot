using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonResultCreate:JsonResult
    {
        public List<JsonUserBuilding> UserBuildings { get; set; }
    }
}
