using ErrorOr;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Services
{
    public interface ISpaceService
    {
        Task<ErrorOr<Created>> CreateSpace(Space space);
        Task<ErrorOr<IEnumerable<Space>>> GetAllSpaces();
        Task<ErrorOr<Space>> GetSpace(Guid id);
    }
}