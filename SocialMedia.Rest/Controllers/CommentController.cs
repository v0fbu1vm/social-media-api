using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Comment;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        #region GetCommentsAsync
        /// <summary>
        /// An action for getting a list of comments, commented by the authenticated user.
        /// </summary>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync()
        {
            return Ok(await _service.GetCommentsAsync());
        }
        #endregion

        #region GetCommentsForPostAsync
        /// <summary>
        /// An action for getting a list of comments, commented on a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="amount">Represents the amount of comments that should be include.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetCommentsForPostAsync(string postId, int amount)
        {
            return Ok(await _service.GetCommentsForPostAsync(postId, amount));
        }
        #endregion

        #region GetCommentAsync
        /// <summary>
        /// An action for getting a comment by id.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentAsync(string id)
        {
            var result = await _service.GetCommentByIdAsync(id);
            
            return result != null ? Ok(result) : NotFound();
        }
        #endregion

        #region CommentAsync
        /// <summary>
        /// An action for commenting on a post.
        /// </summary>
        /// <param name="request">Represents the required data for commenting on a post.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CommentAsync([FromBody] CreateCommentRequest request)
        {
            var result = await _service.CommentAsync(request);

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
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region UpdateCommentAsync
        /// <summary>
        /// An action for updating a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <param name="request">Represents the required data for updating a comment.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentAsync(string id, [FromBody] UpdateCommentRequest request)
        {
            var result = await _service.UpdateCommentAsync(id, request);

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

        #region DeleteCommentAsync
        /// <summary>
        /// An action for deleting a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentAsync(string id)
        {
            var result = await _service.DeleteCommentAsync(id);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
