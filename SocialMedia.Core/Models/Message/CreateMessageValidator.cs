using FluentValidation;

namespace SocialMedia.Core.Models.Message
{
    /// <summary>
    /// A validator for <see cref="CreateMessageRequest"/> to see whether correct data has been given.
    /// </summary>
    public class CreateMessageValidator : AbstractValidator<CreateMessageRequest>
    {
        public CreateMessageValidator()
        {
            RuleFor(options => options.RecipientId)
                .Must(id => Guid.TryParse(id, out _));

            RuleFor(options => options.Message)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}