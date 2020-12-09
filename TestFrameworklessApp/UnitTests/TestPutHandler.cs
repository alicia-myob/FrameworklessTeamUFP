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
    }
}