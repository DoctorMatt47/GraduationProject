namespace GraduationProject.Domain.Entities;

public class FileObject
{
    private FileObject()
    {
    }

    public Stream File { get; private init; } = null!;
    public string Path { get; private init; } = null!;

    public static FileObject Create(string path, Stream file) =>
        new()
        {
            File = file,
            Path = path,
        };
}
