using AuthSafe.DomainModel.Enum;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Commands.RoleChangeState
{
    public record struct RoleChangeStateCommandRequest
    (
        int CompanyID,
        int RoleID,
        StateEnum StateID
    ) : IRequest<MsgResponse<object?>>;
}
