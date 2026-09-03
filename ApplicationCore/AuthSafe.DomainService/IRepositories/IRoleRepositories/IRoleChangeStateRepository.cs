using AuthSafe.DomainModel.Model;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRoleChangeStateRepository
    {
        Task<int> ChangeStateAsync(Role Model, CancellationToken CancellationToken = default);
    }
}
