namespace AuthSafe.DomainModel.Dtos.Auth
{
    public record struct AuthLoginResponseDto(
        int IdAccountUser,
        string UserName,
        string UserFirstName,
        string UserLastName,
        string UserEmail,          // <- renombrado desde UserMail
        int IdCompany,
        string CompanyNumberDocument,
        string CompanyTradeName,
        string CompanySocialReason,
        int IdState
   );
}