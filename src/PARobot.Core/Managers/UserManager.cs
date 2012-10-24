using PARobot.Core.JsonModels;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class UserManager
    {
        public static User CurrentUser { get; set; }

        public static User GetUserInfo()
        {
            JsonAllInfo jsonInfo = LoadManager.Load();

            if (jsonInfo == null) return null;

            return ParseUserFromJson(jsonInfo.User);
        }
        public static User ParseUserFromJson(JsonUser jsonUser)
        {
            if (jsonUser == null) return null;

            User user = new User
            {
                Id = jsonUser.UserId,
                Level = jsonUser.UserLevel,
                Gold = jsonUser.Gold,
                Energy = jsonUser.Energy
            };
            return user;
        }

        public static User GetCurrentUser(bool needLogin = false)
        {
            if (needLogin||CurrentUser == null || CurrentUser.Level == 1)
            {
                if (MembershipManager.Login().Flag == ResultFlag.Success)
                {
                    CurrentUser = GetUserInfo();
                }
            }
            return CurrentUser;
        }
    }
}
