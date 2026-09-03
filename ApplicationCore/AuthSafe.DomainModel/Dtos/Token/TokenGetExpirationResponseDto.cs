namespace AuthSafe.DomainModel.Dtos.Token
{
    public record struct TokenGetExpirationResponseDto
    (
        int TokenID,
        int UserID,
        DateTime TokenExpirationDateTime
    );
}

