using AuthSafe.DomainModel.Dtos.RolePermission;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RolePermissionRepositories
{
    internal class RolePermissionListRepository(Connection<RolePermissionListResponseDto> conn) : IRolePermissionListRepository
    {
        public async Task<List<RolePermissionListResponseDto>> ListAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default)
        {
            Parameters parameters = new Parameters();
            List<RolePermissionListResponseDto> listRolePermission = new List<RolePermissionListResponseDto>();

            parameters.NameProcedure = "USP_SEL_ROLE_PERMISSION";

            parameters.AddParameter("@PI_ID_ACCOUNT_USER", TypeData.DataType.Varchar, 50, ParameterDirection.Input, UserID);
            parameters.AddParameter("@PI_ID_COMPANY", TypeData.DataType.Varchar, 50, ParameterDirection.Input, CompanyID);

            conn.Devolution = TypeRefund.Register.Entity;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            listRolePermission = (List<RolePermissionListResponseDto>)conn.ReturnEntity;

            return listRolePermission;
        }
    }

}
