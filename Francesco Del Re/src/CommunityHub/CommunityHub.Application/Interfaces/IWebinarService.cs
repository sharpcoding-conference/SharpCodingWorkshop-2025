using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    public interface IWebinarService
    {
        Task<IEnumerable<WebinarDto>> GetAllWebinarsAsync();
        Task<WebinarDetailDto> GetWebinarByIdAsync(Guid webinarId);
        Task<Guid> CreateWebinarAsync(WebinarDto webinarDto);
        Task UpdateWebinarAsync(WebinarDto webinarDto);
        Task DeleteWebinarAsync(Guid webinarId);
    }
}
