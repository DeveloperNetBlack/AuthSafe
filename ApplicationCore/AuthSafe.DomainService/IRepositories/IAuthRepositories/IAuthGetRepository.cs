using AuthSafe.DomainModel.Dtos.Auth;

namespace AuthSafe.DomainService.IRepositories.IAuthRepositories
{
    public interface IAuthGetRepository
    {
        Task<AuthLoginResponseDto?> GetAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default);
    }
}
