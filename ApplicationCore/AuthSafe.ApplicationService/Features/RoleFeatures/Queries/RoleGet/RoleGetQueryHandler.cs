using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Queries.RoleGet
{
    internal class RoleGetQueryHandler : IRequestHandler<RoleGetQueryRequest, MsgResponse<RoleGetQueryResponse?>>
    {
        private readonly IRoleGetRepository RoleGetRepository;
        private readonly IMessageService MessageService;
        public RoleGetQueryHandler(IRoleGetRepository RoleGetRepository, IMessageService MessageService)
        {
            this.RoleGetRepository = RoleGetRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<RoleGetQueryResponse?>> Handle(RoleGetQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<RoleGetQueryResponse?>();
            MsgResponse.Type = MessageTypeConst.ERROR;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);

            var RoleGet = await RoleGetRepository.GetAsync(Request.RoleID, CancellationToken);
            if (RoleGet is not null)
            {
                MsgResponse.Type = MessageTypeConst.QUERY;
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);

                var Pages = RoleGet.Value.RolePermission.Select(Page => new RolePageGetQueryResponse
                {
                    PageID = Page.PageID,
                    Actions = RoleGet.Value.RolePermission.Where(w => w.PageID == Page.PageID && w.PageActionID != 0).Select(Action => new RoleActionGetQueryResponse
                    {
                        PageActionID = Action.PageActionID
                    }).ToList()
                })
                .Distinct()
                .ToList();

                var RoleResponse = new RoleGetQueryResponse()
                {
                    RoleID = RoleGet.Value.IdRole,
                    RoleCode = RoleGet.Value.RoleCode,
                    RoleName = RoleGet.Value.RoleName,
                    RoleDescription = RoleGet.Value.RoleDescription,
                    StateID = RoleGet.Value.IdState,
                    Pages = Pages
                };
                MsgResponse.Data = RoleResponse;
            }
            return MsgResponse;
        }
    }
}
