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

        public BuildDirection Direction { get; set; }

        public bool Gainable
        {
            get
            {
                return State == BuildState.Gain;
            }
        }

        public int BaseId { get; set; }
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
        Not = 5,
        Gain = 0
    }

    public enum BuildDirection:byte{
        Normal = 0,
        Right = 1
    }
}
