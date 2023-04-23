using ErrorOr;
using Microsoft.EntityFrameworkCore;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Models.Warehouse;
using PhobosReact.API.ServicesError;

namespace PhobosReact.API.Data.Repositories
{
    public class SpaceRepository : ISpaceRepository
    {
        private readonly AppDbContext _context;

        public SpaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> CreateSpace(Space space)
        {
            try
            {
                SpaceDto spaceDto = space.SpaceToDto(space);

                await _context.AddAsync<SpaceDto>(spaceDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return Errors.Space.CreationFailed(ex);
            }
            return Result.Created;
        }
        public async Task<ErrorOr<Space>> GetSpace(Guid id)
        {
            // Get Dto From Db
            var space = await _context.Spaces.Include(space => space.Boxes)
                                                   .FirstOrDefaultAsync(space => space.Id == id);

            //TODO add null check

            return Space.From(space);
        }

        public async Task<ErrorOr<IEnumerable<SpaceDto>>> GetAllSpaces()
        {
            var errors = new List<Error>();

            var spacesDto = new List<SpaceDto>();
            try
            {
            spacesDto = await _context.Spaces.Include(s => s.Boxes)
                                                    .Include(i => i.Items)
                                                    .ToListAsync();
            }
            catch (Exception ex)
            {
                errors.Add(Errors.Box.RepositoryExceprion(ex));
            }

            if (spacesDto == null)
            {
                errors.Add(Errors.Space.NotFound);
            }

            if (errors.Count > 0)
            {
                return errors;
            }
            return spacesDto;
        }
    }

}
