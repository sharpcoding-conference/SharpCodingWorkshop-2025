using CommunityHub.Application.DTOs;
using CommunityHub.Application.Exceptions;
using CommunityHub.Application.Interfaces;
using CommunityHub.Domain.Entities;
using CommunityHub.Domain.Interfaces;
using CommunityHub.Domain.ValueObjects;

namespace CommunityHub.Application.Services
{
    public class WebinarService : IWebinarService
    {
        private readonly IRepository<Webinar> _webinarRepository;

        public WebinarService(IRepository<Webinar> webinarRepository)
        {
            _webinarRepository = webinarRepository;
        }

        public async Task<IEnumerable<WebinarDto>> GetAllWebinarsAsync()
        {
            var webinars = await _webinarRepository.GetAllAsync();
            return webinars.Select(e => new WebinarDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                StartDate = e.DateRange.StartDate,
                EndDate = e.DateRange.EndDate,
                TotalSeats = e.TotalSeats,
                AvailableSeats = e.AvailableSeats,
                IsActive = e.IsActive
            });
        }

        public async Task<WebinarDto> GetWebinarByIdAsync(Guid webinarId)
        {
            var webinarEntity = await _webinarRepository.GetByIdAsync(webinarId)
                ?? throw new WebinarNotFoundException($"Webinar with ID {webinarId} not found.");

            return new WebinarDto
            {
                Id = webinarEntity.Id,
                Title = webinarEntity.Title,
                Description = webinarEntity.Description,
                StartDate = webinarEntity.DateRange.StartDate,
                EndDate = webinarEntity.DateRange.EndDate,
                TotalSeats = webinarEntity.TotalSeats,
                AvailableSeats = webinarEntity.AvailableSeats,
                IsActive = webinarEntity.IsActive
            };
        }

        public async Task<Guid> CreateWebinarAsync(WebinarDto webinarDto)
        {
            var newWebinar = new Webinar(
                Guid.NewGuid(),
                webinarDto.Title,
                webinarDto.Description,
                new WebinarDateRange(webinarDto.StartDate, webinarDto.EndDate),
                webinarDto.TotalSeats
            );

            await _webinarRepository.AddAsync(newWebinar);
            return newWebinar.Id;
        }

        public async Task UpdateWebinarAsync(WebinarDto webinarDto)
        {
            var existingWebinar = await _webinarRepository.GetByIdAsync(webinarDto.Id)
                ?? throw new WebinarNotFoundException($"Webinar with ID {webinarDto.Id} not found.");

            existingWebinar = new Webinar(
                webinarDto.Id,
                webinarDto.Title,
                webinarDto.Description,
                new WebinarDateRange(webinarDto.StartDate, webinarDto.EndDate),
                webinarDto.TotalSeats
            );

            await _webinarRepository.UpdateAsync(existingWebinar);
        }

        public async Task DeleteWebinarAsync(Guid webinarId)
        {
            await _webinarRepository.DeleteAsync(webinarId);
        }
    }
}
