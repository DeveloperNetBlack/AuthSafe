using AuthSafe.DomainModel.Dtos.PageCompany;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthSafe.DomainModel.Dtos.Company
{
    public record struct CompanyGetResponseDto
    (
        int CompanyID,
        string CompanyTradeName,
        string CompanySocialReason,
        string CompanyDocumentNumber,
        DateTime CompanyBirthDate,
        int CountryID,
        string CompanyAddress,
        short TaxpayerTypeID,
        short RubroID,
        string CompanyCorporateEmail,
        string CompanyMobile,
        string CompanyPhone,
        string CompanyLogo,
        short StateID,
        List<PageCompanyGetResponseDto> PageCompany
    );
}
