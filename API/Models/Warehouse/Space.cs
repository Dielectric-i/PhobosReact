using ErrorOr;
using Org.BouncyCastle.Utilities;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Models.Warehouse
{
    public class Space
    {
        public Guid Id { get; }
        public string Name { get;  }
        public List<Box> Boxes { get; }
        public List<Item> Items { get; }

        private Space(Guid id,
                     string name,
                     List<Box> boxes,
                     List<Item> items)
        {
            Id = id;
            Name = name;
            Boxes = boxes;
            Items = items;
        }

        public static ErrorOr<Space> Create(
                     string name,
                     List<Box>? boxes = null,
                     List<Item>? items = null,
                     Guid? id = null)
        {
            List<Error> errors = new();

            // TODO Add validation

            return new Space(
                id ?? Guid.NewGuid(),
                name,
                boxes = new List<Box>(),
                items = new List<Item>());
        }
        public static ErrorOr<Space> From(CreateSpaceRequest request)
        {
            return Create(
                request.Name);
        }

        // Mapping Dto
        public static Space From(SpaceDto spaceDto)
        {
            // spaceDto.Boxes в space.Boxes
            var boxesSpace = new List<Box>();
            foreach (var boxSpaceDto in spaceDto.Boxes)
            {
                boxesSpace.Add(Box.From(boxSpaceDto));
            }

            // spaceDto.Items в space.Items
            var itemsSpace = new List<Item>();
            foreach (var itemDto in spaceDto.Items)
            {
                itemsSpace.Add(Item.From(itemDto));
            }

            return new Space(
                spaceDto.Id,
                spaceDto.Name,
                boxesSpace,
                itemsSpace);

        }
        public SpaceDto SpaceToDto(Space space)
        {
            // box.Spaces в boxDto.Spaces
            var boxesSpaceDto = new List<BoxDto>();
            foreach (var boxSpace in space.Boxes)
            {
                boxesSpaceDto.Add(boxSpace.BoxToDto(boxSpace));
            }

            // box.Items в boxDto.Items
            var itemsSpaceDto = new List<ItemDto>();
            foreach (var itemSpace in space.Items)
            {
                itemsSpaceDto.Add(itemSpace.ItemToDto(itemSpace));
            }

            return new SpaceDto
            {
                Id = space.Id,
                Name = space.Name,
                Boxes = boxesSpaceDto,
                Items = itemsSpaceDto
            };
        }
    }
}
