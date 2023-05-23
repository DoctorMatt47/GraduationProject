namespace GraduationProject.Application.Identities;

public record IdentityResponse(
    string Token,
    Guid Id,
    long MaxBytesAvailable,
    long BytesUsed);

public record CreateIdentityRequest(
    string Login,
    string Password);
