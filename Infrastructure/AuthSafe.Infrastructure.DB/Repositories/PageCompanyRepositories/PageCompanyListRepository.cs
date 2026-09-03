using AuthSafe.DomainModel.Dtos.PageCompany;
using AuthSafe.DomainService.IRepositories.IPageCompanyRepositories;
using Knotus.NET10.DB.SQLServer;
using System.Data;

namespace AuthSafe.Infrastructure.DB.Repositories.PageCompanyRepositories
{
    internal class PageCompanyListRepository(Connection<PageCompanyListResponseDto> conn) : IPageCompanyListRepository
    {

        public async Task<List<PageCompanyListResponseDto>> ListAsync(int CompanyID, CancellationToken CancellationToken = default)
        {
            Parameters parameters = new Parameters();
            List<PageCompanyListResponseDto> listCompanyPage = new List<PageCompanyListResponseDto>();

            parameters.NameProcedure = "USP_SEL_PAGE_COMPANY";

            parameters.AddParameter("PI_ID_COMPANY", TypeData.DataType.Int, 0, ParameterDirection.Input, CompanyID);

            conn.Devolution = TypeRefund.Register.Entity;

            await conn.ExecuteSQLAsync(parameters, CancellationToken);

            listCompanyPage = (List<PageCompanyListResponseDto>)conn.ReturnEntity;

            return listCompanyPage;
        }
    }
}
