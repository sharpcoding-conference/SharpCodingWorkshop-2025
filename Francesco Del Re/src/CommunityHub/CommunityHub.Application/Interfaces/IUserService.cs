using CommunityHub.Application.DTOs;

namespace CommunityHub.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserByIdAsync(Guid userId);
        Task<Guid> CreateUserAsync(UserDto userDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid userId);
    }
}
