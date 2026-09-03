using AuthSafe.Presentation.Models.RolePermission;
using AuthSafe.Presentation.Helpers;

namespace AuthSafe.Presentation.Services.RolePermissionService
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "RolePermission";

        public RolePermissionService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<List<RolePermissionListResponseModel>>> RolePermissionList(RolePermissionListRequestModel Request)
        {
            return await ApiService.PostAsync<RolePermissionListRequestModel, ApiResponse<List<RolePermissionListResponseModel>>>($"{Controller}/RolePermissionList", Request);
        }
    }
}
