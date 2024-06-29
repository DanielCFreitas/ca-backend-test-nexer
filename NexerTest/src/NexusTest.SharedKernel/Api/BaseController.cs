using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NexerTest.SharedKernel.Api
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
            if (!string.IsNullOrEmpty(validationResult?.ErrorMessage))
                return new BadRequestObjectResult(validationResult.ErrorMessage);
            if (resultado != null)
                return new OkObjectResult(resultado);
            return new OkResult();
        }
    }
}
