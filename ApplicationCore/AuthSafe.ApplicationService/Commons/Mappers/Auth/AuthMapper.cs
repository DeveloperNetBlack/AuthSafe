using AuthSafe.DomainModel.Dtos;
using AuthSafe.DomainModel.Dtos.Auth;
using AuthSafe.Infrastructure.CrossCutting.Enums;

namespace AuthSafe.ApplicationService.Commons.Mappers.Auth
{
    public class AuthMapper : IAuthMapper
    {
        public AppUserDto AuthLoginResponseToAppUser(AuthLoginResponseDto AuthLoginResponse)
        {
            AppUserDto AppUser = new AppUserDto()
            {
                UserID = AuthLoginResponse.IdAccountUser,
                UserName = AuthLoginResponse.UserName,
                UserFirstName = AuthLoginResponse.UserFirstName,
                UserLastName = AuthLoginResponse.UserLastName,
                UserEmail = AuthLoginResponse.UserEmail,
                CompanyID = AuthLoginResponse.IdCompany,
                IdiomID = (short)IdiomEnum.Spanish,
                CompanyDocumentNumber = AuthLoginResponse.CompanyNumberDocument,
                CompanyTradeName = AuthLoginResponse.CompanyTradeName,
                CompanySocialReason = AuthLoginResponse.CompanySocialReason,
                RoleCodes = "1,2"
            };
            return AppUser;
        }
    }
}
