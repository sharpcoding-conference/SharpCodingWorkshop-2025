using AutoMapper;
using CommunityHub.Application.DTOs;
using CommunityHub.Application.Exceptions;
using CommunityHub.Application.Interfaces;
using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using CommunityHub.Domain.ValueObjects;

namespace CommunityHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                ?? throw new UserNotFoundException($"User with ID {userId} not found.");

            return _mapper.Map<UserDetailDto>(user);
        }

        public async Task<Guid> CreateUserAsync(UserDto userDto)
        {
            var email = new Email(userDto.Email);
            var newUser = new User(Guid.NewGuid(), userDto.Name, email);
            await _userRepository.AddAsync(newUser);
            return newUser.Id;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDto.Id)
                ?? throw new UserNotFoundException($"User with ID {userDto.Id} not found.");

            var email = new Email(userDto.Email);
            existingUser.Update(userDto.Name, email);

            await _userRepository.UpdateAsync(existingUser);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId)
                ?? throw new UserNotFoundException($"User with ID {userId} not found.");

            await _userRepository.DeleteAsync(existingUser.Id);
        }
    }
}
