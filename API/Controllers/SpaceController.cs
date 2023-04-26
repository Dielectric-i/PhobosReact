using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Models;
using PhobosReact.API.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhobosReact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SpaceController : ApiController
    {
        private static readonly IEnumerable<Space> _spaces = new[]
        {
            Space.Create("Garage").Value,
            Space.Create("Production").Value
        };
        private readonly ISpaceService _spaceService;

        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpace(SpaceDto request)
        {

            // Отправляем запрос в сервис
            ErrorOr<SpaceDto> createSpaceResult = await _spaceService.CreateSpace(request);

            return await createSpaceResult.MatchAsync<IActionResult>(
                   async created => Ok(created),
                   errors => Problem(errors));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpace(Guid id)
        {
            ErrorOr<SpaceDto> getSpaceResult = await _spaceService.GetSpace(id);

            return await getSpaceResult.MatchAsync<IActionResult>(
                async spaceDto => Ok(spaceDto),
                errors => Problem(errors));
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllSpaces()
        {
            //Request.Headers.Add("Content-Type", "application/json");

            ErrorOr<IEnumerable<SpaceDto>> requestAllSpacesResult = await _spaceService.GetAllSpaces();

            
            return await requestAllSpacesResult.MatchAsync<IActionResult>(
                async success => Ok(success),
                errors => Problem(errors));


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpace(int id)
        {
            return NoContent();
        }
    }
}
