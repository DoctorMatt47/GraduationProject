namespace GraduationProject.Domain.Entities;

public class FileRecord
{
    private FileRecord()
    {
    }
    
    public string Name { get; private set; } = null!;
    public string Path { get; private set; } = null!;
    public string Extension { get; private set; } = null!;
    
    public User User { get; private set; } = null!;
    public Guid UserId { get; private set; } = Guid.Empty;

    public static FileRecord Create(string name, string path, string extension, Guid userId) =>
        new()
        {
            Name = name,
            Path = path,
            Extension = extension,
            UserId = userId,
        };
}
