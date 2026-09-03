using AuthSafe.DomainModel.Dtos.PageCompany;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.PageCompanyFeatures.Queries.PageCompanyList
{
    public record struct PageCompanyListQueryRequest
    (
        int CompanyID
    ) : IRequest<MsgResponse<List<PageCompanyListResponseDto>>>;
}
