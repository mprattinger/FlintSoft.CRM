using System.Security.Cryptography;
using FlintSoft.CRM.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlintSoft.CRM.Api.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists"),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")
            };

            return Problem(statusCode: statusCode, title: message);
        }
    }
}
