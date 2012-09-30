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

        public static void MoveToTreasureBowl(Building building)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string,string>>();


            Plan plan = new Plan
            {
                moves = new moves
                {
                    userbuildingid = building.Id,
                    rectangle = string.Format("{0},{1};{2},{3}", BowlPoint.X, BowlPoint.Y, building.Location.Width, building.Location.Length)
                },
                revolves = new revolves
                {
                    userbuildingid = building.Id,
                    showdirection = 0
                }
            };

            
            postData.Add(new KeyValuePair<string,string>(
                "plan",
                string.Format("{\"moves\":[{\"userbuildingid\":{0},\"rectangle\":\"{1},{2};{3},{4}\"}],\"Revolves\":[{\"userbuildingid\":{0},\"showdirection\":0}]}",
                            building.Id,BowlPoint.X,BowlPoint.Y,building.Location.Width,building.Location.Length)
            ));

            RequestManager.Post(MoveUrl, postData);
        }
    }
}
