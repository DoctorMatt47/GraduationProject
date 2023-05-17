using GraduationProject.Domain.Entities;

namespace GraduationProject.Application.Files;

public interface IFileRepository
{
    Task<Stream> GetFile(string path, CancellationToken cancellationToken = default);
    Task UploadFile(FileObject request, CancellationToken cancellationToken = default);
    Task DeleteFile(string path, CancellationToken cancellationToken = default);
}
