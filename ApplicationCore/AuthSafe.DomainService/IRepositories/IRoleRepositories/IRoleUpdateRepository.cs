using AuthSafe.DomainModel.Dtos.Role;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRoleUpdateRepository
    {
        Task<int> UpdateAsync(RoleCreateDto Model, CancellationToken CancellationToken = default);
    }
}
