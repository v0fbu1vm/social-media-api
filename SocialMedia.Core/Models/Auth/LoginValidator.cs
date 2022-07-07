using FluentValidation;

namespace SocialMedia.Core.Models.Auth
{
    /// <summary>
    /// A validator for <see cref="LoginRequest"/> to see whether correct data has been given.
    /// </summary>
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(instance => instance.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(instance => instance.Password)
                .NotEmpty()
                .Length(8, 20)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$");
        }
    }
}