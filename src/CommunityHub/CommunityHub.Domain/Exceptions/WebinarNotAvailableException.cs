namespace CommunityHub.Domain.Exceptions
{
    public class WebinarNotAvailableException : DomainException
    {
        public WebinarNotAvailableException(string message) : base(message) { }
    }
}
