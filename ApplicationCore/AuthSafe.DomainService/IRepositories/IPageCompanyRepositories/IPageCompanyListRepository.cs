using AuthSafe.DomainModel.Dtos.PageCompany;

namespace AuthSafe.DomainService.IRepositories.IPageCompanyRepositories
{
    public interface IPageCompanyListRepository
    {
        Task<List<PageCompanyListResponseDto>> ListAsync(int CompanyID, CancellationToken CancellationToken = default);
    }
}
