using AuthSafe.DomainModel.Enum;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Commands.RoleUpdate
{
    public record struct RoleUpdateCommandRequest
    (
      int RoleID,
      int CompanyID,
      string RoleCode,
      string RoleName,
      string RoleDescription,
      StateEnum StateID,
      List<RolePermissionUpdateCommandRequest> RolePermission
    ) : IRequest<MsgResponse<object?>>;
}
