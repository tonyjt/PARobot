using PARobot.Core.Helper;
using PARobot.Core.JsonModels;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class GainManager
    {
        public static string MoveUrl { get; set; }

        public static Point BowlPoint { get; set; }

        public static string GainResourceUrl { get; set; }

        public static string GainGoldUrl { get; set; }

        public static bool CheckIsGainable(Building build)
        {
            return build.State == BuildState.Gain;
        }

        public static bool MoveBuilding(Building building,Point target)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string,string>>();

            
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

            
            postData.Add(new KeyValuePair<string,string>(
                "plan",
                JsonHelper.JavaScriptSerialize<JsonPlan>(plan)
            ));

            string result = RequestManager.SendRequest(MoveUrl, postData,true);

            return ResponseManager.ProcessResponse(result);

        }

        public static bool Gain(Building build)
        {
            string url = build.BuildingType == BuildingType.Gold ? GainGoldUrl : GainResourceUrl;

            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>(
                "bid",
                build.Id.ToString()
            ));

            string result = RequestManager.SendRequest(url, postData, true);

            return ResponseManager.ProcessResponse(result);
        }


        public static int GainAll(List<Building> builds)
        {
            int count = 0;
            foreach (Building build in builds)
            {
                if (!build.Gainable) continue;

                if (MoveBuilding(build, BowlPoint))
                {
                    //收割
                    if (Gain(build)) count++;

                    MoveBuilding(build, build.Location.Point);
                }
            }
            return count;
        }

    }
}
