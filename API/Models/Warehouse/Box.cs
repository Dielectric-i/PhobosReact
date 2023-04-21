using ErrorOr;
using PhobosReact.API.Contracts;
using PhobosReact.API.Data.Dto;
using static PhobosReact.API.ServicesError.Errors;

namespace PhobosReact.API.Models.Warehouse
{
    public class Box
    {
        public Guid Id { get; }
        public string Name { get;  }

        public Guid? ParentBoxId { get; set; }

        public List<Box> Boxes { get; }
        public List<Item> Items { get; }

        public Guid SpaceId { get; set; }

        private Box(Guid id,
                    string name,
                    Guid? parentBoxId,
                    List<Box> boxes,
                    List<Item> items,
                    Guid spaceId)
        {
            Id = id;
            Name = name;
            ParentBoxId = parentBoxId;
            Boxes = boxes;
            Items = items;
            SpaceId = spaceId;
        }
        public static ErrorOr<Box> Create(
                     string name,
                     Guid spaceId,
                     Guid? parentBoxId = null,
                     List<Box>? boxes = null,
                     List<Item>? items = null,
                     Guid? id = null)
        {
            List<Error> errors = new();

            // TODO Add validation

            return new Box(
                id: id ?? Guid.NewGuid(),
                name: name,
                parentBoxId: parentBoxId,
                boxes: boxes = new List<Box>(),
                items: items = new List<Item>(),
                spaceId: spaceId);
        }
        public static ErrorOr<Box> From(CreateBoxRequest request)
        {
            return Create(request.Name, request.SpaceId);
        }


        // Mapping Dto
        public static Box From(BoxDto boxDto)
        {
            // boxDto.Boxes в box.Boxes
            var boxesBox = new List<Box>();
            foreach (var boxBoxDto in boxDto.Boxes)
            {
                boxesBox.Add(Box.From(boxBoxDto));
            }

            // boxDto.Items в box.Items
            var itemsBox = new List<Item>();
            foreach (var itemDto in boxDto.Items)
            {
                itemsBox.Add(Item.From(itemDto));
            }

            return new Box(
                id: boxDto.Id,
                name: boxDto.Name,
                parentBoxId: boxDto.ParentBoxId,
                boxes: boxesBox,
                items: itemsBox,
                spaceId: boxDto.SpaceId);

        }
        public BoxDto BoxToDto(Box box)
        {
            // box.Boxes в boxDto.Boxes
            var boxesBoxDto = new List<BoxDto>();
            foreach (var boxBox in box.Boxes)
            {
                boxesBoxDto.Add(boxBox.BoxToDto(boxBox));
            }

            // box.Items в boxDto.Items
            var itemsBoxDto = new List<ItemDto>();
            foreach (var itemBox in box.Items)
            {
                itemsBoxDto.Add(itemBox.ItemToDto(itemBox));
            }
            
            return new BoxDto
            {
                Id = box.Id,
                Name = box.Name,
                ParentBoxId = box.ParentBoxId,
                Boxes = boxesBoxDto,
                Items = itemsBoxDto,
                SpaceId = box.SpaceId
            };
        }
    }
}
