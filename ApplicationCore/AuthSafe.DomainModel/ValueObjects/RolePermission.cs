namespace AuthSafe.DomainModel.ValueObjects
{
    public record struct RolePermission
    (
         int IdCompany,
         int IdRole,
         int IdPage,
         int IdPageAction,
         string IdUserName
    );
}
