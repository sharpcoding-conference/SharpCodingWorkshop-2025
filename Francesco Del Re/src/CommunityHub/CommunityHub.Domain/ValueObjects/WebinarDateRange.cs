namespace CommunityHub.Domain.ValueObjects
{
    public class WebinarDateRange
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public WebinarDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("End date must be after start date.");

            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsOngoing(DateTime currentDate) => StartDate <= currentDate && currentDate <= EndDate;
    }
}

