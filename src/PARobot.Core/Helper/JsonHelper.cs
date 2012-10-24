using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace PARobot.Core.Helper
{
    public class JsonHelper
    {
        public static string DataContractJsonSerialize<T>(T jsonObject)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, jsonObject);
            string json = Encoding.UTF8.GetString(ms.GetBuffer());
            ms.Close();
            ms.Dispose();
            ms = null;
            return json;
        }
        public static T DataContractJsonDeserialize<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            T jto = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            ms = null;
            return jto;
        }
        public static string JavaScriptSerialize<T>(T jsonObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            serializer.Serialize(jsonObject, sb);
            return sb.ToString();
        }
        public static T JavaScriptDeserialize<T>(string json)
        {
            return (T)new JavaScriptSerializer().Deserialize<T>(json);
        }
    }
}
