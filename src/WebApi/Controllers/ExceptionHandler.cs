using GraduationProject.Application.Common.Exceptions;
using GraduationProject.WebApi.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class ExceptionHandler : ControllerBase
{
    [Route("/error")]
    public ActionResult<ErrorResponse> Handle()
    {
        var error = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (error is not ApplicationExceptionBase exception) return StatusCode(500);

        var responseCode = exception switch
        {
            BadRequestException => 400,
            ForbiddenException => 403,
            NotFoundException => 404,
            ConflictException => 409,
            _ => 500,
        };

        return StatusCode(responseCode, new ErrorResponse(exception.Message));
    }
}
