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
            ErrorOr<Created> createBoxResult = await _boxService.CreateBox(boxDto);

            return await createBoxResult.MatchAsync<IActionResult>(
                async created => Ok(await MapBoxResponceAsync(box)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBox(Guid id)
        {
            ErrorOr<Box> getBoxResult = await _boxService.GetBox(id);

            return await getBoxResult.MatchAsync<IActionResult>(
                async box => Ok(await MapBoxResponceAsync(box)),
                errors => Problem(errors));
        }
        private static async Task<BoxResponse> MapBoxResponceAsync(Box box)
        {
            return new BoxResponse(
                                id: box.Id,
                                name: box.Name,
                                boxes: box.Boxes,
                                items: box.Items);
        }
    }
}
