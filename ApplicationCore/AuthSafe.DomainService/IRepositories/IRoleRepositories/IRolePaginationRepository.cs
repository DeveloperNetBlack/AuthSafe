using AuthSafe.DomainModel.Dtos.Pagination;
using AuthSafe.DomainModel.Dtos.Role;

namespace AuthSafe.DomainService.IRepositories.IRoleRepositories
{
    public interface IRolePaginationRepository
    {
        Task<PaginationResponseDto<RolePaginationResponseDto>> PaginationAsync(RolePaginationResquestDto RolePaginationResquest, CancellationToken CancellationToken = default);
    }
}
