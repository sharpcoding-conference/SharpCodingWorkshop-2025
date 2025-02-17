namespace CommunityHub.Application.DTOs
{
    public class CreateBookingDto
    {
        public Guid Id { get; set; }
        public Guid WebinarId { get; set; }
        public Guid UserId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
