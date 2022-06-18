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

        #region NameMust
        /// <summary>
        /// Checks whether name contains letters only.
        /// </summary>
        /// <param name="name">Represents a name.</param>
        /// <returns>
        /// <see langword="true"/> if the name only consists of letters,
        /// otherwise <see langword="false"/>.
        /// </returns>
        private bool NameMust(string name)
        {
            return name.All(c => char.IsLetter(c));
        }
        #endregion
    }
}
