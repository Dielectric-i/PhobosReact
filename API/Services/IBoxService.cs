using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Services
{
    public interface IBoxService
    {
        Task<ErrorOr<Created>> CreateBox(Box box);
        Task<ErrorOr<Box>> GetBox(Guid id);
    }
}