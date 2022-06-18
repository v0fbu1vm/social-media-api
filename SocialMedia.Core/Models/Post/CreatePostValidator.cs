using FluentValidation;
using Microsoft.AspNetCore.Http;
using SocialMedia.Core.Extensions;

namespace SocialMedia.Core.Models.Post
{
    /// <summary>
    /// A validator for <see cref="CreatePostRequest"/> to see whether correct data has been given.
    /// </summary>
    public class CreatePostValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostValidator()
        {
            RuleFor(instance => instance.Caption)
                .MaximumLength(255);

            RuleFor(instance => instance.Description)
                .MaximumLength(280);

            RuleFor(instance => instance.File)
                .NotNull()
                .Must(IsValidContentType)
                .WithMessage("File type not allowed. Only (.png, .jpg, .mp4) are allowed.");
        }

        #region IsValidContentType
        /// <summary>
        /// Checks whether or not a correct file is been given.
        /// </summary>
        /// <param name="file">Represents the file.</param>
        /// <returns>
        /// <see langword="true"/> if it's valid, otherwise <see langword="false"/>.
        /// </returns>
        private bool IsValidContentType(IFormFile file)
        {
            string[] allowedContentTypes = new string[]
            {
                ".png",
                ".jpg",
                ".mp4"
            };

            var type = file.GetContentType();

            foreach (var allowedContentType in allowedContentTypes)
            {
                return type.EndsWith(allowedContentType);
            }

            return false;
        }
        #endregion
    }
}
