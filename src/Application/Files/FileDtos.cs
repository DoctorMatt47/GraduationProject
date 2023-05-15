namespace GraduationProject.Application.Files;

public record UploadFileRequest(
    MemoryStream File,
    string Path);
