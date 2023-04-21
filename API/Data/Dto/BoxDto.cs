using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Data.Dto
{
    public class BoxDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? ParentBoxId { get; set; }

        public List<BoxDto> Boxes { get; set; }
        public List<ItemDto> Items { get; set; }

        public Guid SpaceId { get; set; }
    }
}
