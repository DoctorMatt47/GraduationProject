namespace GraduationProject.Application.Files;

public record FileRecordResponse(
    string Path,
    long SizeInBytes,
    DateTimeOffset UploadedAt);

public record UploadFileRequest(
    MemoryStream File,
    string Path);

public record UploadDirectoryRequest(string Path);
