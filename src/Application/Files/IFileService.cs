namespace GraduationProject.Application.Files;

public interface IFileService
{
    Task UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<FileRecordResponse>> GetFileRecords(
        CancellationToken cancellationToken = default);

    Task<Stream> DownloadFile(string path, CancellationToken cancellationToken = default);
}
