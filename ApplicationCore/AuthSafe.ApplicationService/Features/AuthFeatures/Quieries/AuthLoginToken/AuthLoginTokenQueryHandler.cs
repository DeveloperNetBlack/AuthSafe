using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.ApplicationService.Commons.Mappers.Auth;
using AuthSafe.DomainModel.Dtos;
using AuthSafe.DomainModel.Dtos.Auth;
using AuthSafe.DomainModel.Dtos.Token;
using AuthSafe.DomainModel.Model;
using AuthSafe.DomainService.IRepositories.IAuthRepositories;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.AuthFeatures.Quieries.AuthLoginToken
{
    internal class AuthLoginTokenQueryHandler(
             IAuthLoginRepository AuthLoginRepository,
             IGenerateTokenService GenerateTokenService,
             ITokenCreateRepository TokenCreateRepository,
             IAuthMapper AuthMapper
        ) : IRequestHandler<AuthLoginTokenQueryRequest, MsgResponse<AuthTokenResponseDto?>>
    {
        public async Task<MsgResponse<AuthTokenResponseDto?>> Handle(AuthLoginTokenQueryRequest Request, CancellationToken CancellationToken)
        {
            var UserLoginRequest = new AuthLoginRequestDto()
            {
                CompanyDocumentNumber = Request.CompanyDocumentNumber,
                UserName = Request.UserName,
                UserPassword = Request.UserPassword
            };

            var AuthLoginResponse = await AuthLoginRepository.LoginAsync(UserLoginRequest, CancellationToken);

            var MsgResponse = new MsgResponse<AuthTokenResponseDto?>();
            MsgResponse.Type = MessageTypeConst.QUERY;

            if (AuthLoginResponse == null)
            {
                MsgResponse.Message = MessageDescriptionConst.INVALID_CREDENTIAL_DESCRIPTION;
            }
            else
            {
                MsgResponse.Message = MessageDescriptionConst.VALID_CREDENTIAL_DESCRIPTION;
                AppUserDto AppUser = AuthMapper.AuthLoginResponseToAppUser(AuthLoginResponse.Value);
                var AuthTokenResponse = new AuthTokenResponseDto()
                {
                    AccessToken = await GenerateTokenService.GenerateJWTToken(AppUser),
                    RefreshToken = await GenerateTokenService.GenerateRandomToken()
                };
                var Model = new TokenCreateDto()
                {
                    IdAccountUser = AppUser.UserID,
                    IdCompany = AppUser.CompanyID,
                    TokenRefreshRandom = AuthTokenResponse.RefreshToken,
                    FecTokenCreate = AppUser.CurrentDateTime,
                    FecTokenExpirationRandom = AppUser.ExpirationRandomDateTime,
                    FecTokenExpirationJWT = AppUser.ExpirationJWTDateTime,
                    UserName = "ADMIN"
                };

                await TokenCreateRepository.CreateAsync(Model, CancellationToken);

                MsgResponse.Data = AuthTokenResponse;
            }
            return MsgResponse;
        }
    }

}
