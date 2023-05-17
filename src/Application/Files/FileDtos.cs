namespace GraduationProject.Application.Files;

public record UploadFileRequest(
    MemoryStream File,
    long SizeInBytes,
    string Path);
