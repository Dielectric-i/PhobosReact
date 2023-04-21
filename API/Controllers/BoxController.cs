using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PhobosReact.API.Contracts;
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
        public async Task<IActionResult> CreateBox(CreateBoxRequest request)
        {
            // 1. Создаем объект коробки. Если ошибка - возвращаем проблему
            ErrorOr<Box> requestToBoxResult = Box.From(request);
            if (requestToBoxResult.IsError)
            {
                return await Problem(requestToBoxResult.Errors);
            }

            var box = requestToBoxResult.Value;

            // Отправляем запрос в сервис
            ErrorOr<Created> createBoxResult = await _boxService.CreateBox(box);

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
