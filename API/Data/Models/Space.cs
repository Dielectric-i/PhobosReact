using ErrorOr;
using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Data.Models
{
    public class Space
    {
        public Guid Id { get; }
        public string Name { get; }
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
    }
}
