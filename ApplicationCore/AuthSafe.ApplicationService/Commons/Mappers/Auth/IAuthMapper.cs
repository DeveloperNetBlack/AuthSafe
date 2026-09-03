using AuthSafe.DomainModel.Dtos;
using AuthSafe.DomainModel.Dtos.Auth;

namespace AuthSafe.ApplicationService.Commons.Mappers.Auth
{
    public interface IAuthMapper
    {
        AppUserDto AuthLoginResponseToAppUser(AuthLoginResponseDto AuthLoginResponse);
    }
}
