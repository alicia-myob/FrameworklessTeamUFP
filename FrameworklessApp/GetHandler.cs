using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
        

        public List<User> GetUserById(string Id)
        {
            List<User> allUsers = GetAllUsers();
            var singleUser = new List<User>();
            
            foreach (var user in allUsers)
            {
                if (user.Id == Id)
                {
                    singleUser.Add(user);
                    return singleUser;
                }
            } 
            
            throw new ArgumentException("User does not exist");
        }

        public Message HandleRequest(Request request)
        {
            var message = new Message {MethodType = MethodType.Get};

            if (request.Path.Equals("//") || request.Path.Equals("//users//"))
            {
                message.List = GetAllUsers();    
            }
            else if (request.Path.Length > 7)
            {
                var id = request.Path.Substring(7);
                message.List = GetUserById(id);
            }

            return message;
        }
    }
}