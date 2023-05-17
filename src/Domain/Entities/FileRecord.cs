using GraduationProject.Domain.Abstractions;

namespace GraduationProject.Domain.Entities;

public class FileRecord : IHasId<Guid>
{
    private FileRecord()
    {
    }

    public string Path { get; private set; } = null!;
    public long SizeInBytes { get; private set; } = 0;

    public User User { get; private set; } = null!;
    public Guid UserId { get; private set; }

    public Guid Id { get; private set; } = Guid.NewGuid();

    public static FileRecord Create(string path, Guid userId) =>
        new()
        {
            Path = path,
            UserId = userId,
        };
}
