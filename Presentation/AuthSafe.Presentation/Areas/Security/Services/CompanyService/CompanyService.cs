using AuthSafe.Presentation.Models;
using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Areas.Security.Models.Company;

namespace AuthSafe.Presentation.Areas.Security.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "Company";

        public CompanyService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<object?>> CompanyCreate(CompanyCreateUpdateRequestModel Request)
        {           
            return await ApiService.PostFormDataAsync<CompanyCreateUpdateRequestModel, ApiResponse<object?>>($"{Controller}/CompanyCreate", Request);
        }
        public async Task<ApiResponse<object?>> CompanyUpdate(CompanyCreateUpdateRequestModel Request)
        {
            return await ApiService.PutFormDataAsync<CompanyCreateUpdateRequestModel, ApiResponse<object?>>($"{Controller}/CompanyUpdate", Request);
        }
        public async Task<ApiResponse<object?>> CompanyChangeState(CompanyChangeStateRequestModel Request)
        {
            return await ApiService.PutAsync<CompanyChangeStateRequestModel, ApiResponse<object?>>($"{Controller}/CompanyChangeState", Request);
        }
        public async Task<ApiResponse<CompanyGetResponseModel?>> CompanyGet(int CompanyID)
        {
            return await ApiService.GetAsync<ApiResponse<CompanyGetResponseModel?>>($"{Controller}/CompanyGet/{CompanyID}");
        }
        public async Task<ApiResponse<PaginationResultModel<CompanyPaginationResponseModel>>> CompanyPagination(CompanyPaginationRequestModel Request)
        {
            return await ApiService.PostAsync<string, ApiResponse<PaginationResultModel<CompanyPaginationResponseModel>>>($"{Controller}/CompanyPagination", null, Request);
        }

        public async Task<ApiResponse<List<CompanyListResponseModel>>> CompanyList(int CompanyIDRegister)
        {
            return await ApiService.GetAsync<ApiResponse<List<CompanyListResponseModel>>>($"{Controller}/CompanyList/{CompanyIDRegister}");
        }
    }
}