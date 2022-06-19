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

        #region GetPostAsync
        /// <summary>
        /// An action for getting a post.
        /// </summary>
        /// <param name="id">Represents the id of the post.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostAsync(string id)
        {
            var result = await _service.GetPostByIdAsync(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Post could not be found.");
        }
        #endregion

        #region GetPostContentAsync
        /// <summary>
        /// An action for getting the content of a post.
        /// </summary>
        /// <param name="fileName">Represents the name of the file.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetPostContentAsync(string fileName)
        {
            var result = await _service.GetPostContentAsync(fileName);

            if (result != null)
            {
                return Ok(result.FileStream);
            }

            return NotFound();
        }
        #endregion

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

        #region UpdatePostAsync
        /// <summary>
        /// An action for updating a post.
        /// </summary>
        /// <param name="id">Represents the id of the post.</param>
        /// <param name="request">Represents the required data for updating a post.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync(string id, [FromBody] UpdatePostRequest request)
        {
            var result = await _service.UpdatePostAsync(id, request);

            if (result.Succeeded)
            {
                return Ok(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region DeletePostAsync
        /// <summary>
        /// An action for deleting a post.
        /// </summary>
        /// <param name="id">Represents the id of the post.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostAsync(string id)
        {
            var result = await _service.DeletePostAsync(id);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.Problem => Problem(result.Fault.ErrorMessage),
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
