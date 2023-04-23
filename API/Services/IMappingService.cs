using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Services
{
    public interface IMappingService
    {
        ErrorOr<Box> FromDto(BoxDto boxDto);
        ErrorOr<BoxDto> ToDto(Box box);
    }
}
