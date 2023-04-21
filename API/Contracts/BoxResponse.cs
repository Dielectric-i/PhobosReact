using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Contracts
{
    public record BoxResponse(
    Guid Id,
    string Name,
    Guid? ParentBoxId,
    List<BoxDto> Boxes,
    List<ItemDto> Items,
    Guid SpaceId
    );
}
