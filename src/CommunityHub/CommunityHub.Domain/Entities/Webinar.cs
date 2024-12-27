using CommunityHub.Domain.Exceptions;
using CommunityHub.Domain.ValueObjects;

namespace CommunityHub.Domain.Entities
{
    public class Webinar
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public WebinarDateRange DateRange { get; private set; }
        public int TotalSeats { get; private set; }
        public int AvailableSeats { get; private set; }
        public bool IsActive { get; private set; }

        // EF Core requires a parameterless constructor for entities
        private Webinar() { }

        public Webinar(Guid id, string title, string description, WebinarDateRange dateRange, int totalSeats)
        {
            Id = id;
            Title = title;
            Description = description;
            DateRange = dateRange;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            IsActive = true;
        }

        public void ReserveSeat()
        {
            if (AvailableSeats <= 0)
                throw new WebinarNotAvailableException("No seats available for this event.");

            AvailableSeats--;
        }

        public void CancelSeatReservation()
        {
            if (AvailableSeats < TotalSeats)
                AvailableSeats++;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
