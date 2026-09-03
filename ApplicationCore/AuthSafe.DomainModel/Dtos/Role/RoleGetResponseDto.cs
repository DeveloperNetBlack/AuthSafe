using AuthSafe.DomainModel.Dtos.RolePermission;

namespace AuthSafe.DomainModel.Dtos.Role
{
    public record struct RoleGetResponseDto
    (
        int IdRole,
        int IdCompany,
        string RoleCode,
        string RoleName,
        string RoleDescription,
        short IdState,
        string IdUserName,
        List<RolePermissionGetResponseDto> RolePermission
    );
}
