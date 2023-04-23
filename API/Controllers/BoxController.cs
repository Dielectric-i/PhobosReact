using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.Services;


namespace PhobosReact.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BoxController : ApiController
    {
        private readonly IBoxService _boxService;

        public BoxController(IBoxService boxService)
        {
            _boxService = boxService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBox(BoxDto boxDto)
        {
           
            // Отправляем запрос в сервис
            ErrorOr<BoxDto> createBoxResult = await _boxService.CreateBox(boxDto);

            return await createBoxResult.MatchAsync<IActionResult>(
                async created => Ok(createBoxResult.Value),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBox(Guid id)
        {
            ErrorOr<BoxDto> getBoxResult = await _boxService.GetBox(id);

            return await getBoxResult.MatchAsync<IActionResult>(
                async boxDto => Ok(getBoxResult.Value),
                errors => Problem(errors));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBoxes()
        {
            ErrorOr<IEnumerable<BoxDto>> getAllBoxesResult = await _boxService.GetAllBoxes();

            return await getAllBoxesResult.MatchAsync<IActionResult>(
                async boxesDto => Ok(getAllBoxesResult.Value),
                errors => Problem(errors));
        }
    }
}