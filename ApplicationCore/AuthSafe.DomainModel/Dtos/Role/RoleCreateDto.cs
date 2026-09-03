namespace AuthSafe.DomainModel.Dtos.Role
{
    public record struct RoleCreateDto
(
    int IdRole,
    int IdCompany,
    string RoleCode,
    string RoleName,
    string RoleDescription,
    short IdState,
    string IdUserName
);
}
