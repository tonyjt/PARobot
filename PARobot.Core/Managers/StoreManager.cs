using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class StoreManager
    {
        public static string FilePath { get; set; }

        private static Dictionary<string, string>  dicContents { get; set; }

        public static void Save(string key, string value)
        {
            if (dicContents == null) dicContents = new Dictionary<string, string>();

            if (!dicContents.ContainsKey(key)|| value != dicContents[key])
            {
                dicContents[key] = value;

                string[] lines = dicContents.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
                File.WriteAllLines(FilePath, lines);
            }
        }

        public static string Read(string key)
        {
            if (dicContents == null)
            {
                string[] lines = File.ReadAllLines(FilePath);
                dicContents = lines.Select(l => l.Split('=')).ToDictionary(a => a[0], a => a[1]);
            }
            return dicContents.ContainsKey(key) ? dicContents[key] : "";
        }
    }
}
