using Microsoft.AspNetCore.Http;

namespace SocialMedia.Core.Extensions
{
    public static class FileExtensions
    {
        public static string GetContentType(this IFormFile formFile)
        {
            var charSequence = formFile.ContentType.Split('/')
                .Last()
                .Prepend('.');

            return new string(charSequence.ToArray());
        }
    }
}
