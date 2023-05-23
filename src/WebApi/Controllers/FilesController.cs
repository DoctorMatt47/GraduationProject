using System.Net;
using System.Net.Http.Headers;
using GraduationProject.Application.Files;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.WebApi.Controllers;

public class FilesController : ApiControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService) => _fileService = fileService;

    [HttpPost("{path}")]
    public async Task UploadFile(string path, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);

        var request = new UploadFileRequest(
            stream,
            Path.Combine(path, file.FileName)
                .Replace("\\", "/")
                .Replace("%2F", "/"));
        
        await _fileService.UploadFile(request, cancellationToken);
    }
    
    [HttpGet("{path}")]
    public async Task<IActionResult> DownloadFile(string path, CancellationToken cancellationToken)
    {
        var filteredPath = path.Replace("%2F", "/");
        var fileStream = await _fileService.DownloadFile(filteredPath, cancellationToken);

        return File(fileStream, "application/octet-stream", filteredPath.Split("/").Last());
    }
    
    [HttpGet]
    public async Task<IEnumerable<FileRecordResponse>> GetFileRecords(CancellationToken cancellationToken)
    {
        return await _fileService.GetFileRecords(cancellationToken);
    }
}
