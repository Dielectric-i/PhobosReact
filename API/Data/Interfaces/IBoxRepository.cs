using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Data.Interfaces
{
    public interface IBoxRepository
    {
        Task<ErrorOr<BoxDto>> CreateBox(BoxDto boxDto);
        Task<ErrorOr<BoxDto>> GetBox(Guid id);
    }
}
