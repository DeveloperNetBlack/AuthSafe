using AuthSafe.DomainModel.Dtos.Token;

namespace AuthSafe.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenGetExpirationRepository
    {
        Task<TokenGetExpirationResponseDto?> GetExpirationAsync(TokenGetExpirationResquestDto TokenGetExpirationResquest, CancellationToken CancellationToken = default);
    }
}
