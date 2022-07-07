using FluentValidation;

namespace SocialMedia.Core.Models.Comment
{
    /// <summary>
    /// A validator for <see cref="UpdateCommentRequest"/> to see whether correct data has been given.
    /// </summary>
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentRequest>
    {
        public UpdateCommentValidator()
        {
            RuleFor(instance => instance.Id)
                .Must(id => Guid.TryParse(id, out _));

            RuleFor(instance => instance.Comment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}