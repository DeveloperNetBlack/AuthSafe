using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Areas.Security.Models.Page;

namespace AuthSafe.Presentation.Areas.Security.Services.PageService
{
    public class PageService : IPageService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = "Page";

        public PageService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<List<PageListResponseModel>>> PageList()
        {
           return await ApiService.GetAsync<ApiResponse<List<PageListResponseModel>>>($"{Controller}/PageList");
        }
    }
}
