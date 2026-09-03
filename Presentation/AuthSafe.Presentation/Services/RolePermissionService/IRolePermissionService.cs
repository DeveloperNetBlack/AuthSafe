using AuthSafe.Presentation.Models.RolePermission;

namespace AuthSafe.Presentation.Services.RolePermissionService
{
    public interface IRolePermissionService
    {
        Task<ApiResponse<List<RolePermissionListResponseModel>>> RolePermissionList(RolePermissionListRequestModel Request);
    }
}