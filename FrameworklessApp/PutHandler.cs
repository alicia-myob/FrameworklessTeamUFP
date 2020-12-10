using System;

namespace FrameworklessApp
{
    public class PutHandler
    {
        private string _filepath;

        public bool UpdateUserName(string id, string newName)
        {
            var list = DataController.GetData(_filepath);

            foreach (var user in list)
            {
                if (user.Id.Equals(id))
                {
                    user.Name = newName;
                    DataController.SendData(_filepath, list);
                    return true;
                }
                
            }
            
            throw new ArgumentException("User doesn't exist");
        }

        public PutHandler(string filepath)
        {
            _filepath = filepath;
        }
    }
}