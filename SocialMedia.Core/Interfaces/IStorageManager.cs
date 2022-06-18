using Microsoft.AspNetCore.Http;

namespace SocialMedia.Core.Interfaces
{
    /// <summary>
    /// An interface for storage related operations.
    /// </summary>
    public interface IStorageManager
    {
        /// <summary>
        /// For uploading a file to storage.
        /// </summary>
        /// <param name="formFile">Represents a file sent with the HttpRequest.</param>
        /// <param name="fileName">Represents the name of the file.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see langword="string"/> that represents the file name.
        /// </returns>
        public Task<string> UploadAsync(IFormFile formFile, string fileName = "");
        /// <summary>
        /// For deleting a file from storage.
        /// </summary>
        /// <param name="fileName">Represents the name of the file.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// </returns>
        public Task DeleteAsync(string fileName);
    }
}
