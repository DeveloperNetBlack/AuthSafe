namespace AuthSafe.Presentation.Models.Auth
{
   public record struct AuthRefreshTokenRequestModel(
      string AccessToken,
      string RefreshToken  
   );
}