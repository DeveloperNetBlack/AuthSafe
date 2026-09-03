namespace AuthSafe.ApplicationService.Commons.Dtos
{
    public record struct AuthTokenResponseDto(
       string AccessToken,
       string RefreshToken
    );
}
