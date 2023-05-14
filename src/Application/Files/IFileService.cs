namespace GraduationProject.Application.Files;

public interface IFileService
{
    Task UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default);
}
