using GraduationProject.Application.Files;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

public class FilesController : ApiControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task UploadFile(CancellationToken cancellationToken)
    {
        await _fileService.UploadFile(null, cancellationToken);
    }
}
