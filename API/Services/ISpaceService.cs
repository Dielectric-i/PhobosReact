using ErrorOr;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Services
{
    public interface ISpaceService
    {
        Task<ErrorOr<SpaceDto>> CreateSpace(SpaceDto space);
        Task<ErrorOr<IEnumerable<SpaceDto>>> GetAllSpaces();
        Task<ErrorOr<SpaceDto>> GetSpace(Guid id);
    }
}