using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using GraduationProject.Application.Files;
using GraduationProject.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraduationProject.Infrastructure.Files;

public class FileS3Repository : IFileRepository
{
    private readonly ILogger<FileS3Repository> _logger;
    private readonly IAmazonS3 _s3Client;
    private readonly S3Options _s3Options;

    public FileS3Repository(IAmazonS3 s3Client, IOptions<S3Options> s3Options, ILogger<FileS3Repository> logger)
    {
        _s3Client = s3Client;
        _logger = logger;
        _s3Options = s3Options.Value;
    }

    public async Task<Stream> GetFile(string path, CancellationToken cancellationToken = default)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = _s3Options.BucketName,
            Key = path,
        };

        try
        {
            var response = await _s3Client.GetObjectAsync(getObjectRequest, cancellationToken);
            return response.ResponseStream;
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError("Error getting file from S3: {EMessage}", e.Message);
            throw;
        }
    }

    public async Task UploadFile(FileObject file, CancellationToken cancellationToken = default)
    {
        using var fileTransferUtility = new TransferUtility(_s3Client);

        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = file.File,
            Key = file.Path,
            BucketName = _s3Options.BucketName,
            CannedACL = S3CannedACL.NoACL,
        };

        try
        {
            await fileTransferUtility.UploadAsync(uploadRequest, cancellationToken);
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError("Error uploading file to S3: {EMessage}", e.Message);
            throw;
        }
    }

    public async Task DeleteFile(string path, CancellationToken cancellationToken = default)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = _s3Options.BucketName,
            Key = path,
        };

        try
        {
            await _s3Client.DeleteObjectAsync(deleteObjectRequest, cancellationToken);
        }
        catch (AmazonS3Exception e)
        {
            _logger.LogError("Error deleting file from S3: {EMessage}", e.Message);
            throw;
        }
    }
}
