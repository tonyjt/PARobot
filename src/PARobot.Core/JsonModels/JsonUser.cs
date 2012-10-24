using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonUser
    {
        public int Energy { get; set; }// 38,
        public int GameCurrency { get; set; }// 15893,
        public int Gold { get; set; }// 275024,
        public bool IsFriend { get; set; }// false,
        public bool IsRequested { get; set; }// false,
        public DateTime LastEnergyAddDateUTC { get; set; }// /Date(1350124237597)/,
        public DateTime LastSocialPointAddDateUTC { get; set; }// /Date(1350124120847)/,
        public DateTime LastSocialPointLimitAddDateUTC { get; set; }// /Date(1350099330083)/,
        public string NickName { get; set; }// tonyjt,
        public int SocialPoint { get; set; }// 8,
        public int SocialPointLimit { get; set; }// 65,
        public int UserExperience { get; set; }// 7531,
        public int UserId { get; set; }// 10023241,
        public int UserLevel { get; set; }// 18,
        public int VipExp { get; set; }// 12652,
        public int VipLevel { get; set; }// 3
    }
}
