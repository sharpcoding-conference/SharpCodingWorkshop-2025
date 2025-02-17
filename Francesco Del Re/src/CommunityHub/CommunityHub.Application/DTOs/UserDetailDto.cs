namespace CommunityHub.Application.DTOs
{
    public class UserDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<BookingDto> Bookings { get; set; } = [];
    }
}
