namespace GraduationProject.Application.Identities;

public interface IIdentityService
{
    public Task<IdentityResponse> CreateIdentity(CreateIdentityRequest request, CancellationToken cancellationToken);
}
