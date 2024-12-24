namespace CommunityHub.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public Guid WebinarId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime BookingDate { get; private set; }

        public Booking(Guid id, Guid webinarId, Guid userId)
        {
            Id = id;
            WebinarId = webinarId;
            UserId = userId;
            BookingDate = DateTime.UtcNow;
        }
    }
}

