using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.DomainModel.Dtos.Pagination;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Queries.RolePagination
{
    public class RolePaginationQueryRequest : PaginationParametersDto, IRequest<MsgResponse<PaginationResultDto<RolePaginationQueryResponse>>>
    {
        public int CompanyID { get; set; }
        public short StateID { get; set; }
    }
}
