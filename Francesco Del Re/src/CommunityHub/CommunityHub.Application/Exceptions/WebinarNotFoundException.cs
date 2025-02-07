namespace CommunityHub.Application.Exceptions
{
    public class WebinarNotFoundException : ApplicationException
    {
        public WebinarNotFoundException(string message) : base(message) { }

        public WebinarNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
