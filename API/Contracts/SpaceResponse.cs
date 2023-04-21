using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Contracts
{
    public record SpaceResponse(
                     Guid id,
                     string name,
                     List<Box> boxes,
                     List<Item> items
    
        );
}
