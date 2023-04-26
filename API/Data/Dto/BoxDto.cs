
using System.Text.Json.Serialization;

namespace PhobosReact.API.Data.Dto
{
    public class BoxDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? ParentBoxId { get; set; }

        public List<BoxDto> Boxes { get; set; } = new List<BoxDto>();
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();

        public Guid SpaceDtoId { get; set; }
        [JsonIgnore]
        public SpaceDto SpaceDto { get; set; } = new SpaceDto();
    }
}
