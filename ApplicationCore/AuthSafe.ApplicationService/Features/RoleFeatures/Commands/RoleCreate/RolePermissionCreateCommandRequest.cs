namespace AuthSafe.ApplicationService.Features.RoleFeatures.Commands.RoleCreate
{
    public record struct RolePermissionCreateCommandRequest
    (
        int PageID,
        int PageActionID
     );
}
