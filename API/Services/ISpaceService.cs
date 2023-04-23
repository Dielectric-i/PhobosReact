using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Services
{
    public interface ISpaceService
    {
        Task<ErrorOr<Created>> CreateSpace(Space space);
        Task<ErrorOr<IEnumerable<SpaceDto>>> GetAllSpaces();
        Task<ErrorOr<Space>> GetSpace(Guid id);
    }
}