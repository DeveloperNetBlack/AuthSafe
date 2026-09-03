using AuthSafe.DomainModel.Dtos.Constant;

namespace AuthSafe.DomainService.IRepositories.IConstantRepositories
{
    public interface IConstantListRepository
    {
        Task<List<ConstantListResponseDto>> ListAsync(string ConstantClass, CancellationToken CancellationToken = default);
    }
}
