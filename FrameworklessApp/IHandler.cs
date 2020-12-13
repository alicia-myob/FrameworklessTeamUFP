namespace FrameworklessApp
{
    public interface IHandler
    {
        public MethodType HandleRequest(Request request);
    }
}