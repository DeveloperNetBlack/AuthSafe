using AuthSafe.Presentation.Models;
using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Areas.Security.Models.Company;

namespace AuthSafe.Presentation.Areas.Security.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<ApiResponse<object?>> CompanyCreate(CompanyCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> CompanyUpdate(CompanyCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> CompanyChangeState(CompanyChangeStateRequestModel Request);
        Task<ApiResponse<CompanyGetResponseModel?>> CompanyGet(int CompanyID);
        Task<ApiResponse<PaginationResultModel<CompanyPaginationResponseModel>>> CompanyPagination(CompanyPaginationRequestModel Request);
        Task<ApiResponse<List<CompanyListResponseModel>>> CompanyList(int CompanyIDRegister);
    }
}
