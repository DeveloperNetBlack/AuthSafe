using AuthSafe.DomainModel.Dtos.RolePermission;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RolePermissionFeatures.Queries.RolePermissionList
{
    internal class RolePermissionListQueryHandler : IRequestHandler<RolePermissionListQueryRequest, MsgResponse<List<RolePermissionListResponseDto>>>
    {
        private readonly IRolePermissionListRepository RolePermissionListRepository;
        private readonly IMessageService MessageService;

        public RolePermissionListQueryHandler(IRolePermissionListRepository RolePermissionListRepository,
            ICurrentSessionService CurrentSessionService,
            IMessageService MessageService
            )
        {
            this.RolePermissionListRepository = RolePermissionListRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<RolePermissionListResponseDto>>> Handle(RolePermissionListQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<RolePermissionListResponseDto>>();

            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Data = await RolePermissionListRepository.ListAsync(Request.UserID, Request.CompanyID, CancellationToken);
            
            if (MsgResponse.Data is null)
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            else 
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            
            return MsgResponse;
        }
    }
}
