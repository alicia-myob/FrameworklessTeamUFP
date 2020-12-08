using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace FrameworklessApp
{
    public class GetHandler : IHandler
    {


        public List<User> getAllUsers()
        {
            // TODO: extract this later
            
            string filepath = "../../../../FrameworklessApp/database.json";
            var streamReader = new StreamReader(filepath);

            var json = streamReader.ReadToEnd();

            List<User> import = JsonConvert.DeserializeObject<List<User>>(json);
            
            return import;
        }
    }
}