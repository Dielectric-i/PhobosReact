using ErrorOr;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Data.Interfaces
{
    public interface ISpaceRepository
    {
        Task<ErrorOr<Created>> CreateSpace(Space space);
        Task<ErrorOr<IEnumerable<Space>>> GetAllSpaces();
        Task<ErrorOr<Space>> GetSpace(Guid id);
    }
}
