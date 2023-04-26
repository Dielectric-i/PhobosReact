using ErrorOr;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Data.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private Item(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public static ErrorOr<Item> Create(string name,
                                           Guid? id)
        {
            List<Error> errors = new();

            // TODO Add validation

            return new Item(
                id: id ?? Guid.NewGuid(),
                name: name);
        }

        // Mapping Dto
        public static Item From(ItemDto itemDto)
        {
            return new Item(
                itemDto.Id,
                itemDto.Name
                );
        }
        public ItemDto ItemToDto(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}
