namespace CommunityHub.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; private set; }
        public Guid WebinarId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime BookingDate { get; private set; }

        // EF Core requires a parameterless constructor for entities
        private Booking() { }

        public Booking(Guid id, Guid webinarId, Guid userId)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id cannot be empty", nameof(id));
            if (webinarId == Guid.Empty) throw new ArgumentException("WebinarId cannot be empty", nameof(webinarId));
            if (userId == Guid.Empty) throw new ArgumentException("UserId cannot be empty", nameof(userId));

            Id = id;
            WebinarId = webinarId;
            UserId = userId;
            BookingDate = DateTime.UtcNow;
        }

        public void UpdateDetails(Guid webinarId, Guid userId, DateTime bookingDate)
        {
            if (webinarId == Guid.Empty) throw new ArgumentException("WebinarId cannot be empty", nameof(webinarId));
            if (userId == Guid.Empty) throw new ArgumentException("UserId cannot be empty", nameof(userId));

            WebinarId = webinarId;
            UserId = userId;
            BookingDate = bookingDate;
        }
    }
}

