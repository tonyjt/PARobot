﻿using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class MembershipManager
    {
        public static string LoginUrl { get; set; }

        public static Result Login(string email, string password)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>
                (
                    "email",
                    email
                )
            );
            postData.Add(new KeyValuePair<string, string>(
                    "password",
                    password
                )
                );

            string result = RequestManager.SendRequest(LoginUrl, postData, true);

            return ResponseManager.ProcessResponse(result);
        }

        public static Result Login()
        {
            string Email = StoreManager.Read("Email");
            string Password = StoreManager.Read("Password");

            return Login(Email, Password);
        }
    }
}
