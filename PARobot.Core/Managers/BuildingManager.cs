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
        public static string MoveUrl { get; set; }

        public static string CreateUrl { get; set; }

        public static string DestoryUrl { get; set; }

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

        public static Result MoveBuilding(Building building, Point target)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();


            JsonPlan plan = new JsonPlan
            {
                moves = new List<JsonMove>
                {
                    new JsonMove
                    {
                        userbuildingid = building.Id,
                        rectangle = string.Format("{0},{1};{2},{3}", target.X, target.Y, building.Location.Width, building.Location.Length)
                    }
                },
                revolves = new List<JsonRevolve>
                {
                    new JsonRevolve
                    {
                        userbuildingid = building.Id,
                        showdirection = 0
                    }
                }
            };


            postData.Add(new KeyValuePair<string, string>(
                "plan",
                JsonHelper.JavaScriptSerialize<JsonPlan>(plan)
            ));

            string result = RequestManager.SendRequest(MoveUrl, postData, true);

            return ResponseManager.ProcessResponse(result);

        }

        public static Result Create(ref Building building, Point target)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();


            JsonPlan plan = new JsonPlan
            {
                creates = new List<JsonCreate>
                {
                    new JsonCreate
                    {
                        buildingid = building.BaseId,
                        rectangle = string.Format("{0},{1};{2},{3}", target.X, target.Y, building.Location.Width, building.Location.Length)
                    }
                }
               
            };
            postData.Add(new KeyValuePair<string, string>(
                "plan",
                JsonHelper.JavaScriptSerialize<JsonPlan>(plan)
            ));
            string strResult = RequestManager.SendRequest(MoveUrl, postData, true);

            Result result = ResponseManager.ProcessResponse(strResult);


            return result;
        }

        public static Result Destory(Building building)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();


            JsonPlan plan = new JsonPlan
            {
                removes = new List<JsonRemove>
                {
                    new JsonRemove
                    {
                        userbuildingid = building.Id
                    }
                }

            };
            postData.Add(new KeyValuePair<string, string>(
                "plan",
                JsonHelper.JavaScriptSerialize<JsonPlan>(plan)
            ));

            string result = RequestManager.SendRequest(MoveUrl, postData, true);

            return ResponseManager.ProcessResponse(result);
        }
    }
}
