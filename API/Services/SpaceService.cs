using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.ServicesError;


namespace PhobosReact.API.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMappingService _mappingService;
        public SpaceService(ISpaceRepository spaceRepository,
                            IMappingService mappingService)
        {
            _spaceRepository = spaceRepository;
            _mappingService = mappingService;
        }

        public async Task<ErrorOr<SpaceDto>> CreateSpace(SpaceDto request)
        {
            // Общий список ошибок метода
            var errors = new List<Error>();

            // 1. Создаем Space из Dto. В модели Space происходит валидация
            var resultFromDto = _mappingService.FromDto(request);
            if (resultFromDto.IsError)
            {
                errors.AddRange(resultFromDto.Errors);
            }

            var space = resultFromDto.Value;

            //----------------------------------
            // Здесь бизнес логика  будет
            //----------------------------------

            // 2. Space to Dto
            ErrorOr<SpaceDto> resultToDto = await _mappingService.ToDto(space);
            if (resultToDto.IsError)
            {
                errors.AddRange(resultToDto.Errors);
            }

            var spaceDto = resultToDto.Value;

            ErrorOr<SpaceDto> createSpaceResult = await _spaceRepository.CreateSpace(spaceDto);

            if (createSpaceResult.IsError)
            {
                return createSpaceResult.Errors;
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            return createSpaceResult.Value;
        }

        public async Task<ErrorOr<IEnumerable<SpaceDto>>> GetAllSpaces()
        {
            ErrorOr<IEnumerable<SpaceDto>> getAllSpacesResult = await _spaceRepository.GetAllSpaces();
            if (getAllSpacesResult.IsError)
            {
                return getAllSpacesResult.Errors;
            }

            //TODO разобраться с тем как мне нужно возвращать

            //return ErrorOrFactory.From(getAllSpacesResult.Value);  // Так можно вернуть значение используя явное преобразование
            return getAllSpacesResult;  // Можно вернуть просто значение т.к. репозиторий возвращает ErrorOr<IEnumerable<Space>>
            //return getAllSpacesResult.Value; // А так по идее должно происходить неяное приобразование, но видимо из за того что обернуто в IEnumerable - не происходит
        }

        public async Task<ErrorOr<SpaceDto>> GetSpace(Guid id)
        {
            var errors = new List<Error>();

            var getSpaceResult = await _spaceRepository.GetSpace(id);

            if (getSpaceResult.IsError)
            {
                errors.AddRange(getSpaceResult.Errors);
            }

            if (getSpaceResult.Value == null)
            {
                errors.Add(Errors.Space.NotFound);
            }

            if (errors.Count>0)
            {
                return errors;
            }
            return getSpaceResult;
        }
    }
}
