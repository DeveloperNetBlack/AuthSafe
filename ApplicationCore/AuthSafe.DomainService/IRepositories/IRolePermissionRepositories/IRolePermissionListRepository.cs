using AuthSafe.DomainModel.Dtos.RolePermission;

namespace AuthSafe.DomainService.IRepositories.IRolePermissionRepositories
{
    public interface IRolePermissionListRepository
    {
        Task<List<RolePermissionListResponseDto>> ListAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default);
    }
}
