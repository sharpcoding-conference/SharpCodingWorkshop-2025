﻿namespace CommunityHub.Application.DTOs
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid WebinarId { get; set; }
        public Guid UserId { get; set; }
        public WebinarDto? Webinar { get; set; }
        public UserDto? User { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
