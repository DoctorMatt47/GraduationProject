using GraduationProject.Domain.Abstractions;

namespace GraduationProject.Domain.Entities;

public class FileRecord : IHasId<Guid>
{
    private FileRecord()
    {
    }

    public string Path { get; private set; } = null!;
    public long SizeInBytes { get; private set; }
    public DateTimeOffset UploadedAt { get; private set; } = DateTimeOffset.UtcNow;

    public User User { get; private set; } = null!;
    public Guid UserId { get; private set; } = Guid.Empty;

    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public static FileRecord Create(string path, long sizeInBytes) =>
        new()
        {
            Path = path,
            SizeInBytes = sizeInBytes,
        };

    public void UpdateSize(long sizeInBytes)
    {
        SizeInBytes = sizeInBytes;
        UploadedAt = DateTimeOffset.UtcNow;
    }
}
