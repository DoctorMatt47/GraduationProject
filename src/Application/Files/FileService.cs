using GraduationProject.Application.Common.Abstractions;
using GraduationProject.Application.Identities;
using GraduationProject.Domain.Entities;

namespace GraduationProject.Application.Files;

public class FileService : IFileService
{
    // private readonly IFileRepository _files;
    private readonly IIdentityRepository _identities;

    public FileService(IIdentityRepository identities)
    {
        _identities = identities;
    }

    public async Task UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default)
    {
    }
}
