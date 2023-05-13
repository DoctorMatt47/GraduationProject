using GraduationProject.Domain.Abstractions;

namespace GraduationProject.Domain.Entities;

public class IdentityUser : IHasId<Guid>
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}
