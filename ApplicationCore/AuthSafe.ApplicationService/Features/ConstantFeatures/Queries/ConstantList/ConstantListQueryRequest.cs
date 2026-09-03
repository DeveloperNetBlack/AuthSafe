using AuthSafe.DomainModel.Dtos.Constant;
using AuthSafe.DomainService.IRepositories.IConstantRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.ConstantFeatures.Queries.ConstantList
{
    internal class ConstantListQueryHandler : IRequestHandler<ConstantListQueryRequest, MsgResponse<List<ConstantListResponseDto>>>
    {
        private readonly IMessageService MessageService;
        private readonly IConstantListRepository ConstantListRepository;
        public ConstantListQueryHandler(
            IMessageService MessageService,
            IConstantListRepository ConstantListRepository)
        {
            this.ConstantListRepository = ConstantListRepository;
            this.MessageService = MessageService;
        }

        public async Task<MsgResponse<List<ConstantListResponseDto>>> Handle(ConstantListQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<ConstantListResponseDto>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            MsgResponse.Data = await ConstantListRepository.ListAsync(Request.ConstantClass, CancellationToken);
            if (!MsgResponse.Data.Any())
            {
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
            }
            return MsgResponse;
        }
    }
}
