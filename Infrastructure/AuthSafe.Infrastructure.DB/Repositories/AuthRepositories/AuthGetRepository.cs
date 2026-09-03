using AuthSafe.DomainModel.Dtos.Auth;
using AuthSafe.DomainService.IRepositories.IAuthRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.AuthRepositories
{
    internal class AuthGetRepository(Connection<AuthLoginResponseDto> conn) : IAuthGetRepository
    {
        public async Task<AuthLoginResponseDto?> GetAsync(int UserID, int CompanyID, CancellationToken CancellationToken)
        {
            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_SEL_AUTH_GET";

            parameters.AddParameter("PI_ID_ACCOUNT_USER", TypeData.DataType.Int, 0, ParameterDirection.Input, UserID);
            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, CompanyID);

            conn.Devolution = TypeRefund.Register.EntitySingle;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return conn.ReturnEntitySingle;
        }
    }

}
