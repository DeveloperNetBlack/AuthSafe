using AuthSafe.DomainModel.Dtos.Pagination;

namespace AuthSafe.DomainModel.Dtos.Role
{
    public record struct RolePaginationResquestDto
    (
        int IdCompany,
        int IdState,
        PaginationParametersDto Parameters
    );
}
