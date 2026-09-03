using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.AuthFeatures.Quieries.AuthLoginToken
{
    public record struct AuthLoginTokenQueryRequest(
            string CompanyDocumentNumber,
            string UserName,
            string UserPassword
    ) : IRequest<MsgResponse<AuthTokenResponseDto?>>;
}
