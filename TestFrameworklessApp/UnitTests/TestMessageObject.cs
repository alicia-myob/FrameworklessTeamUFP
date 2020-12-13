using System.Collections.Generic;
using FrameworklessApp;
using Xunit;

namespace TestFrameworklessApp.UnitTests
{
    public class TestMessageObject
    {
        [Fact]
        public void Message_Object_Should_Be_For_Get()
        {
            IHandler handler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var request = new Request("GET","","","");
            var message = handler.HandleRequest(request);

            Assert.Equal(MethodType.Get, message.MethodType);
        }

        [Fact]
        public void Message_Object_Gets_Assigned_Full_User_List_For_Get()
        {
            IHandler handler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var request = new Request("GET","","","");
            var message = handler.HandleRequest(request);
            
            var list = new List<User>();
            list.Add(new User("Bob", "1"));
            list.Add(new User("Sally", "2"));
            list.Add(new User("Sam", "3"));

            var variable = true;

            if (list.Count == message.List.Count)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i].Name != message.List[i].Name || list[i].Id != message.List[i].Id)
                    {
                        variable = false;
                    }
                }
            }
            else
            {
                variable = false;
            }

            Assert.True(variable);
        }

        [Fact]
        public void Message_Object_Gets_Assigned_Single_User_For_Get()
        {
            IHandler handler = new GetHandler("../../../../TestFrameworklessApp/UnitTests/MultipleUserDatabase.json");
            var request = new Request("GET","/users/1","","");
            var message = handler.HandleRequest(request);

            var variable = message.List.Count == 1 && message.List[0].Name == "Bob";
            
            Assert.True(variable);
        }
    }
}