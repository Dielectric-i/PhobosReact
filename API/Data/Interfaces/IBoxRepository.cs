using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Data.Interfaces
{
    public interface IBoxRepository
    {
        Task<ErrorOr<Created>> CreateBox(Box box);
        Task<ErrorOr<Box>> GetBox(Guid id);
        Task<IEnumerable<Box>> GetBoxesInSpace(int id);
    }
}
