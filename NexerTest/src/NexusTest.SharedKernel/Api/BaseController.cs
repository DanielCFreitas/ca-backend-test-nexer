using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NexusTest.SharedKernel.Api
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult BaseResponse(object? resultado = null)
        {
            if (resultado != null)
                return new OkObjectResult(resultado);
            return new OkResult();
        }

        protected IActionResult BaseResponse(ValidationResult validationResult, object? resultado = null)
        {
            if (validationResult?.ErrorMessage?.Length > 0)
                return new BadRequestResult();
            if (resultado != null)
                return new OkObjectResult(resultado);
            return new OkResult();
        }
    }
}
