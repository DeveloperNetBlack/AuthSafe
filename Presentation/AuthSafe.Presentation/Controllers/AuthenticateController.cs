using AuthSafe.Presentation.Areas.Security.Models.Role.Filters;
using AuthSafe.Presentation.Extensions;
using AuthSafe.Presentation.Helpers;
using AuthSafe.Presentation.Models.Auth;
using AuthSafe.Presentation.Models.RolePermission;
using AuthSafe.Presentation.Services.AuthService;
using AuthSafe.Presentation.Services.RolePermissionService;
using Microsoft.AspNetCore.Mvc;

namespace AuthSafe.Presentation.Controllers
{
    public class AuthenticateController : BaseController
    {
        private readonly IAuthService AuthService;
        private readonly IRolePermissionService RolePermissionService;
        public AuthenticateController(IAuthService AuthService, IRolePermissionService RolePermissionService)
        {
            this.AuthService = AuthService;
            this.RolePermissionService = RolePermissionService;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(AuthLoginTokenRequestModel model)
        {
            string Url = string.Empty;
            string Message = string.Empty;
            var ApiResponse = await AuthService.SignIn(model);

            if (ApiResponse.Data is not null)
            {
                Url = "Dashboard";

                var authenticationIdentity = ConvertsHelper.ExtractUserInfo(ApiResponse.Data.Value.AccessToken);

                if (HttpContext.Session != null)
                {
                    if (HttpContext.Session.GetObject<AuthenticationIdentity>(ConstantsHelper.SessionKeys.AuthenticationIdentity) == null)
                    {
                        HttpContext.Session.SetObject(ConstantsHelper.SessionKeys.AuthenticationIdentity, authenticationIdentity);
                    }
                    if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(ConstantsHelper.SessionKeys.AccessToken)))
                    {
                        HttpContext.Session.SetString(ConstantsHelper.SessionKeys.AccessToken, ApiResponse.Data.Value.AccessToken);
                    }
                    if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(ConstantsHelper.SessionKeys.RefreshToken)))
                    {
                        HttpContext.Session.SetString(ConstantsHelper.SessionKeys.RefreshToken, ApiResponse.Data.Value.RefreshToken);
                    }
                    if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(ConstantsHelper.SessionKeys.MenuSidebar)))
                    {
                        var ApiResponseRolePermission = await RolePermissionService.RolePermissionList(new RolePermissionListRequestModel
                        {
                            UserID = authenticationIdentity.UserID,
                            CompanyID = authenticationIdentity.CompanyID
                        });
                        HttpContext.Session.SetObject(ConstantsHelper.SessionKeys.MenuSidebar, ApiResponseRolePermission.Data!);
                    }
                }
            }

            return Json(new { ApiResponse.Message, Url });
        }
        /*
        [HttpGet]
        public ActionResult ExpiredSession() {
            var msgResponse = new MsgResponse<string>();            
            msgResponse.Type = MsgOperation.MessageType.Session.ToString();
            msgResponse.Title = MsgOperation.GetEnumDescription(MsgOperation.MessageTitle.AssistantSession);
            msgResponse.Message = MsgOperation.GetEnumDescription(MsgOperation.MessageDescription.VerifyExpiredSession);
            msgResponse.Session = false;
            msgResponse.Function = "Uti.Modal.Session()";
            return Json(msgResponse);
        }
        */

    }
}
