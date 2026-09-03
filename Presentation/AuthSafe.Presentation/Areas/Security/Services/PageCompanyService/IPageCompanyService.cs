using AuthSafe.Presentation.Areas.Security.Models.Page;
using AuthSafe.Presentation.Areas.Security.Models.PageCompany;
using AuthSafe.Presentation.Services;

namespace AuthSafe.Presentation.Areas.Security.Services.PageCompanyService
{
    public interface IPageCompanyService
    {
        Task<ApiResponse<object?>> PageCompanyDeleteCreate(PageCompanyDeleteCreateRequestModel Request);
        Task<ApiResponse<List<PageListResponseModel>>> PageCompanyList(int CompanyID);
    }
}