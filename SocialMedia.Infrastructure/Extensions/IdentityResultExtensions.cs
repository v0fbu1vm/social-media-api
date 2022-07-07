using Microsoft.AspNetCore.Identity;
using System.Text;

namespace SocialMedia.Infrastructure.Extensions
{
    public static class IdentityResultExtensions
    {
        /// <summary>
        /// Converts errors from <see cref="IdentityResult"/> to a <see langword="string"/>.
        /// </summary>
        /// <param name="result">Represents the result of an identity operation.</param>
        /// <returns>
        /// All errors as a <see langword="string"/>.
        /// </returns>
        public static string ErrorMessage(this IdentityResult result)
        {
            var errorMessage = new StringBuilder();
            foreach (var item in result.Errors)
            {
                errorMessage.AppendLine(item.Description);
            }

            return errorMessage.ToString();
        }
    }
}