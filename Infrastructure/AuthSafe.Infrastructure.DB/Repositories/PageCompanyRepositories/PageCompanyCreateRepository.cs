using AuthSafe.DomainModel.Dtos.PageCompany;
using AuthSafe.DomainModel.ValueObjects;
using AuthSafe.DomainService.IRepositories.IPageCompanyRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.PageCompanyRepositories
{
    internal class PageCompanyCreateRepository(Connection<PageCompany> conn) : IPageCompanyCreateRepository
    {
        public async Task<int> CreateAsync(PageCompany Model, CancellationToken CancellationToken = default)
        {
            int RecordAffected = 1;

            Parameters parameters = new Parameters();
            parameters.NameProcedure = "USP_INS_PAGE_COMPANY";

            parameters.AddParameter("PI_ID_PAGE", TypeData.DataType.Varchar, 50, ParameterDirection.Input, Model.IdPage);
            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Varchar, 100, ParameterDirection.Input, Model.IdCompany);
            parameters.AddParameter("PI_USER_NAME", TypeData.DataType.Varchar, 200, ParameterDirection.Input, Model.IdUserName);

            conn.Devolution = TypeRefund.Register.None;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            return RecordAffected;
        }
    }
}
