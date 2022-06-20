using FluentValidation;

namespace SocialMedia.Core.Models.Comment
{
    /// <summary>
    /// A validator for <see cref="CreateCommentRequest"/> to see whether correct data has been given.
    /// </summary>
    public class CreateCommentValidator : AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentValidator()
        {
            RuleFor(instance => instance.PostId)
                .Must(id => Guid.TryParse(id, out _));

            RuleFor(instance => instance.Comment)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}
