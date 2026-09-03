namespace AuthSafe.Presentation.Models.Auth
{
   public record struct AuthTokenResponseModel(
      string AccessToken,
      string RefreshToken  
   );
}