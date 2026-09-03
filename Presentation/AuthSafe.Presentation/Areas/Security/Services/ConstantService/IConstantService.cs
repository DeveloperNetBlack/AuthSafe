using AuthSafe.Presentation.Areas.Security.Models.Constant;
using AuthSafe.Presentation.Services;

namespace AuthSafe.Presentation.Areas.Security.Services.ConstantService
{
    public interface IConstantService
    {
        Task<ApiResponse<List<ConstantListResponseModel>>> ConstantList(string ConstantClassConcat);       
    }
}