using AuthSafe.DomainModel.Dtos.Token;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.TokenRepositories
{
    internal class TokenCreateRepository(Connection<TokenCreateDto> conn) : ITokenCreateRepository
    {
        public async Task<int> CreateAsync(TokenCreateDto Model, CancellationToken CancellationToken)
        {
            int RecordAffected = 1;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_INS_TOKEN";

            parameters.AddParameter("@PI_ID_COMPANY", TypeData.DataType.Varchar, 50, ParameterDirection.Input, Model.IdCompany);
            parameters.AddParameter("@PI_ID_ACCOUNT_USER", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.IdAccountUser);
            parameters.AddParameter("@PI_TOKEN_SESSION_JSON", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.TokenSessionJson);
            parameters.AddParameter("@PI_TOKEN_REFRESH_RANDOM", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.TokenRefreshRandom);
            parameters.AddParameter("@PI_TOKEN_ACCESS_JWT", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.TokenAccessJWT);
            parameters.AddParameter("@PI_FEC_TOKEN_CREATE", TypeData.DataType.DateTime, 0, ParameterDirection.Input, Model.FecTokenCreate);
            parameters.AddParameter("@PI_FEC_TOKEN_EXPIRATION_RANDOM", TypeData.DataType.DateTime, 0, ParameterDirection.Input, Model.FecTokenExpirationRandom);
            parameters.AddParameter("@PI_FEC_TOKEN_EXPIRATION_JWT", TypeData.DataType.DateTime, 0, ParameterDirection.Input, Model.FecTokenExpirationJWT);
            parameters.AddParameter("PI_USER_NAME", TypeData.DataType.Varchar, 20, ParameterDirection.Input, Model.UserName);

            conn.Devolution = TypeRefund.Register.None;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return RecordAffected;
        }
    }

}
