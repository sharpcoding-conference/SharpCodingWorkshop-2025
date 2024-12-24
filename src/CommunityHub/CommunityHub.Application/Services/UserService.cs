using CommunityHub.Application.DTOs;
using CommunityHub.Application.Exceptions;
using CommunityHub.Application.Interfaces;
using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using CommunityHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityHub.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId)
                ?? throw new UserNotFoundException($"User with ID {userId} not found.");

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email.Value
            };
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
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email.Value
            });
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
