using System;
using System.Collections.Generic;
using System.Net;

namespace FrameworklessApp
{
    public enum MethodType{
        Get,
        Post,
        Put,
        Delete
    }
    public class Response
    {
        public HttpStatusCode Code { get; }
        public string Path { get; }
        public string Body { get; }
        public string Host { get;}

        public MethodType MethodType { get; }
        
        public Response(HttpStatusCode code, string path, string body, string host, MethodType methodType)
        {
            Code = code;
            Path = path;
            Body = body;
            Host = host;
            MethodType = methodType;
        }
        
    }
}