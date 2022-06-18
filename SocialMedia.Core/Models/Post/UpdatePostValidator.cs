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
            RuleFor(options => options.Id)
                .Must(id => Guid.TryParse(id, out _));

            RuleFor(options => options.Caption)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255)
                .When(instance => instance.Description == null);

            RuleFor(options => options.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(280)
                .When(instance => instance.Caption == null);
        }
    }
}
