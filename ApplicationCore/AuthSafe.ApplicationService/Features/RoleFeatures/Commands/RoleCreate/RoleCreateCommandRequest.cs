using AuthSafe.DomainModel.Enum;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Commands.RoleCreate
{
    public record struct RoleCreateCommandRequest
    (
      int CompanyID,
      string RoleCode,
      string RoleName,
      string RoleDescription,
      StateEnum StateID,
      List<RolePermissionCreateCommandRequest> RolePermission
    ) : IRequest<MsgResponse<object?>>;
}
