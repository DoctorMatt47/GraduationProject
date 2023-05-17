namespace GraduationProject.Domain.Entities;

public class FileObject
{
    private FileObject()
    {
    }

    public MemoryStream File { get; private init; } = null!;
    public string Path { get; private init; } = null!;

    public static FileObject Create(string path, MemoryStream file) =>
        new()
        {
            File = file,
            Path = path,
        };
}
