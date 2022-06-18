using FluentValidation;

namespace SocialMedia.Core.Models.Post
{
    /// <summary>
    /// A validator for <see cref="UpdatePostRequest"/> to see whether correct data has been given.
    /// </summary>
    public class UpdatePostValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostValidator()
        {
            RuleFor(instance => instance.Id)
                .Must(id => Guid.TryParse(id, out _));

            RuleFor(instance => instance.Caption)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255)
                .When(instance => instance.Description == null);

            RuleFor(instance => instance.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(280)
                .When(instance => instance.Caption == null);
        }
    }
}
