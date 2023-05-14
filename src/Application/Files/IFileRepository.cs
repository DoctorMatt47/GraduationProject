namespace GraduationProject.Application.Files;

public interface IFileRepository
{
    Task UploadFile(UploadFileRequest file, CancellationToken cancellationToken = default);
}
