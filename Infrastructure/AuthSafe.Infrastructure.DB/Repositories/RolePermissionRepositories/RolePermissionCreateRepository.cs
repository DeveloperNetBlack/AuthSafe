using AuthSafe.DomainModel.ValueObjects;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RolePermissionRepositories
{
    internal class RolePermissionCreateRepository(Connection<RolePermission> conn) : IRolePermissionCreateRepository
    {

        public async Task<int> CreateAsync(RolePermission Model, CancellationToken CancellationToken = default)
        {
            int RecordAffected = 1;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_INS_ROLE_PERMISSION";

            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdCompany);
            parameters.AddParameter("PI_ID_ROLE", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdRole);
            parameters.AddParameter("PI_ID_PAGE", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdPage);
            parameters.AddParameter("PI_ID_PAGE_ACTION", TypeData.DataType.Int, 0, ParameterDirection.Input, Model.IdPageAction);
            parameters.AddParameter("PI_USER_NAME", TypeData.DataType.Varchar, 20, ParameterDirection.Input, Model.IdUserName);

            conn.Devolution = TypeRefund.Register.None;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return RecordAffected;
        }
    }
}
