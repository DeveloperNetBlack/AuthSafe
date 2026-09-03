using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.AuthFeatures.Commands.AuthRefreshToken
{
    public record struct AuthRefreshTokenCommandRequest
    (string AccessToken,
      string RefreshToken
    ) : IRequest<MsgResponse<AuthTokenResponseDto>>;
}
