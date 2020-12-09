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

        private string _filepath = "";
        public GetHandler(string filepath)
        {
            _filepath = filepath;
        }


        public List<User> getAllUsers()
        {
            // TODO: extract this later
            
            var streamReader = new StreamReader(_filepath);

            var json = streamReader.ReadToEnd();

            List<User> import = JsonConvert.DeserializeObject<List<User>>(json);

            if (import.Count == 0)
            {
                throw new ArgumentException("Database is empty");
            }
            
            return import;
        }


        public User getUserById(string Id)
        {
            List<User> allUsers = getAllUsers();
            foreach (var user in allUsers)
            {
                if (user.Id == Id)
                {
                    return user;
                }
            } 
            
            throw new ArgumentException("User does not exist");
        }
    }
}