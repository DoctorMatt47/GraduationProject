using GraduationProject.Domain.Abstractions;

namespace GraduationProject.Domain.Entities;

public class IdentityUser : IHasId<Guid>
{
    public IdentityUser(Guid id) => Id = id;

    public Guid Id { get; private set; }
}
