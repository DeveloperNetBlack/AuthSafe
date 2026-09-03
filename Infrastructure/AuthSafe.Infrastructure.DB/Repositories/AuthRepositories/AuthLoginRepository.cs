using AuthSafe.DomainModel.Dtos.Auth;
using AuthSafe.DomainService.IRepositories.IAuthRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.AuthRepositories
{
    internal class AuthLoginRepository(Connection<AuthLoginResponseDto> conn) : IAuthLoginRepository
    {
        public async Task<AuthLoginResponseDto?> LoginAsync(AuthLoginRequestDto UserCredentials, CancellationToken CancellationToken)
        {
            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_SEL_AUTH_USER";

            parameters.AddParameter("PI_NUMBER_DOCUMENT", TypeData.DataType.Varchar, 50, ParameterDirection.Input, UserCredentials.CompanyDocumentNumber ?? (object)DBNull.Value);
            parameters.AddParameter("PI_USER_NAME", TypeData.DataType.Varchar, 100, ParameterDirection.Input, UserCredentials.UserName ?? (object)DBNull.Value);
            parameters.AddParameter("PI_USER_PASSWORD", TypeData.DataType.Varchar, 200, ParameterDirection.Input, UserCredentials.UserPassword ?? (object)DBNull.Value);

            conn.Devolution = TypeRefund.Register.EntitySingle;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return conn.ReturnEntitySingle;
        }
    }

}
