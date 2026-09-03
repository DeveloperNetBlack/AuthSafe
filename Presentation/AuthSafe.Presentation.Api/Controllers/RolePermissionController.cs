using AuthSafe.ApplicationService.Features.RolePermissionFeatures.Queries.RolePermissionList;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthSafe.Presentation.Api.Controllers
{
    public class RolePermissionController : BaseController
    {
        [HttpPost("RolePermissionList")]
        [SwaggerOperation(Summary = "Listar los permisos por usuario y empresa", Description = "Permite listar los permisos por usuario y empresa.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonExceptionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RolePermissionList([FromBody] RolePermissionListQueryRequest Query, CancellationToken CancellationToken)
        {
            return Ok(await Mediator.Send(Query, CancellationToken));
        }
    }
}
