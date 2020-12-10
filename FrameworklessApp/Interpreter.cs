using System;
using System.Net;

namespace FrameworklessApp
{
    public class Interpreter
    {
        private string _filePath;
        public Interpreter(string filePath)
        {
            _filePath = filePath;
        }

        public Response RespondTo(Request request)
        {
            IHandler handler;
            switch (request.Method)
            {
                case("GET"):
                    handler = new GetHandler(_filePath);
                    break;
                // case("POST"):
                //     handler = new PostHandler(_filePath);
                //     break;
                // case("PUT"):
                //     handler = new PutHandler(_filePath);
                //     break;
                // case("DELETE"):
                //     handler = new DeleteHandler(_filePath);
                //     break;
                
                default:
                    throw new ArgumentException("Method not valid");
            }
            
            return new Response();

        }
    }
}