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
        public BoxService(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<ErrorOr<Created>> CreateBox(Box box)
        {

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
