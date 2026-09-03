namespace AuthSafe.DomainModel.Dtos.RolePermission
{
    public record struct RolePermissionListResponseDto
    (
        int IdPage,
        int IdPageParent,
        string PageHierarchy,
        string PageName,
        string PageUrlName,
        string PageIconName,
        short PageOrder
    );
}
