using ErrorOr;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Data.Models;
using PhobosReact.API.Data.Repositories;

namespace PhobosReact.API.Services
{
    public class BoxService : IBoxService
    {
        private readonly IBoxRepository _boxRepository;
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMappingService _mappingService;
        public BoxService(IBoxRepository boxRepository,
                          IMappingService mappingService,
                          ISpaceRepository spaceRepository)
        {
            _boxRepository = boxRepository;
            _mappingService = mappingService;
            _spaceRepository = spaceRepository;
        }

        public async Task<ErrorOr<BoxDto>> CreateBox(CreateBoxRequest request)
        {
            // Общий список ошибок метода
           var errors = new List<Error>();

            // 1. Создаем Box из CreateBoxRequest. В модели Box происходит валидация
            ErrorOr<Box> resultFtomDto = _mappingService.BoxFromCreateBoxRequest(request);

            if (resultFtomDto.IsError)
            {
                errors.AddRange(resultFtomDto.Errors);
            }

            var box = resultFtomDto.Value;

            //----------------------------------
            // Здесь бизнес логика  будет
            //----------------------------------

            // 2. Box to Dto
            ErrorOr<BoxDto> resultToDto =await _mappingService.ToDto(box);

            if (resultToDto.IsError)
            {
                errors.AddRange(resultToDto.Errors);
            }

            var boxDto = resultToDto.Value;

            // 3. Заполняем поле SpaceDto и передаем в репозиторий

            ErrorOr<SpaceDto> getSpaceDtoResult = await _spaceRepository.GetSpace(box.SpaceId);
            if (getSpaceDtoResult.IsError)
            {
                errors.AddRange(getSpaceDtoResult.Errors);
            }
            boxDto.SpaceDto = getSpaceDtoResult.Value;


            ErrorOr<BoxDto> createBoxResult = await _boxRepository.CreateBox(boxDto);

            if (createBoxResult.IsError)
            {
                errors.AddRange(createBoxResult.Errors);
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            return createBoxResult.Value;

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