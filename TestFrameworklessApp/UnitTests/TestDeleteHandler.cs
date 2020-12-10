using System;
using FrameworklessApp;
using Xunit;
using Xunit.Sdk;

namespace TestFrameworklessApp.UnitTests
{
    public class TestDeleteHandler
    {
        [Fact]
        public void Delete_A_User_From_Database()
        {
            var deleteHandler = new DeleteHandler("../../../../TestFrameworklessApp/UnitTests/DeleteUserDatabaseTest.json");
            deleteHandler.DeleteUser("3");
            var list = DataController.GetData("../../../../TestFrameworklessApp/UnitTests/DeleteUserDatabaseTest.json");
            bool result = true;
            foreach (var user in list)
            {
                if (user.Id.Equals("3"))
                {
                    result = false;
                }
            }
            list.Add(new User("Sam", "3"));
            DataController.SendData("../../../../TestFrameworklessApp/UnitTests/DeleteUserDatabaseTest.json", list);
            Assert.True(result);
        }

        [Fact]
        public void Try_To_Delete_Invalid_User()
        {
            var deleteHandler = new DeleteHandler("../../../../TestFrameworklessApp/UnitTests/DeleteUserDatabaseTest.json");
            var exception = Assert.Throws<ArgumentException>(() => deleteHandler.DeleteUser("8"));
            Assert.Equal("User does not exist", exception.Message);
        }
    }
}