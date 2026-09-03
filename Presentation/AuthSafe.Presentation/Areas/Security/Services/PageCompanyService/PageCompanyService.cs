using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Areas.Security.Models.Page;
using AuthSafe.Presentation.Areas.Security.Models.PageCompany;

namespace AuthSafe.Presentation.Areas.Security.Services.PageCompanyService
{
    public class PageCompanyService : IPageCompanyService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "PageCompany";

        public PageCompanyService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<object?>> PageCompanyDeleteCreate(PageCompanyDeleteCreateRequestModel Request)
        {
            return await ApiService.PostAsync<PageCompanyDeleteCreateRequestModel, ApiResponse<object?>>($"{Controller}/PageCompanyDeleteCreate", Request);
        }

        public async Task<ApiResponse<List<PageListResponseModel>>> PageCompanyList(int CompanyID)
        {
            return await ApiService.GetAsync<ApiResponse<List<PageListResponseModel>>>($"{Controller}/PageCompanyList/{CompanyID}");
        }
    }
}