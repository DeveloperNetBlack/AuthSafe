using AuthSafe.Presentation.Helpers;

namespace AuthSafe.Presentation.Areas.Security.Models.Role
{
    public class RolePaginationRequestModel: DataTableHelper
    {
        public int CompanyID { get; set; }
        public short StateID { get; set; }
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
