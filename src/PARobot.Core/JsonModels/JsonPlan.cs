﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonPlan
    {
        public List<JsonMove> moves { get; set; }

       //"{\"moves\":[{\"userbuildingid\":{0},\"rectangle\":\"{1},{2};{3},{4}\"}],\"Revolves\":[{\"userbuildingid\":{0},\"showdirection\":0}]}",
        public List<JsonRevolve> revolves { get; set; }

        public List<JsonCreate> creates { get; set; }

        public List<JsonRemove> removes { get; set; }
    }
}
