namespace FrameworklessApp
{
    public class Request
    {
        public string Method { get; }
        public string Path { get; }
        public string Body { get; }
        public string Host { get;}
        
        public Request(string method, string path, string body, string host)
        {
            Method = method;
            Path = path;
            Body = body;
            Host = host;
        }
    }
}