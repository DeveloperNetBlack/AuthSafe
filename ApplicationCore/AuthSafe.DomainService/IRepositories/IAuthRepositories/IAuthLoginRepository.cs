using AuthSafe.DomainModel.Dtos.Auth;

namespace AuthSafe.DomainService.IRepositories.IAuthRepositories
{
    public interface IAuthLoginRepository
    {
        Task<AuthLoginResponseDto?> LoginAsync(AuthLoginRequestDto UserCredentials, CancellationToken CancellationToken = default);
    }
}
