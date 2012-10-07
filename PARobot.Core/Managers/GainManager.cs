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
        public delegate void GainDelegate(int count);

        public delegate void GainFailedMessage(string message);

        public static GainDelegate Start;

        public static GainDelegate GainComplelte;

        public static GainFailedMessage GainFailed;



        public static Point BowlPoint { get; set; }

        public static string GainResourceUrl { get; set; }

        public static string GainGoldUrl { get; set; }

        public static bool CheckIsGainable(Building build)
        {
            return build.State == BuildState.Gain;
        }

   

        public static Result Gain(Building build)
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

            List<Building> gainAblebuilds = builds.FindAll(b => b.Gainable == true);

            Start(gainAblebuilds.Count);
            
            for(int i =0;i<gainAblebuilds.Count;i++)
            {

                Building build = gainAblebuilds[i];

                if (BuildingManager.MoveBuilding(build, BowlPoint).Flag == ResultFlag.Success)
                {
                    //收割
                    if (Gain(build).Flag == ResultFlag.Success) count++;
                    int j = 0;
                    for (; j < 10; j++)
                    {
                        if (BuildingManager.MoveBuilding(build, build.Location.Point).Flag == ResultFlag.Success)
                        {
                            break;
                        }
                    }
                    if (j == 10)
                    {
                        GainFailed("建筑物卡在聚宝盆内，无法移出");
                    }
                }
                GainComplelte(i + 1);
            }
            return count;
        }

    }
}
