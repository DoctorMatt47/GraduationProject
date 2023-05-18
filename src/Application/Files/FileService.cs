using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Common.Exceptions;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        var user = await _dbContext.Set<User>().FindAsync(_identities.CurrentUser!.Id, cancellationToken)
            ?? throw NotFoundException.DoesNotExist(nameof(User), _identities.CurrentUser!.Id);

        var key = CombineUserIdAndPath(request.Path);

        var fileRecord = FileRecord.Create(request.Path);
        _dbContext.Set<FileRecord>().Add(fileRecord);
        user.AddFileRecord(fileRecord);

        var fileObject = FileObject.Create(key, request.File);
        await _files.UploadFile(fileObject, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<FileRecordResponse>> GetFileRecords(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<FileRecord>()
            .Where(fr => fr.UserId == _identities.CurrentUser!.Id)
            .Select(fr => new FileRecordResponse(fr.Path, fr.SizeInBytes))
            .ToListAsync(cancellationToken);
    }

    public async Task<FileResponse> GetFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        var file = await _files.GetFile(key, cancellationToken);

        return new FileResponse(file.File, file.Path);
    }

    public async Task DeleteFile(string path, CancellationToken cancellationToken = default)
    {
        var key = CombineUserIdAndPath(path);
        await _files.DeleteFile(key, cancellationToken);
    }

    private string CombineUserIdAndPath(string path) =>
        Path.Combine(_identities.CurrentUser!.Id.ToString(), path).Replace("\\", "/");
}
