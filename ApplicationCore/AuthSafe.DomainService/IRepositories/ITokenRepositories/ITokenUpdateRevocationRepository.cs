using AuthSafe.DomainModel.Model;

namespace AuthSafe.DomainService.IRepositories.ITokenRepositories
{
    public interface ITokenUpdateRevocationRepository
    {
        Task<int> UpdateRevocationAsync(Token Model, CancellationToken CancellationToken = default);
    }
}
