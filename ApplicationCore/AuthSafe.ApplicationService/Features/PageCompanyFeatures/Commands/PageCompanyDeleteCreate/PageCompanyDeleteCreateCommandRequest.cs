using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.PageCompanyFeatures.Commands.PageCompanyDeleteCreate
{
    public record struct PageCompanyDeleteCreateCommandRequest
    (
        int CompanyID,
        List<int> PageIDS
    ) : IRequest<MsgResponse<object?>>;
}
