using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Models
{
    public class Building:IdBase
    {
        public BuildingType BuildingType { get; set; }

        public int Level { get; set; }

        public Rectangle Location { get; set; }

        public BuildState State { get; set; }

    }

    public enum BuildingType:byte
    {
        Food = 1,

        Gold = 2,

        Iron = 3,

        Oil = 4,
    }

    public enum BuildState:byte
    {
        Gain = 5
    }
}
