namespace PhobosReact.API.Data.Dto
{
    public class SpaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BoxDto> Boxes { get; set; } = new List<BoxDto>();
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
