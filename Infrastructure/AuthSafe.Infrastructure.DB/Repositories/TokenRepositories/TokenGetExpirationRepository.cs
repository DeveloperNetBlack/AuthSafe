using AuthSafe.DomainModel.Dtos.Token;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.TokenRepositories
{
    internal class TokenGetExpirationRepository(Connection<TokenGetExpirationResponseDto?> conn) : ITokenGetExpirationRepository
    {
        public async Task<TokenGetExpirationResponseDto?> GetExpirationAsync(TokenGetExpirationResquestDto TokenGetExpirationResquest, CancellationToken CancellationToken = default)
        {

            Parameters parameters = new Parameters();
            TokenGetExpirationResponseDto listTokenExpiration = new TokenGetExpirationResponseDto();

            parameters.NameProcedure = "USP_SEL_TOKEN_EXPIRATION";

            parameters.AddParameter("PI_ID_ACCOUNT_USER", TypeData.DataType.Varchar, 50, ParameterDirection.Input, TokenGetExpirationResquest.UserID);
            parameters.AddParameter("PI_TOKEN_REFRESH_RANDOM", TypeData.DataType.Varchar, 50, ParameterDirection.Input, TokenGetExpirationResquest.TokenRefreshRandom);
            parameters.AddParameter("PI_FEC_TOKEN_EXPIRATION", TypeData.DataType.Varchar, 50, ParameterDirection.Input, TokenGetExpirationResquest.TokenExpirationDateTime);

            conn.Devolution = TypeRefund.Register.EntitySingle;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            listTokenExpiration = (TokenGetExpirationResponseDto)conn.ReturnEntitySingle!;

            return listTokenExpiration;

        }
    }

}
