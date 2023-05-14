using GraduationProject.Application.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

public class IdentitiesController : ApiControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentitiesController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [HttpPost("Authenticate")]
    [AllowAnonymous]
    public Task<IdentityResponse> Authenticate(
        CreateIdentityRequest body,
        CancellationToken cancellationToken)
    {
        return _identityService.CreateIdentity(body, cancellationToken);
    }
}
