using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Models.Warehouse;

namespace PhobosReact.API.Services
{
    public class MappingService : IMappingService
    {

        //       BOX      //
        //----------------//
        public ErrorOr<Box> FromDto(BoxDto boxDto)
        {
            
            List<Error> errors = new();

            // boxDto.Boxes в box.Boxes
            var boxesBox = new List<Box>();
            foreach (var boxBoxDto in boxDto.Boxes)
            {
                ErrorOr<Box> resultBox = FromDto(boxBoxDto);

                if (resultBox.IsError)
                    errors.AddRange(resultBox.Errors);
                else boxesBox.Add(resultBox.Value);

            }

            // boxDto.Items в box.Items
            var itemsBox = new List<Item>();
            foreach (var itemBoxDto in boxDto.Items)
            {
                ErrorOr<Item> resultItem = FromDto(itemBoxDto);

                if (resultItem.IsError)
                    errors.AddRange(resultItem.Errors);
                else itemsBox.Add(resultItem.Value);
            }

            if (errors.Count>0)
                return errors;

            return Box.Create(
                id: boxDto.Id,
                name: boxDto.Name,
                parentBoxId: boxDto.ParentBoxId,
                boxes: boxesBox,
                items: itemsBox,
                spaceId: boxDto.SpaceId);
        }

        public ErrorOr<BoxDto> ToDto(Box box)
        {
            List<Error> errors = new();

            // box.Boxes в boxDto.Boxes
            var boxesBoxDto = new List<BoxDto>();

            foreach (var boxBox in box.Boxes)
            {
                ErrorOr<BoxDto> resultDto = ToDto(boxBox);

                if (resultDto.IsError)
                    errors.AddRange(resultDto.Errors);
                else boxesBoxDto.Add(resultDto.Value);

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

        //       ITEM     //
        //----------------//
        public ErrorOr<Item> FromDto(ItemDto itemDto)
        {
            return Item.Create(
                id: itemDto.Id,
                name: itemDto.Name
                );
        }
        public ErrorOr<ItemDto> ToDto(Item item)
        {

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        //       Space    //
        //----------------//
        public ErrorOr<Space> FromDto(SpaceDto spaceDto)
        {

            List<Error> errors = new();

            // spaceDto.Boxes в space.Boxes
            var boxesSpace = new List<Box>();
            foreach (var boxSpaceDto in spaceDto.Boxes)
            {
                ErrorOr<Box> resultBox = FromDto(boxSpaceDto);

                if (resultBox.IsError)
                    errors.AddRange(resultBox.Errors);
                else boxesSpace.Add(resultBox.Value);

            }

            // spaceDto.Items в space.Items
            var itemsSpace = new List<Item>();
            foreach (var itemSpaceDto in spaceDto.Items)
            {
                ErrorOr<Item> resultItem = FromDto(itemSpaceDto);

                if (resultItem.IsError)
                    errors.AddRange(resultItem.Errors);
                else itemsSpace.Add(resultItem.Value);
            }

            if (errors.Count > 0)
                return errors;

            return Space.Create(
                id: spaceDto.Id,
                name: spaceDto.Name,
                boxes: boxesSpace,
                items: itemsSpace);
        }

        public ErrorOr<SpaceDto> ToDto(Space space)
        {
            List<Error> errors = new();

            // space.Boxes в spaceDto.Boxes
            var boxesSpaceDto = new List<BoxDto>();

            foreach (var boxSpace in space.Boxes)
            {
                ErrorOr<BoxDto> resultBoxDto = ToDto(boxSpace);

                if (resultBoxDto.IsError)
                    errors.AddRange(resultBoxDto.Errors);
                else boxesSpaceDto.Add(resultBoxDto.Value);

            }

            // box.Items в boxDto.Items
            var itemsSpaceDto = new List<ItemDto>();
            foreach (var itemSpace in space.Items)
            {
                ErrorOr<ItemDto> resultItemDto = ToDto(itemSpace);

                if (resultItemDto.IsError)
                    errors.AddRange(resultItemDto.Errors);
                else itemsSpaceDto.Add(resultItemDto.Value);
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
