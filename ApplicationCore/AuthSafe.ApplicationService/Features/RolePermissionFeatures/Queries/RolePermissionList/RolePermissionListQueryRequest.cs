using AuthSafe.DomainModel.Dtos.RolePermission;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RolePermissionFeatures.Queries.RolePermissionList
{
    public record struct RolePermissionListQueryRequest
    (
     int UserID,
     int CompanyID
    ) : IRequest<MsgResponse<List<RolePermissionListResponseDto>>>;
}
