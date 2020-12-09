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
            var getHandler = new GetHandler();
            var exception = Assert.Throws<ArgumentException>(() => getHandler.getAllUsers("../../../../TestFrameworklessApp/UnitTests/EmptyDatabaseTest.json"));
            Assert.Equal("Database is empty", exception.Message);
        }
        
        // [Fact]
        // public void Get_All_Users_In_Database_Containing_One_User()
        // {
        //     var userList = new List<User>();
        //     userList.Add(new User("Bob", "1"));
        //     Create_Temporary_Database(userList);
        //     
        //     var getHandler = new GetHandler();
        //     
        //     var actual = getHandler.getAllUsers();
        //
        //     bool result = true;
        //
        //     if (userList.Count == actual.Count)
        //     {
        //         foreach (var user in actual)
        //         {
        //             if (user.Name != "Bob" || user.Id != "1") result = false;
        //         }
        //     }
        //     else
        //     {
        //         result = false;
        //     }
        //     
        //     Assert.True(result);
        // }
        
        // [Fact]
        // public void Get_All_Users_In_Database_Containing_Multiple_Users()
        // {
        //     var getHandler = new GetHandler();
        //     var userList = new List<User>();
        //     userList.Add(new User("Bob", "1"));
        //     userList.Add(new User("Sally", "2"));
        //
        //     var actual = getHandler.getAllUsers();
        //     bool result = true;
        //     
        //     for (int i = 0; i < actual.Count; i++)
        //     {
        //         if (actual[i].Name != userList[i].Name || actual[i].Id != userList[i].Id)
        //         {
        //             result = false;
        //         }
        //     }
        //     Assert.True(result);
        // }



        public void Create_Temporary_Database(List<User> database)
        {
            
            var users = database.Select(user =>
                new JObject(new JProperty("name", user.Name), new JProperty("id", user.Id)));
            var newDatabase = new JArray(users);
            using var streamWriter = File.CreateText(filepath);

            streamWriter.WriteLine(newDatabase);
         //   streamWriter.Close();
        }
    }
    
}