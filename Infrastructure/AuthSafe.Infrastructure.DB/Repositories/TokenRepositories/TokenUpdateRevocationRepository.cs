using AuthSafe.DomainModel.Model;
using AuthSafe.DomainService.IRepositories.ITokenRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.TokenRepositories
{
    internal class TokenUpdateRevocationRepository(Connection<Token> conn) : ITokenUpdateRevocationRepository
    {
        public async Task<int> UpdateRevocationAsync(Token Model, CancellationToken CancellationToken)
        {
            int RecordAffected = 1;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_UPD_TOKEN_REVOCATION";

            parameters.AddParameter("PI_ID_TOKEN", TypeData.DataType.Varchar, 50, ParameterDirection.Input, Model.TokenID);
            parameters.AddParameter("@I_FEC_TOKEN_REVOCATION", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.TokenCreateDateTime);

            conn.Devolution = TypeRefund.Register.None;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return RecordAffected;
        }
    }
}
