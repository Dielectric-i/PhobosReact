using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.ServicesError;

namespace PhobosReact.API.Services
{
    public class BoxService : IBoxService
    {
        private readonly IBoxRepository _boxRepository;
        private readonly IMappingService _mappingService;
        public BoxService(IBoxRepository boxRepository,
                          IMappingService mappingService)
        {
            _boxRepository = boxRepository;
            _mappingService = mappingService;
        }

        public async Task<ErrorOr<Box>> CreateBox(BoxDto boxDto)
        {
            // 1. Создаем объект коробки. Если ошибка - возвращаем проблему
            //TODO дополнительно обрабоатать ошибку создания здесь
            ErrorOr<Box> requestToBoxResult = MappingService.FromDto(boxDto);
            if (requestToBoxResult.IsError)
            {
                return await Problem(requestToBoxResult.Errors);
            }

            var box = requestToBoxResult.Value;

            ErrorOr<Created> createBoxResult = await _boxRepository.CreateBox(box);

            if (createBoxResult.IsError)
            {
                return createBoxResult.Errors;
            }

            return Result.Created;
        }

        public async Task<ErrorOr<Box>> GetBox(Guid id)
        {
            
            ErrorOr<Box> result = await _boxRepository.GetBox(id);

            if (result is Box) { return result; }

            return Errors.Box.NotFound;
        }
    }
}
