using AutoMapper;
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
        private readonly IMapper _mapper;

        public WebinarController(IWebinarService webinarService, IMapper mapper)
        {
            _webinarService = webinarService;
            _mapper = mapper;
        }

        // GET: api/Webinars
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<WebinarDto>>> GetAllWebinarsAsync()
        {
            var webinars = await _webinarService.GetAllWebinarsAsync();
            return Ok(webinars);
        }

        // GET: api/Webinar/{id}
        [HttpGet("{id}")]
        [ActionName("GetWebinarByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<WebinarDetailDto>> GetWebinarByIdAsync(Guid id)
        {
            var webinar = await _webinarService.GetWebinarByIdAsync(id);
            if (webinar == null)
            {
                return NotFound();
            }
            return Ok(webinar);
        }

        // POST: api/Webinar
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<WebinarDto>> CreateWebinarAsync([FromBody] WebinarDto webinarDto)
        {
            var webinarId = await _webinarService.CreateWebinarAsync(webinarDto);
            return CreatedAtAction(nameof(GetWebinarByIdAsync), new { id = webinarId }, webinarId);
        }

        // PUT: api/Webinar
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateWebinarAsync([FromBody] WebinarDto webinarDto)
        {
            await _webinarService.UpdateWebinarAsync(webinarDto);
            return NoContent();
        }

        // DELETE: api/Webinar/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteWebinarAsync(Guid id)
        {
            await _webinarService.DeleteWebinarAsync(id);
            return NoContent();
        }
    }
}