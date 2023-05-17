using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Common.Exceptions;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Application.Files;

public class FileService : IFileService
{
    private readonly IAppDbContext _dbContext;
    private readonly IFileRepository _files;
    private readonly IIdentityRepository _identities;

    public FileService(IIdentityRepository identities, IFileRepository files, IAppDbContext dbContext)
    {
        _identities = identities;
        _files = files;
        _dbContext = dbContext;
    }

    public async Task UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Set<User>().FindAsync(_identities.CurrentUser!.Id)
            ?? throw NotFoundException.DoesNotExist(nameof(User), _identities.CurrentUser!.Id);

        if (user.BytesUsed + request.SizeInBytes > user.MaxBytesAvailable)
        {
            throw new ConflictException("Not enough space available");
        }

        var key = CombineUserIdAndPath(request.Path);

        var fileRecord = FileRecord.Create(key, user.Id);
        user.AddFileRecord(fileRecord);

        var fileObject = FileObject.Create(key, request.File);
        await _files.UploadFile(fileObject, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Stream> GetFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        return await _files.GetFile(key, cancellationToken);
    }

    public async Task DeleteFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        await _files.DeleteFile(key, cancellationToken);
    }

    private string CombineUserIdAndPath(string path) => Path.Combine(_identities.CurrentUser!.Id.ToString(), path);
}
