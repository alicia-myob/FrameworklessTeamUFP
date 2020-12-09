using System.Collections.Generic;
using System.Reflection;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestPostHandler
    {
        [Fact]
        public void Add_One_User_To_Database()
        {
            var postHandler = new PostHandler("../../../../TestFrameworklessApp/UnitTests/PostHandlerDatabaseTest.json");
            postHandler.AddUser("Tracy");

            var userList = new List<User>();
            
            userList.Add(new User("Bob", "1"));
            userList.Add(new User("Sally", "2"));
            userList.Add(new User("Sam", "3"));
            userList.Add(new User("Tracy", "4"));
            
            bool result = false;
            foreach (var user in userList)
            {
                if (user.Name.Equals("Tracy"))
                {
                    result = true;
                }
            }
            
            Assert.True(result);
        }
    }
}