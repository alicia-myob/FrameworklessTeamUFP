using System;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestPutHandler
    {

        [Fact]
        public void Update_Existing_User_Name_Given_Id()
        {
            var putHandler = new PutHandler("../../../../TestFrameworklessApp/UnitTests/PutHandlerDatabaseTest.json");
            
            bool result = putHandler.UpdateUserName("2", "Alicia");

            Assert.True(result);
        }

        [Fact]
        public void Update_Non_Existing_User()
        {
            var putHandler = new PutHandler("../../../../TestFrameworklessApp/UnitTests/PutHandlerDatabaseTest.json");

            var exception = Assert.Throws<ArgumentException>(() => putHandler.UpdateUserName("8", "Alex"));
            Assert.Equal("User doesn't exist", exception.Message);

        }
    }
}