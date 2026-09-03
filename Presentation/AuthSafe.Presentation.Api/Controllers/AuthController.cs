using AuthSafe.ApplicationService.Commons.Dtos;
using AuthSafe.ApplicationService.Features.AuthFeatures.Commands.AuthRefreshToken;
using AuthSafe.ApplicationService.Features.AuthFeatures.Quieries.AuthLoginToken;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthSafe.Presentation.Api.Controllers
{
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("SignIn")]
        [SwaggerOperation(Summary = "Inicar sesión", Description = "Permite Inicar sesión.")]
        [ProducesResponseType(typeof(MsgResponse<AuthTokenResponseDto?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonExceptionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignIn([FromBody] AuthLoginTokenQueryRequest Query, CancellationToken CancellationToken)
        {
            return Ok(await Mediator.Send(Query, CancellationToken));
        }

        [AllowAnonymous]
        [HttpPost("Refresh")]
        [SwaggerOperation(Summary = "Generar JWT", Description = "Permite Generar JWT.")]
        [ProducesResponseType(typeof(MsgResponse<AuthTokenResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JsonExceptionResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Refresh([FromBody] AuthRefreshTokenCommandRequest Command, CancellationToken CancellationToken)
        {
            return Ok(await Mediator.Send(Command, CancellationToken));
        }
    }
}
