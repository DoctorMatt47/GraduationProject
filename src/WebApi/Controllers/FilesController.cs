using GraduationProject.Application.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

public class FilesController : ApiControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService) => _fileService = fileService;

    [HttpPost]
    public async Task UploadFile(IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);
        
        var request = new UploadFileRequest(stream, file.Length, file.Name);
        await _fileService.UploadFile(request, cancellationToken);
    }
}
