using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainModel.Model;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using AuthSafe.Infrastructure.DB.AppDBContext;
using Knotus.NET10.DB.SQLServer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RoleRepositories
{
    internal class RoleVerifyCodeAndNameRepository(Connection<RoleCreateDto> conn) : IRoleVerifyCodeAndNameRepository
    {
        public async Task<string> VerifyCodeAndNameAsync(RoleCreateDto Model, CancellationToken CancellationToken = default)
        {
            string retorno = string.Empty;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_SEL_VERIFY_CODE_NAME";

            parameters.AddParameter("PI_ID_ROLE", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdRole);
            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdCompany);
            parameters.AddParameter("PI_ROLE_CODE", TypeData.DataType.Varchar, 5, ParameterDirection.Input, Model.RoleCode);
            parameters.AddParameter("PI_ROLE_NAME", TypeData.DataType.Varchar, 150, ParameterDirection.Input, Model.RoleName);

            conn.Devolution = TypeRefund.Register.Scale;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            retorno = conn.ReturnScale!.ToString()!;

            return retorno;
        }
    }
}
