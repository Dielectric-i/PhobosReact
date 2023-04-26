using ErrorOr;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Models;

namespace PhobosReact.API.Services
{
    public interface IMappingService
    {
        ErrorOr<Box> FromDto(BoxDto boxDto);
        Task<ErrorOr<BoxDto>> ToDto(Box box);
        ErrorOr<Space> FromDto(SpaceDto spaceDto);
        Task<ErrorOr<SpaceDto>> ToDto(Space space);
        ErrorOr<Box> BoxFromCreateBoxRequest(CreateBoxRequest request);
    }
}
