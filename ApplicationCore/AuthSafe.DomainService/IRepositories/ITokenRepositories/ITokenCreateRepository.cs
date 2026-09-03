using AuthSafe.DomainModel.Dtos.Token;

namespace AuthSafe.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenCreateRepository
    {
        Task<int> CreateAsync(TokenCreateDto Model, CancellationToken CancellationToken = default);
    }
}
