using AuthSafe.DomainModel.Dtos.Role;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRoleCreateRepository
    {
        Task<int> CreateAsync(RoleCreateDto Model, CancellationToken CancellationToken = default);
    }
}
