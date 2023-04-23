using ErrorOr;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Services
{
    public interface IBoxService
    {
        Task<ErrorOr<BoxDto>> CreateBox(BoxDto boxDto);
        Task<ErrorOr<IEnumerable<BoxDto>>> GetAllBoxes();
        Task<ErrorOr<BoxDto>> GetBox(Guid id);
    }
}