using ErrorOr;
using PhobosReact.API.Data.Dto;
using PhobosReact.API.Data.Interfaces;
using PhobosReact.API.Services;
using PhobosReact.API.ServicesError;

namespace PhobosReact.API.Data.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly AppDbContext _context;
        private readonly IMappingService _mappingService;

        public BoxRepository(AppDbContext context,
                             IMappingService mappingService)
        {
            _context = context;
            _mappingService = mappingService;
        }

        public async Task<ErrorOr<BoxDto>> CreateBox(BoxDto boxDto)
        {
            try
            {
                await _context.AddAsync<BoxDto>(boxDto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Errors.Box.RepositoryExceprion(ex);
            }

            return boxDto;
        }

        public async Task<ErrorOr<BoxDto>> GetBox(Guid id)
        {
            List<Error> errors = new List<Error>();

            var boxDto = new BoxDto();
            try
            {
                boxDto = _context.Boxes.FirstOrDefault(b => b.Id == id);
            }
            catch (Exception ex)
            {
                errors.Add(Errors.Box.RepositoryExceprion(ex));
            }

            if (boxDto == null)
            {
                errors.Add(Errors.Box.NotFound);
            }

            if (errors.Count>0)
            {
                return errors;
            }

            return boxDto;

        }
    }
}
