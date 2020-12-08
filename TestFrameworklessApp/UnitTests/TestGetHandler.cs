using System;
using System.Collections.Generic;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestGetHandler
    {
        [Fact]
        public void Get_All_Users_In_Database_Containing_One_User()
        {
            var getHandler = new GetHandler();
            var userList = new List<User>();
            userList.Add(new User("Bob", "1"));

            var actual = getHandler.getAllUsers();

            bool result = true;

            if (userList.Count == actual.Count)
            {
                foreach (var user in actual)
                {
                    if (user.Name != "Bob") result = false;
                    if (user.Id != "1") result = false;
                }
            }
            else
            {
                result = false;
            }
            
            Assert.True(result);
        }

        [Fact]
        public void Get_All_Users_In_Database_Containing_Multiple_Users()
        {
            var getHandler = new GetHandler();
            var userList = new List<User>();
            userList.Add(new User("Bob", "1"));
            userList.Add(new User("Sally", "2"));
        
            var actual = getHandler.getAllUsers();
            bool result = true;
            
            for (int i = 0; i < actual.Count; i++)
            {
                if (actual[i].Name != userList[i].Name || actual[i].Id != userList[i].Id)
                {
                    result = false;
                }
            }
            Assert.True(result);
        }
    }
    
}