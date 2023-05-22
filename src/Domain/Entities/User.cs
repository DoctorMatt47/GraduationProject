using GraduationProject.Domain.Exceptions;

namespace GraduationProject.Domain.Entities;

public class User : IdentityUser
{
    private readonly List<FileRecord> _fileRecords = new();

    public IEnumerable<FileRecord> FileRecords => _fileRecords.ToList();

    private User() : base(Guid.NewGuid())
    {
    }

    public string Login { get; private set; } = null!;
    public byte[] PasswordSalt { get; private set; } = null!;
    public byte[] PasswordHash { get; private set; } = null!;
    public long MaxBytesAvailable { get; private set; } = 104_857_600;
    public long BytesUsed { get; set; }

    public static User Create(string login, byte[] passwordSalt, byte[] passwordHash) =>
        new()
        {
            Login = login,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
        };

    public void AddFileRecord(FileRecord fileRecord)
    {
        _fileRecords.Add(fileRecord);

        if (BytesUsed + fileRecord.SizeInBytes > MaxBytesAvailable)
        {
            throw new DomainConflictException("Not enough space available");
        }

        BytesUsed += fileRecord.SizeInBytes;
    }
}
