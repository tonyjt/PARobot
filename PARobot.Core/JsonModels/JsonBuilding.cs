using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonBuilding
    {
        public int BuildingGroupId{get;set;}
        public int BuildingId{get;set;}
        public int BuildingLevel{get;set;}
        public bool IsHaveEffect{get;set;}
        public DateTime LastDateUTC{get;set;}
        public int Seed{get;set;}
        public int SeedCount{get;set;}
        public int ShowDirection{get;set;}
        public int State{get;set;}
        public int UserBuildingId{get;set;}
        public string UserBuildingPoint { get; set; }
    }
}
