using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonFriend
    {
        public int UserId{get;set;}
        public string NickName{get;set;}
        public int Level{get;set;}
        public string AvatarUrl{get;set;}
        public bool Present{get;set;}
        public bool HasAttacked{get;set;}
        public bool IsProect{get;set;}
        public bool Invades { get; set; }
    }
}
