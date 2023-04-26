using ErrorOr;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Services
{
    public interface IBoxService
    {
        Task<ErrorOr<BoxDto>> CreateBox(CreateBoxRequest boxDto);
        Task<ErrorOr<IEnumerable<BoxDto>>> GetAllBoxes();
        Task<ErrorOr<BoxDto>> GetBox(Guid id);
    }
}