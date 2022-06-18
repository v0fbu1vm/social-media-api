using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Auth;
using SocialMedia.Core.Models;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;

        public AuthController(IAuthService authService, IUserService userService, IEmailSender emailSender)
        {
            _authService = authService;
            _userService = userService;
            _emailSender = emailSender;
        }

        #region SignInAsync
        /// <summary>
        /// An action for authenticating a user.
        /// </summary>
        /// <param name="request">Represents the required data for authenticating a user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> SignInAsync([FromBody] LoginRequest request)
        {
            var result = await _authService.SignInAsync(request);

            if (result.Succeeded)
            {
                return Ok(result.Value);
            }

            if (result.Fault.ErrorType == ErrorType.PartialSuccess)
            {
                await SendEmailConfirmationTokenAsync(request.Email);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.PartialSuccess => Ok("Email not confirmed, an email confirmation link has been sent."),
                ErrorType.Unauthorized => Unauthorized(result.Fault.ErrorMessage),
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region RegisterAsync
        /// <summary>
        /// An action for registering a user.
        /// </summary>
        /// <param name="request">Represents the required data for registering a user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation. 
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if (result.Succeeded)
            {
                await SendEmailConfirmationTokenAsync(request.Email);

                return new ObjectResult("Account successfully created. An email confirmation link has been sent.")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

            return BadRequest(result.Fault.ErrorMessage);
        }
        #endregion

        #region SendEmailConfirmationTokenAsync
        /// <summary>
        /// Used for sending an email confirmation token to a specified user. 
        /// </summary>
        /// <param name="userEmail">Represents the email of the user.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// </returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task SendEmailConfirmationTokenAsync(string userEmail)
        {
            var emailConfirmationToken = await _userService.GenerateEmailConfirmationTokenAsync(userEmail);

            if (emailConfirmationToken != null)
            {
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = emailConfirmationToken.User.Id,
                    token = emailConfirmationToken.Token
                },
                protocol: Request.Scheme);

                var mailMessage = new MailMessage(userEmail)
                {
                    Subject = "Confirm Email",
                    Body = $"Please Confirm your account by clicking this link: {callbackUrl}"
                };

                await _emailSender.SendEmailAsync(mailMessage);
            }
        }
        #endregion
    }
}
