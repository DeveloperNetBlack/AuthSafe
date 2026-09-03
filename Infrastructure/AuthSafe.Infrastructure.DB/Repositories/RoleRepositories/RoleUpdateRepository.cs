using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RoleRepositories
{
    internal class RoleUpdateRepository(Connection<RoleCreateDto> conn) : IRoleUpdateRepository
    {
        public async Task<int> UpdateAsync(RoleCreateDto Model, CancellationToken CancellationToken = default)
        {
            int RecordAffected = 1;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_UPD_ROLE";

            parameters.AddParameter("PI_ID_ROLE", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdRole);
            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdCompany);
            parameters.AddParameter("PI_ROLE_CODE", TypeData.DataType.Varchar, 5, ParameterDirection.Input, Model.RoleCode);
            parameters.AddParameter("PI_ROLE_NAME", TypeData.DataType.Varchar, 150, ParameterDirection.Input, Model.RoleName);
            parameters.AddParameter("PI_ROLE_DESCRIPTION", TypeData.DataType.Varchar, 150, ParameterDirection.Input, Model.RoleDescription);
            parameters.AddParameter("PI_ID_STATE", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdState);
            parameters.AddParameter("PI_USER_NAME", TypeData.DataType.Varchar, 20, ParameterDirection.Input, Model.IdUserName);

            conn.Devolution = TypeRefund.Register.None;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return RecordAffected;
        }
    }
}
