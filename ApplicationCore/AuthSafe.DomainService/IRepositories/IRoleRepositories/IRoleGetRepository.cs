using AuthSafe.DomainModel.Dtos.Role;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRoleGetRepository
    {
        Task<RoleGetResponseDto?> GetAsync(int RoleID, CancellationToken CancellationToken = default);
    }
}
