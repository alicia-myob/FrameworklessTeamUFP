using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FrameworklessApp
{
    public class GetHandler : IHandler
    {


        public List<User> getAllUsers(string filepath)
        {
            // TODO: extract this later
            
            var streamReader = new StreamReader(filepath);

            var json = streamReader.ReadToEnd();

            List<User> import = JsonConvert.DeserializeObject<List<User>>(json);

            if (import.Count == 0)
            {
                throw new ArgumentException("Database is empty");
            }
            
            return import;
        }
    }
}