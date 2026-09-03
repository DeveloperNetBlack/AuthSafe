using AuthSafe.Presentation.Areas.Security.Models.Page;
using AuthSafe.Presentation.Services;

namespace AuthSafe.Presentation.Areas.Security.Services.PageService
{
    public interface IPageService
    {
        Task<ApiResponse<List<PageListResponseModel>>> PageList();
    }
}
