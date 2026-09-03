using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.DomainModel.Dtos.Pagination;
using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Queries.RolePagination
{
    internal class RolePaginationQueryHandler : IRequestHandler<RolePaginationQueryRequest, MsgResponse<PaginationResultDto<RolePaginationQueryResponse>>>
    {
        private readonly IRolePaginationRepository RolePaginationRepository;
        private readonly IMessageService MessageService;
        public RolePaginationQueryHandler(IRolePaginationRepository RolePaginationRepository,
            IMessageService MessageService
            )
        {
            this.RolePaginationRepository = RolePaginationRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<PaginationResultDto<RolePaginationQueryResponse>>> Handle(RolePaginationQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<PaginationResultDto<RolePaginationQueryResponse>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            var Response = await RolePaginationRepository.PaginationAsync(new RolePaginationResquestDto
            {
                IdState = Request.CompanyID,
                IdCompany = Request.StateID,
                Parameters = new PaginationParametersDto()
                {
                    Search = Request.Search ?? "",
                    PageNumber = Request.PageNumber,
                    PageSize = Request.PageSize
                }
            }, CancellationToken);

            if (!Response.Entities.Any()) MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);

            MsgResponse.Data = new PaginationResultDto<RolePaginationQueryResponse>();
            MsgResponse.Data.Items = Response.Entities.Select(s => new RolePaginationQueryResponse
            {
                RoleID = s.RoleID,
                RoleCode = s.RoleCode,
                RoleName = s.RoleName,
                StateID = s.StateID,
                RoleDescription = s.RoleDescription,
                RoleLastUpdatedDateTime = s.RoleLastUpdatedDateTime,
                RoleLastUpdatedUserName = s.RoleLastUpdatedUserName
            }).ToList();
            MsgResponse.Data.TotalRecords = Response.Total;
            MsgResponse.Data.RecordsFiltered = Response.Filtered;
            return MsgResponse;

        }
    }

}
