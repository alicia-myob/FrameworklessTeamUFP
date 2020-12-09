using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrameworklessApp
{
    public static class DataController
    {
        public static List<User> GetData(string filePath)
        {
            var streamReader = new StreamReader(filePath);

            var json = streamReader.ReadToEnd();

            List<User> import = JsonConvert.DeserializeObject<List<User>>(json);

            if (import.Count == 0)
            {
                throw new ArgumentException("Database is empty");
            }
            
            streamReader.Close();

            return import;
        }


        public static void SendData(string filePath, List<User> list)
        {
            var newUsers = list.Select(user => new JObject(new JProperty("name", user.Name), new JProperty("id", user.Id)));
            var newJson = new JArray(newUsers);
            using var streamWriter = File.CreateText(filePath);
            streamWriter.WriteLine(newJson);
            streamWriter.Close();
        }
    }
}