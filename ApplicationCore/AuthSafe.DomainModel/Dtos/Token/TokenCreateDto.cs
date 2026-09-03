namespace AuthSafe.DomainModel.Dtos.Token
{
    public record struct TokenCreateDto
    (
        int IdToken,
        int IdCompany,
        int IdAccountUser,
        string? TokenSessionJson,
        string TokenRefreshRandom,
        string? TokenAccessJWT,
        DateTime FecTokenCreate,
        DateTime FecTokenExpirationRandom,
        DateTime FecTokenExpirationJWT,
        DateTime FecTokenRevocation,
        int IdState,
        string UserName
    );
}
