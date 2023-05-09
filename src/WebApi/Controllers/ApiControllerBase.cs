using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
}
