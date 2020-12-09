using System;

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
            var newList = DataController.GetData(_filepath);
            var newId = Convert.ToInt32(newList[newList.Count - 1].Id) + 1;
            
            newList.Add(new  User(userName, newId.ToString()));
            DataController.SendData(_filepath, newList);
        }
    }
}