using AuthSafe.DomainModel.Dtos.Pagination;
using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.RoleRepositories
{
    internal class RolePaginationRepository(Connection<PaginationResponseDto<RolePaginationResponseDto>> conn) : IRolePaginationRepository
    {
        public async Task<PaginationResponseDto<RolePaginationResponseDto>> PaginationAsync(RolePaginationResquestDto RolePaginationResquest, CancellationToken CancellationToken = default)
        {
            Parameters parameters = new Parameters();
            var Pagination = new PaginationResponseDto<RolePaginationResponseDto>();

            parameters.NameProcedure = "USP_SEL_ROLE_PAGINATION";

            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, RolePaginationResquest.IdCompany);
            parameters.AddParameter("PI_ROLE_NAME", TypeData.DataType.Varchar, 50, ParameterDirection.Input, RolePaginationResquest.Parameters.Search);
            parameters.AddParameter("PI_ID_STATE", TypeData.DataType.Int, 0, ParameterDirection.Input, RolePaginationResquest.IdState);
            parameters.AddParameter("PI_PAGE_NUMBER", TypeData.DataType.Int, 0, ParameterDirection.Input, RolePaginationResquest.Parameters.PageNumber);
            parameters.AddParameter("PI_PAGE_SIZE", TypeData.DataType.Int, 0, ParameterDirection.Input, RolePaginationResquest.Parameters.PageSize);

            conn.Devolution = TypeRefund.Register.Entity;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            Pagination = (PaginationResponseDto<RolePaginationResponseDto>)conn.ReturnEntity;

            return Pagination;
        }
    }
}
