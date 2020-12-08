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
            userList.Add(new User("Bob", 1));
            var actual = getHandler.getAllUsers();
            Assert.Equal("Bob", actual);
        }
    }
    
}