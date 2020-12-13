using System;
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

            bool result = false;
            var actualList = DataController.GetData("../../../../TestFrameworklessApp/UnitTests/PostHandlerDatabaseTest.json");
            foreach (var user in actualList)
            {
                if (user.Name.Equals("Tracy"))
                {
                    result = true;
                    var deleteHandler = new DeleteHandler("../../../../TestFrameworklessApp/UnitTests/PostHandlerDatabaseTest.json");
                    deleteHandler.DeleteUser("4");
                }
            }
            
            Assert.True(result);
        }

        [Fact]
        public void Add_Duplicate_User_Test()
        {
            var postHandler = new PostHandler("../../../../TestFrameworklessApp/UnitTests/PostHandlerDatabaseTest.json");

            var exception = Assert.Throws<ArgumentException>(() => postHandler.AddUser("Bob"));
            Assert.Equal("User already exists", exception.Message);
        }
    }
}