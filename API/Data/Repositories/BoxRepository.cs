using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Models;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.ServicesError;

namespace PhobosReact.API.Data.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly AppDbContext _context;

        public BoxRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> CreateBox(Box box)
        {
            try
            {
                BoxDto boxDto = box.BoxToDto(box);

                await _context.AddAsync<BoxDto>(boxDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

               return Errors.Box.CreationFailed(ex);
            }
            return Result.Created;
        }

        public Task<ErrorOr<Box>> GetBox(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Box>> GetBoxesInSpace(int id)
        {
            throw new NotImplementedException();
        }
    }
}
