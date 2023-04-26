using PhobosReact.API.Data.Dto;

namespace PhobosReact.API.Contracts
{
    public record CreateBoxRequest(
        
        string BoxName,
        Guid? ParentBoxId,
        Guid SpaceDtoId
        );
}
