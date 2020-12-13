namespace FrameworklessApp
{
    public interface IHandler
    {
        public Message HandleRequest(Request request);
    }
}