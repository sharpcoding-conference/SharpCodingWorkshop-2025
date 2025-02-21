using AutoMapper;
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
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public WebinarService(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WebinarDto>> GetAllWebinarsAsync()
        {
            var webinars = await _webinarRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WebinarDto>>(webinars);
        }

        public async Task<WebinarDetailDto> GetWebinarByIdAsync(Guid webinarId)
        {
            var webinar = await _webinarRepository.GetByIdAsync(webinarId)
                ?? throw new WebinarNotFoundException($"Webinar with ID {webinarId} not found.");

            return _mapper.Map<WebinarDetailDto>(webinar);
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
