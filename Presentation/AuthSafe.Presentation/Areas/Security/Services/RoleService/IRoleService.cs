using AuthSafe.Presentation.Models;
using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Areas.Security.Models.Role;

namespace AuthSafe.Presentation.Areas.Security.Services.RoleService
{
    public interface IRoleService
    {
        Task<ApiResponse<object?>> RoleCreate(RoleCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> RoleUpdate(RoleCreateUpdateRequestModel Request);
        Task<ApiResponse<object?>> RoleChangeState(RoleChangeStateRequestModel Request);
        Task<ApiResponse<RoleGetResponseModel?>> RoleGet(int RoleID);
        Task<ApiResponse<PaginationResultModel<RolePaginationResponseModel>>> RolePagination(RolePaginationRequestModel Request);   
    }
}