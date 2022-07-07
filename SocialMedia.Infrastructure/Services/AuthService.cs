using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Extensions;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Auth;
using SocialMedia.Core.Objects;
using SocialMedia.Infrastructure.Extensions;

namespace SocialMedia.Infrastructure.Services
{
    /// <summary>
    /// A service for authentication related operation.
    /// </summary>
    public class AuthService : IDisposable, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenProvider;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenProvider = tokenProvider;
        }

        #region RegisterAsync

        /// <inheritdoc cref="IAuthService.RegisterAsync(RegisterRequest)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<bool>> RegisterAsync(RegisterRequest request)
        {
            var validator = new RegisterValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var newUser = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    UserName = request.Email.RemoveSpecialCharacters()
                };

                var result = await _userManager.CreateAsync(newUser, request.Password);

                return result.Succeeded ? Result<bool>.Success(true)
                    : Result<bool>.Failure(ErrorType.BadRequest, result.ErrorMessage());
            }

            return Result<bool>.Failure(ErrorType.BadRequest, validationResult.ErrorMessage());
        }

        #endregion RegisterAsync

        #region SignInAsync

        /// <inheritdoc cref="IAuthService.SignInAsync(LoginRequest)"/>
        /// <remarks>
        /// May produce the following errors.
        /// <list type="bullet">
        /// <item><see cref="ErrorType.PartialSuccess"/></item>
        /// <item><see cref="ErrorType.BadRequest"/></item>
        /// <item><see cref="ErrorType.Unauthorized"/></item>
        /// <item><see cref="ErrorType.NotFound"/></item>
        /// </list>
        /// </remarks>
        public async Task<Result<LoginResponse>> SignInAsync(LoginRequest request)
        {
            var validator = new LoginValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                    if (result.Succeeded)
                    {
                        if (user.EmailConfirmed)
                        {
                            return Result<LoginResponse>.Success(new LoginResponse()
                            {
                                Token = _tokenProvider.GenerateToken(user),
                                User = user
                            });
                        }

                        return Result<LoginResponse>.Failure(ErrorType.PartialSuccess, "Email not confirmed.");
                    }

                    return Result<LoginResponse>.Failure(ErrorType.Unauthorized, "Authentication failed.");
                }

                return Result<LoginResponse>.Failure(ErrorType.NotFound, "User not found.");
            }

            return Result<LoginResponse>.Failure(ErrorType.BadRequest, validationResult.ErrorMessage());
        }

        #endregion SignInAsync

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _userManager.Dispose();
        }
    }
}