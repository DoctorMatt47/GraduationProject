namespace GraduationProject.Application.Identities;

public record IdentityResponse(
    string Token,
    Guid Id);

public record CreateIdentityRequest(
    string Login,
    string Password);
