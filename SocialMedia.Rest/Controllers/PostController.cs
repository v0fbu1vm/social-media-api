using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Post;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        #region PostAsync
        /// <summary>
        /// An action for posting.
        /// </summary>
        /// <param name="request">Represents the required data for posting.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] CreatePostRequest request)
        {
            var result = await _service.PostAsync(request);

            if (result.Succeeded)
            {
                return new ObjectResult(result.Value)
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.Problem => Problem(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
