using AuthSafe.DomainModel.ValueObjects;

namespace AuthSafe.DomainService.IRepositories.IRolePermissionRepositories
{
    public interface IRolePermissionCreateRepository
    {
        Task<int> CreateAsync(RolePermission Model, CancellationToken CancellationToken = default);
    }
}
