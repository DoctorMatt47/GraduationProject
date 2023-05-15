using GraduationProject.Application.Identities;

namespace GraduationProject.Application.Files;

public class FileService : IFileService
{
    private readonly IIdentityRepository _identities;
    private readonly IFileRepository _files;

    public FileService(IIdentityRepository identities, IFileRepository files)
    {
        _identities = identities; 
        _files = files;
    }
    
    public async Task<Stream> GetFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        return await _files.GetFile(key, cancellationToken);
    }

    public async Task UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(request.Path);
        await _files.UploadFile(request with {Path = key}, cancellationToken);
    }
    
    public async Task DeleteFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        await _files.DeleteFile(key, cancellationToken);
    }
    
    private string CombineUserIdAndPath(string path) => Path.Combine(_identities.CurrentUser!.Id.ToString(), path);
}
