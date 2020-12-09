using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FrameworklessApp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestGetHandler
    {
        string filepath = "../../../../FrameworklessApp/database.json";
        
        [Fact]
        public void Check_If_Database_Is_Empty_Return_Error()
        {
            var getHandler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/EmptyDatabaseTest.json");
            var exception = Assert.Throws<ArgumentException>(() => getHandler.getAllUsers());
            Assert.Equal("Database is empty", exception.Message);
        }
        
        [Fact]
        public void Get_All_Users_In_Database_Containing_One_User()
        {
            var userList = new List<User>();
            userList.Add(new User("Bob", "1"));

            var getHandler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/SingleUserDatabaseTest.json");
            
            var actual = getHandler.getAllUsers();
        
            bool result = true;
        
            if (userList.Count == actual.Count)
            {
                foreach (var user in actual)
                {
                    if (user.Name != "Bob" || user.Id != "1") result = false;
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
            var getHandler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var userList = new List<User>();
            userList.Add(new User("Bob", "1"));
            userList.Add(new User("Sally", "2"));
            userList.Add(new User("Sam", "3"));
            
            var actual = getHandler.getAllUsers();
            bool result = true;

            if (actual.Count == userList.Count)
            {
                for (int i = 0; i < actual.Count; i++)
                {
                    if (actual[i].Name != userList[i].Name || actual[i].Id != userList[i].Id)
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            
            Assert.True(result);
        }

        [Fact]
        public void Search_For_User_By_Id()
        {
            var getHandler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            User actualUser = getHandler.getUserById("3");
            Assert.Equal("Sam", actualUser.Name);
        }

        [Fact]
        public void Search_For_User_By_Id_No_User_Existent()
        {
            var getHandler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var exception = Assert.Throws<ArgumentException>(() => getHandler.getUserById("4"));
            Assert.Equal("User does not exist", exception.Message);
        }

        
    }
    
}