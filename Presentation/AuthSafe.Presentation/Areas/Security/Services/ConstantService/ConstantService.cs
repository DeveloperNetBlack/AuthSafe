using AuthSafe.Presentation.Services;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Areas.Security.Models.Constant;

namespace AuthSafe.Presentation.Areas.Security.Services.ConstantService
{
    public class ConstantService : IConstantService
    {
        private readonly IApiService ApiService;
        private readonly string Controller = " Constant";

        public ConstantService(IApiServiceFactory ApiServiceFactory)
        {
            this.ApiService = ApiServiceFactory.Create(ConstantsHelper.HttpClientNames.ApiAuthSafe);
        }

        public async Task<ApiResponse<List<ConstantListResponseModel>>> ConstantList(string ConstantClassConcat)
        {
            return await ApiService.GetAsync<ApiResponse<List<ConstantListResponseModel>>>($"{Controller}/ConstantList?ConstantClassConcat={ConstantClassConcat}");
        }
    }
}