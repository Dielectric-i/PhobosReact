using System.ComponentModel.DataAnnotations;

namespace PhobosReact.API.Contracts
{
    public record CreateBoxRequest
    (
        [Required] string Name,
        [Required] Guid SpaceId
    );
}
