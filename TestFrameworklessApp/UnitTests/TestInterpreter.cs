using System.Net;
using FrameworklessApp;
using Xunit;


namespace TestFrameworklessApp.UnitTests
{
    public class TestInterpreter
    {
        [Fact]
        public void Interpreter_Responds_To_GET_Request()
        {
            var interpreter = new Interpreter("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var request = new Request("GET", "/users", "","" );
            var response = interpreter.RespondTo(request);
            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}