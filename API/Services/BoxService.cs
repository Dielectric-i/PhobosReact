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

        public async Task<ErrorOr<BoxDto>> CreateBox(BoxDto boxDtoRequest)
        {
            // Общий список ошибок метода
            List<Error> errors = new List<Error>();

            // 1. Создаем Box из Dto. В модели Box происходит валидация
            ErrorOr<Box> resultFtomDto = _mappingService.FromDto(boxDtoRequest);

            if (resultFtomDto.IsError)
            {
                errors.AddRange(resultFtomDto.Errors);
            }

            var box = resultFtomDto.Value;

            //----------------------------------
            // Здесь бизнес логика  будет
            //----------------------------------

            // 2. Box to Dto
            ErrorOr<BoxDto> resultToDto = _mappingService.ToDto(box);

            if (resultToDto.IsError)
            {
                errors.AddRange(resultToDto.Errors);
            }

            var boxDto = resultToDto.Value;

            // 3. Передаем Dto в репозиторий
            ErrorOr<BoxDto> resultCreateBox = await _boxRepository.CreateBox(boxDto);

            if (resultCreateBox.IsError)
            {
                errors.AddRange(resultCreateBox.Errors);
            }

            var boxDtoResponce = resultCreateBox.Value;

            if (errors.Count > 0)
            {
                return errors;
            }

            return boxDtoResponce;

        }

        public async Task<ErrorOr<IEnumerable<BoxDto>>> GetAllBoxes()
        {
            ErrorOr<IEnumerable<BoxDto>> resultGetAllBoxes = await _boxRepository.GetAllBoxes();

            if (resultGetAllBoxes.IsError)
            {
                return resultGetAllBoxes.Errors;
            }

            return resultGetAllBoxes;
        }

        public async Task<ErrorOr<BoxDto>> GetBox(Guid id)
        {
            // 
            ErrorOr<BoxDto> resultGetBox = await _boxRepository.GetBox(id);

            if (resultGetBox.IsError)
            {
                return resultGetBox.Errors;
            }

            return resultGetBox.Value;

            // Почему так не работает?
            /*return resultGetBox.Match<BoxDto>(
                success => resultGetBox.Value,
                error => resultGetBox.Errors);*/
        }
    }
}