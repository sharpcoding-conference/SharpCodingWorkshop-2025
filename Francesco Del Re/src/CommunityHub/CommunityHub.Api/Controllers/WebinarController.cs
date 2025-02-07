using CommunityHub.Application.DTOs;
using CommunityHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommunityHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebinarController : ControllerBase
    {
        private readonly IWebinarService _webinarService;

        public WebinarController(IWebinarService webinarService)
        {
            _webinarService = webinarService;
        }

        // GET: api/Webinars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebinarDto>>> GetAllWebinarsAsync()
        {
            var webinars = await _webinarService.GetAllWebinarsAsync();
            return Ok(webinars);
        }

        // GET: api/Webinar/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WebinarDto>> GetWebinarByIdAsync(Guid id)
        {
            var webinarDto = await _webinarService.GetWebinarByIdAsync(id);
            if (webinarDto == null)
            {
                return NotFound();
            }
            return Ok(webinarDto);
        }

        // POST: api/Webinar
        [HttpPost]
        public async Task<ActionResult<WebinarDto>> CreateWebinarAsync([FromBody] WebinarDto eventDto)
        {
            var createdWebinarId = await _webinarService.CreateWebinarAsync(eventDto);
            return CreatedAtAction(nameof(CreateWebinarAsync), new { id = createdWebinarId });
        }

        // PUT: api/Webinar
        [HttpPut]
        public async Task<ActionResult> UpdateWebinarAsync([FromBody] WebinarDto webinarDto)
        {
            await _webinarService.UpdateWebinarAsync(webinarDto);
            return CreatedAtAction(nameof(UpdateWebinarAsync), new { webinarDto.Id });
        }

        // DELETE: api/Webinar/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWebinarAsync(Guid id)
        {
            await _webinarService.DeleteWebinarAsync(id);
            return CreatedAtAction(nameof(DeleteWebinarAsync), new { id });
        }
    }
}
