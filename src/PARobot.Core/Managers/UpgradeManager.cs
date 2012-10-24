using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class UpgradeManager
    {
        public static int AddExp(int exps,Point targetPoint,Item energeItem)
        {
            int count;
            int eachExp  = 5;
            if (exps % eachExp == 0) count = exps / eachExp;
            else count = exps / eachExp + 1;

            Building build = new Building
            {
                BaseId = 301,
                Location = new Rectangle
                {
                    Point = targetPoint,
                    Width = 4,
                    Length = 4
                }
            };
            int i = 0;
            for (; i < count; i++)
            {
                build.BaseId = 301;
                Result result = BuildingManager.Create(ref build);
                if (result.Flag == ResultFlag.EnergyNotEnough)
                {
                    Result energyResult = ItemManager.UseItem(energeItem);
                    if (energyResult.Flag == ResultFlag.Failed)
                    {
                        break;
                    }
                    else
                    {
                        i--; continue;
                    }
                }
                else if (result.Flag == ResultFlag.Failed)
                    break; 

                Result desResult = null;
                
                for(int j=0;j<10;j++)
                {
                    desResult = BuildingManager.Destory(build);
                    if (desResult.Flag == ResultFlag.Success) break;
                }

                if (desResult == null||desResult.Flag != ResultFlag.Success) break;
            }

            return  i * eachExp;
        }
    }
}
