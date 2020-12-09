using System.Collections.Generic;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestDataController
    {
        [Fact]
        public void Get_All_Data()
        {
            var allUsers = DataController.GetData("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var list = new List<User>();
            list.Add(new User("Bob", "1"));
            list.Add(new User("Sally", "2"));
            list.Add(new User("Sam", "3"));
            int count = 0;
            if (list.Count == allUsers.Count)
            {
                for (int i = 0; i < allUsers.Count; i++)
                {
                    if ((list[i].Name.Equals(allUsers[i].Name) && list[i].Id.Equals(allUsers[i].Id)))
                    {
                        count++;
                    }
                }
            }
            Assert.Equal(list.Count, count);
        }

        [Fact]
        public void Write_List_To_Database()
        {
            var list = new List<User>();
            list.Add(new User("Bob", "1"));
            list.Add(new User("Sally", "2"));
            list.Add(new User("Sam", "3"));
            list.Add(new User("Tracy", "4"));
            DataController.SendData("../../../../TestFrameworklessApp/UnitTests/DataControllerDatabase.json", list);
            var allUsers =
                DataController.GetData("../../../../TestFrameworklessApp/UnitTests/DataControllerDatabase.json");
            int count = 0;
            if (list.Count == allUsers.Count)
            {
                for (int i = 0; i < allUsers.Count; i++)
                {
                    if ((list[i].Name.Equals(allUsers[i].Name) && list[i].Id.Equals(allUsers[i].Id)))
                    {
                        count++;
                    }
                }
            }
            Assert.Equal(list.Count, count);
        }
    }
}