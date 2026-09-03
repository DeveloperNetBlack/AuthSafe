using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RoleRepositories
{
    internal class RoleGetRepository(Connection<RoleGetResponseDto> conn) : IRoleGetRepository
    {
        public async Task<RoleGetResponseDto?> GetAsync(int RoleID, CancellationToken CancellationToken = default)
        {
            Parameters parameters = new Parameters();
            RoleGetResponseDto listRole = new RoleGetResponseDto();

            parameters.NameProcedure = "USP_SEL_ROLE";

            parameters.AddParameter("PI_ID_ROLE", TypeData.DataType.Int, 0, ParameterDirection.Input, RoleID);

            conn.Devolution = TypeRefund.Register.EntitySingle;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            listRole = conn.ReturnEntitySingle;

            return listRole;
        }
    }
}
