using AuthSafe.DomainModel.Dtos.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthSafe.DomainModel.Dtos.Company
{
    public record struct CompanyPaginationResquestDto
    (
        int CompanyIDRegister,
        short? TaxpayerTypeID,
        short? RubroID,
        string? CompanyDocumentNumber,
        string? CompanySocialReason,
        short StateID,
        PaginationParametersDto Parameters
    );
}
