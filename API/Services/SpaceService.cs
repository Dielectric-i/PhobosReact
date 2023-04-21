using ErrorOr;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.ServicesError;


namespace PhobosReact.API.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly ISpaceRepository _spaceRepository;
        public SpaceService(ISpaceRepository spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        public async Task<ErrorOr<Created>> CreateSpace(Space space)
        {
            ErrorOr<Created> createSpaceResult = await _spaceRepository.CreateSpace(space);

            if (createSpaceResult.IsError)
            {
                return createSpaceResult.Errors;
            }

            return Result.Created;
        }

        public async Task<ErrorOr<IEnumerable<Space>>> GetAllSpaces()
        {
            ErrorOr<IEnumerable<Space>> getAllSpacesResult = await _spaceRepository.GetAllSpaces();
            if (getAllSpacesResult.IsError)
            {
                return getAllSpacesResult.Errors;
            }

            //TODO разобраться с тем как мне нужно возвращать

            //return ErrorOrFactory.From(getAllSpacesResult.Value);  // Так можно вернуть значение используя явное преобразование
            return getAllSpacesResult;  // Можно вернуть просто значение т.к. репозиторий возвращает ErrorOr<IEnumerable<Space>>
            //return getAllSpacesResult.Value; // А так по идее должно происходить неяное приобразование, но видимо из за того что обернуто в IEnumerable - не происходит
        }

        public async Task<ErrorOr<Space>> GetSpace(Guid id)
        {

            var result = await _spaceRepository.GetSpace(id);

                if(result is Space) { return result; }

            return Errors.Space.NotFound;
        }
    }
}
