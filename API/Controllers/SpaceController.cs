using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.Services;

namespace PhobosReact.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> CreateSpace(CreateSpaceRequest request)
        {
            // Создаем объект Space
            var requestToSpaceResult = Space.From(request);

            // Если ошибка - возвращаем проблему, если все ок - возвращаем объект типа Space
            if (requestToSpaceResult.IsError)
            {
                return await Problem(requestToSpaceResult.Errors);
            }

            var space = requestToSpaceResult.Value;

            // Отправляем запрос в сервис
            ErrorOr<Created> createSpaceResult = await _spaceService.CreateSpace(space);

           /* createSpaceResult.MatchAsync<IActionResult>(
               async created => createSpaceResult.Value,
                errors => Problem(errors));*/

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpace(Guid id)
        {
            ErrorOr<Space> getSpaceResult = await _spaceService.GetSpace(id);

            return await getSpaceResult.MatchAsync<IActionResult> (
                async space => Ok( await MapSpaceResponceAsync(space)),
                errors => Problem(errors));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSpaces()
        {
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpsertSpace(int id, UpsertSpaceRequest request)
        {
            return NoContent();
        }
        private static async Task<SpaceResponse> MapSpaceResponceAsync(Space space)
        {
            return new SpaceResponse(
                                id: space.Id,
                                name: space.Name,
                                boxes: space.Boxes,
                                items: space.Items);
        }
        private static async Task<GetAllSpacesResponce> MapGetAllSpacesResponceAsync(List<Space> spaces)
        {
            List<SpaceResponse> listSpacesResponce = new List<SpaceResponse> ();

            foreach (Space space in spaces)
            {
                listSpacesResponce.Add(await MapSpaceResponceAsync(space));
            }
            
            return new GetAllSpacesResponce(listSpacesResponce);
        }
    }
}
