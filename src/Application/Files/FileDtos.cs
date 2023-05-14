namespace GraduationProject.Application.Files;

public record UploadFileRequest(
    MemoryStream File,
    string FileName,
    string Extension,
    string Path);
