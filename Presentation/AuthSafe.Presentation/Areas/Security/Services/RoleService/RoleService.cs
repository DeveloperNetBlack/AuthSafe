using AuthSafe.Presentation.Models;
using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Areas.Security.Models.Role;

namespace AuthSafe.Presentation.Areas.Security.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "Role";

        public RoleService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<object?>> RoleCreate(RoleCreateUpdateRequestModel Request)
        {
            return await ApiService.PostAsync<RoleCreateUpdateRequestModel, ApiResponse<object?>>($"{Controller}/RoleCreate", Request);
        }
        public async Task<ApiResponse<object?>> RoleUpdate(RoleCreateUpdateRequestModel Request)
        {
            return await ApiService.PutAsync<RoleCreateUpdateRequestModel, ApiResponse<object?>>($"{Controller}/RoleUpdate", Request);
        }
        public async Task<ApiResponse<object?>> RoleChangeState(RoleChangeStateRequestModel Request)
        {
            return await ApiService.PutAsync<RoleChangeStateRequestModel, ApiResponse<object?>>($"{Controller}/RoleChangeState", Request);
        }
        public async Task<ApiResponse<RoleGetResponseModel?>> RoleGet(int RoleID)
        {
            return await ApiService.GetAsync<ApiResponse<RoleGetResponseModel?>>($"{Controller}/RoleGet/{RoleID}");
        }
        public async Task<ApiResponse<PaginationResultModel<RolePaginationResponseModel>>> RolePagination(RolePaginationRequestModel Request)
        {
            return await ApiService.PostAsync<string, ApiResponse<PaginationResultModel<RolePaginationResponseModel>>>($"{Controller}/RolePagination", null ,Request);
        }
    }
}