using System.Collections.Generic;
using System.Net;

namespace FrameworklessApp
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }
        public List<string> Body { get; set; }
    }
}