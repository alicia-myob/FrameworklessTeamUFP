using System;
using System.Collections.Generic;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestGetHandler
    {
        [Fact]
        public void Get_All_Users_In_Database()
        {
            var getHandler = new GetHandler();
            var userList = new List<User>();
            userList.Add(new User("Bob", "1"));

            var actual = getHandler.getAllUsers();

            bool result = true;

            if (userList.Count == actual.Count)
            {
                foreach (var user in userList)
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
    }
    
}