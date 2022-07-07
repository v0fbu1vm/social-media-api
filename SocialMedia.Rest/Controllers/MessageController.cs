using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        #region GetMessageAsync

        /// <summary>
        /// An action for getting a message by id.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageAsync(string id)
        {
            var message = await _service.GetMessageByIdAsync(id);

            return message != null ? Ok(message) : NotFound();
        }

        #endregion GetMessageAsync

        #region GetMessagesSentToAsync

        /// <summary>
        /// An action for getting a list of messages sent to a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of a user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesSentToAsync(string userId)
        {
            return Ok(await _service.GetMessagesSentToAsync(userId));
        }

        #endregion GetMessagesSentToAsync

        #region GetMessagesReceivedFromAsync

        /// <summary>
        /// An action for getting a list of messages received from a specified user.
        /// </summary>
        /// <param name="userId">Represents the id of a user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesReceivedFromAsync(string userId)
        {
            return Ok(await _service.GetMessagesReceivedFromAsync(userId));
        }

        #endregion GetMessagesReceivedFromAsync

        #region DeleteMessageAsync

        /// <summary>
        /// An action for deleting a message.
        /// </summary>
        /// <param name="id">Represents the id of the message.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageAsync(string id)
        {
            var result = await _service.DeleteMessageAsync(id);

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

        #endregion DeleteMessageAsync
    }
}