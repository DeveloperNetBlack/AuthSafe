using AuthSafe.Presentation.Models.Auth;

namespace AuthSafe.Presentation.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthTokenResponseModel?>> SignIn(AuthLoginTokenRequestModel Request);
        Task<ApiResponse<AuthTokenResponseModel?>> Refresh(AuthRefreshTokenRequestModel Request);
    }
}