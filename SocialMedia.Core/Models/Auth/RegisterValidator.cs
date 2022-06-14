using FluentValidation;

namespace SocialMedia.Core.Models.Auth
{
    /// <summary>
    /// A validator for <see cref="RegisterRequest"/> to see whether correct data has been given.
    /// </summary>
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(instance => instance.FirstName)
                .NotEmpty()
                .Length(2, 30)
                .Must(NameMust);

            RuleFor(instance => instance.LastName)
                .NotEmpty()
                .Length(2, 30)
                .Must(NameMust);

            RuleFor(instance => instance.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(instance => instance.Password)
                .NotEmpty()
                .Length(8, 20)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$");

        }

        private bool NameMust(string name)
        {
            return name.All(c => char.IsLetter(c));
        }
    }
}
