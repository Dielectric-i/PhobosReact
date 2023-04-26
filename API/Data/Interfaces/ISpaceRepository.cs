using ErrorOr;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Data.Interfaces
{
    public interface ISpaceRepository
    {
        Task<ErrorOr<SpaceDto>> CreateSpace(SpaceDto space);
        Task<ErrorOr<IEnumerable<SpaceDto>>> GetAllSpaces();
        Task<ErrorOr<SpaceDto>> GetSpace(Guid id);
    }
}
