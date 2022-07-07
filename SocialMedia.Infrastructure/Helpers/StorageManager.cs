using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Extensions;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Infrastructure.Helpers
{
    /// <summary>
    /// A service for storage related operations.
    /// </summary>
    public class StorageManager : IStorageManager
    {
        private readonly BlobContainerClient _containerClient;

        public StorageManager(BlobServiceClient serviceClient)
        {
            _containerClient = serviceClient.GetBlobContainerClient(AppSettings.AzureBlobStorageContainer);
        }

        #region DownloadFileAsync

        /// <inheritdoc cref="IStorageManager.DownloadFileAsync(string)"/>
        public async Task<FileStreamResult?> DownloadFileAsync(string fileName)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);

            if (blobClient == null)
                return null;

            var file = await blobClient.DownloadStreamingAsync();
            return new FileStreamResult(file.Value.Content, file.Value.Details.ContentType);
        }

        #endregion DownloadFileAsync

        #region DeleteAsync

        /// <inheritdoc cref="IStorageManager.DeleteAsync(string)"/>
        public async Task DeleteAsync(string fileName)
        {
            if (!Guid.TryParse(fileName.Split('.').First(), out _))
                return;

            var blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        #endregion DeleteAsync

        #region UploadAsync

        /// <inheritdoc cref="IStorageManager.UploadAsync(IFormFile, string)"/>
        public async Task<string> UploadAsync(IFormFile formFile, string fileName = "")
        {
            if (!Guid.TryParse(fileName, out _))
                fileName = Guid.NewGuid().ToString();

            fileName += formFile.GetContentType();

            var blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(formFile.OpenReadStream());
            return fileName;
        }

        #endregion UploadAsync
    }
}