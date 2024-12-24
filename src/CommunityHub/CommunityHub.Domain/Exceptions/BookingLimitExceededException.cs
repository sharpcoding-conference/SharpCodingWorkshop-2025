namespace CommunityHub.Domain.Exceptions
{
    public class BookingLimitExceededException : DomainException
    {
        public BookingLimitExceededException(string message) : base(message) { }
    }
}
