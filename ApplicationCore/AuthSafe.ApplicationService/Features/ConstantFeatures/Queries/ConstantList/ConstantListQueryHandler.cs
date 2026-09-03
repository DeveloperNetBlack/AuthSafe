using AuthSafe.DomainModel.Dtos.Constant;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.ConstantFeatures.Queries.ConstantList
{
    public record struct ConstantListQueryRequest
    (
      string ConstantClass
    ) : IRequest<MsgResponse<List<ConstantListResponseDto>>>;
}
