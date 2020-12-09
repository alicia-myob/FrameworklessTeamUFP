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


        public List<User> GetAllUsers()
        {
            // TODO: extract this later

            return DataController.GetData(_filepath);
        }
        


        public User GetUserById(string Id)
        {
            List<User> allUsers = GetAllUsers();
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