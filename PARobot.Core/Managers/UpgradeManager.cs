using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    class UpgradeManager
    {
        public static int AddExp(int exps,Point targetPoint,Item energeItem)
        {
            int count;
            int eachExp  = 5;
            if (exps % eachExp == 0) count = exps / eachExp;
            else count = exps / eachExp + 1;

            Building build = new Building{
                BaseId = 301
            };

            for (int i = 0; i < count; i++)
            {
                Result result = BuildingManager.Create(ref build, targetPoint);
                if (result.Flag == ResultFlag.EnergyNotEnough)
                {
                    Result energyResult = ItemManager.UseItem(energeItem);
                    if (energyResult.Flag == ResultFlag.Failed)
                    {
                        return i *eachExp;
                    }
                }
                else if (result.Flag == ResultFlag.Failed)
                    return i*eachExp;

                BuildingManager.Destory(build);
            }

            return exps;
        }
    }
}
