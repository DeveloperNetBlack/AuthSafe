using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Queries.RoleGet
{
    public record struct RoleGetQueryRequest
    (
      int RoleID
    ) : IRequest<MsgResponse<RoleGetQueryResponse?>>;
}
