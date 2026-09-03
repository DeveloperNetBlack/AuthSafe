using AuthSafe.DomainModel.Dtos.PageCompany;
using AuthSafe.DomainService.IRepositories.IPageCompanyRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.PageCompanyFeatures.Queries.PageCompanyList
{
    internal class PageCompanyListQueryHandler : IRequestHandler<PageCompanyListQueryRequest, MsgResponse<List<PageCompanyListResponseDto>>>
    {
        private readonly IMessageService MessageService;
        private readonly IPageCompanyListRepository PageCompanyListRepository;
        public PageCompanyListQueryHandler(
            IMessageService MessageService,
            IPageCompanyListRepository PageCompanyListRepository
            )
        {
            this.MessageService = MessageService;
            this.PageCompanyListRepository = PageCompanyListRepository;
        }

        public async Task<MsgResponse<List<PageCompanyListResponseDto>>> Handle(PageCompanyListQueryRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<List<PageCompanyListResponseDto>>();
            MsgResponse.Type = MessageTypeConst.QUERY;
            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_RESULT);
            MsgResponse.Data = await PageCompanyListRepository.ListAsync(Request.CompanyID, CancellationToken);
            if (!MsgResponse.Data.Any())
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);

            return MsgResponse;
        }
    }
}
