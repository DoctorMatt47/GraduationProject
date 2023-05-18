namespace GraduationProject.Application.Files;

public record FileResponse(
    Stream File,
    string Path);

public record FileRecordResponse(
    string Path,
    long SizeInBytes);

public record UploadFileRequest(
    MemoryStream File,
    long SizeInBytes,
    string Path);
