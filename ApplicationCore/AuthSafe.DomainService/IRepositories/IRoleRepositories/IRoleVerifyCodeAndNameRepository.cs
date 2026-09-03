using AuthSafe.DomainModel.Dtos.Role;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRoleVerifyCodeAndNameRepository
    {
        Task<string> VerifyCodeAndNameAsync(RoleCreateDto Model, CancellationToken CancellationToken = default);
    }
}
