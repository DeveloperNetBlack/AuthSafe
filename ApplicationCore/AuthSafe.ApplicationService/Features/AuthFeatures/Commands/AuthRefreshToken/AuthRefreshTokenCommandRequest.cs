using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.ApplicationService.Commons.Mappers.Auth;
using AuthSafe.DomainModel.Dtos;
using AuthSafe.DomainModel.Dtos.Token;
using AuthSafe.DomainModel.Model;
using AuthSafe.DomainService.IRepositories.IAuthRepositories;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.AuthFeatures.Commands.AuthRefreshToken
{
    internal class AuthRefreshTokenCommandHandler(
       ITokenCreateRepository TokenCreateRepository,
       ITokenGetExpirationRepository TokenGetRepository,
       ITokenUpdateRevocationRepository TokenUpdateRepository,
       IAuthGetRepository AuthGetRepository,
       IMessageService MessageService,
       IGenerateTokenService GenerateTokenService,
       IAuthMapper AuthMapper
    ) : IRequestHandler<AuthRefreshTokenCommandRequest, MsgResponse<AuthTokenResponseDto>>
    {
        public async Task<MsgResponse<AuthTokenResponseDto>> Handle(AuthRefreshTokenCommandRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<AuthTokenResponseDto>();
            try
            {
                var ClaimsPrincipal = await GenerateTokenService.ValidateJWTToken(Request.AccessToken, IgnoreExpiration: true);

                if (!ClaimsPrincipal!.IsValid || ClaimsPrincipal.UserID == null)
                {
                    MsgResponse.Type = MessageTypeConst.WARNING; //El token inválido, no tiene userId
                    MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.INVALID_JWT_TOKEN);
                }
                else if (!ClaimsPrincipal.IsExpired)
                {
                    MsgResponse.Type = MessageTypeConst.WARNING; // El token aún no expiró, no refrescar
                    MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.VALID_JWT_TOKEN);
                }
                else
                {
                    var TokenGetResponse = await TokenGetRepository.GetExpirationAsync(new
                                     TokenGetExpirationResquestDto(
                                        UserID: ClaimsPrincipal.UserID.Value,
                                        TokenRefreshRandom: Request.RefreshToken,
                                        TokenExpirationDateTime: DateTime.Now
                                    ), CancellationToken);

                    if (TokenGetResponse is null)
                    {
                        MsgResponse.Type = MessageTypeConst.WARNING; // El refresh token inválido o ya expiró
                        MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.INVALID_RANDOM_TOKEN);
                    }
                    else
                    {
                        var AuthLoginResponse = await AuthGetRepository.GetAsync(ClaimsPrincipal.UserID.Value, ClaimsPrincipal.CompanyID, CancellationToken);

                        if (AuthLoginResponse is null)
                        {
                            MsgResponse.Type = MessageTypeConst.WARNING;
                            MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.QUERY_EMPTY);
                        }
                        else
                        {
                            var RecordAffected = await TokenUpdateRepository.UpdateRevocationAsync(new Token
                            {
                                TokenID = TokenGetResponse.Value.TokenID,
                                TokenCreateDateTime = DateTime.Now
                            }, CancellationToken);

                            AppUserDto AppUser = AuthMapper.AuthLoginResponseToAppUser(AuthLoginResponse.Value);
                            var AuthTokenResponse = new AuthTokenResponseDto
                            {
                                AccessToken = await GenerateTokenService.GenerateJWTToken(AppUser),
                                RefreshToken = await GenerateTokenService.GenerateRandomToken()
                            };

                            var Model = new TokenCreateDto()
                            {
                                IdAccountUser = ClaimsPrincipal.UserID.Value,
                                IdCompany = ClaimsPrincipal.CompanyID,
                                TokenRefreshRandom = AuthTokenResponse.RefreshToken,
                                FecTokenCreate = AppUser.CurrentDateTime,
                                FecTokenExpirationRandom = AppUser.ExpirationRandomDateTime,
                                FecTokenExpirationJWT = AppUser.ExpirationJWTDateTime
                            };

                            RecordAffected = await TokenCreateRepository.CreateAsync(Model, CancellationToken);
                            if (RecordAffected > 0)
                            {

                                MsgResponse.Type = MessageTypeConst.SUCCESS;
                                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.SATISFACTORY_INSERT);
                                MsgResponse.Data = AuthTokenResponse;
                            }
                            else
                            {
                                MsgResponse.Type = MessageTypeConst.ERROR;
                                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.ERROR_INSERT);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgResponse.Type = MessageTypeConst.ERROR;
                MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.ERROR_OPERATION + "-" + ex.Message);
            }
            return MsgResponse;
        }

    }
}
