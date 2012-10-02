using PARobot.Core.Helper;
using PARobot.Core.JsonModels;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class BuildingManager
    {
        public static List<Building> GetAllBuildings()
        {
            JsonAllInfo jsonInfo = LoadManager.Load();

            if (jsonInfo == null) return null;


            List<Building> buildings = new List<Building>();
            foreach (JsonBuilding jb in jsonInfo.UserBuildings)
            {
                buildings.Add(ParseBuilding(jb));
            }
            return buildings;
        }

        public static Building ParseBuilding(JsonBuilding jbuilding)
        {
            Building build = new Building
            {
                Id = jbuilding.UserBuildingId,
                Location = new Rectangle
                {
                    Point = ParsePoint(jbuilding.UserBuildingPoint),
                    Width = 3,
                    Length = 3
                },
                State = (BuildState)jbuilding.State,
                Level = jbuilding.BuildingLevel,
                Direction = BuildDirection.Normal,
                
                BuildingType = jbuilding.Seed >0? BuildingType.Food:BuildingType.Gold
            };
            return build;
        }

        public static Point ParsePoint(string strPoint)
        {
            if (string.IsNullOrEmpty(strPoint)) return null;

            string[] strs = strPoint.Split(',');

            if (strs == null || strs.Length < 2) return null;

            return new Point
            {
                X = Convert.ToInt32(strs[0]),
                Y = Convert.ToInt32(strs[1])
            };
            
        }
    }
}
