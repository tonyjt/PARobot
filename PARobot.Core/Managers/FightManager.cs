using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class FightManager
    {
        public static int AttackLevelDistance{get;set;}

        public static List<Friend> GetAttackAbleFriends(int level)
        {
            //获取我的等级
            List<Friend> friendList = FriendManager.GetAllMyFriends();

            if (friendList == null) return null;

            return friendList.FindAll(f => !f.IsProtect && !f.HasAttack && f.Level >= level - AttackLevelDistance && f.Level <= level + AttackLevelDistance);
        }

        
    }
}
