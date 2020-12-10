using System;

namespace FrameworklessApp
{
    public class DeleteHandler
    {
        private string _filepath;

        public DeleteHandler(string filepath)
        {
            _filepath = filepath;
        }

        public bool DeleteUser(string id)
        {
            if (id.Equals("1"))
            {
                throw new ArgumentException("Can not delete Bob"); 
            }
            var list = DataController.GetData(_filepath);

            foreach (var user in list)
            {
                if (user.Id.Equals(id))
                {
                    list.Remove(user);
                    DataController.SendData(_filepath,list);
                    return true;
                }
                
            }
            throw new ArgumentException("User does not exist");
        }
    }
}