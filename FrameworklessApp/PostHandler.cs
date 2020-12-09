using System;
using System.Collections.Generic;

namespace FrameworklessApp
{
    public class PostHandler : IHandler
    {
        private string _filepath;
        
        public PostHandler(string filepath)
        {
            _filepath = filepath;
        }
        
        public void AddUser(string userName)
        {
            var list = DataController.GetData(_filepath);

            if (CheckIfUserExists(userName, list))
            {
                var newId = Convert.ToInt32(list[list.Count - 1].Id) + 1;
            
                list.Add(new  User(userName, newId.ToString()));
                DataController.SendData(_filepath, list);
            }
            else
            {
                throw new ArgumentException("User already exists");
            }
        }

        private bool CheckIfUserExists(string userName, List<User> list)
        {
            foreach (var user in list)
            {
                if (user.Name.Equals(userName)) return false;
            }

            return true;
        }
    }
}