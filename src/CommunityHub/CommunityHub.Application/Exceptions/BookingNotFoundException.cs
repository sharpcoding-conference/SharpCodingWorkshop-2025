namespace CommunityHub.Application.Exceptions
{
    public class BookingNotFoundException : ApplicationException
    {
        public BookingNotFoundException(string message) : base(message) { }

        public BookingNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
