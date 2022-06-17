using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Rest.Models;
using AutoMapper.QueryableExtensions;

namespace SocialMedia.Rest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerService _service;
        private readonly IMapper _mapper;

        public FollowerController(IFollowerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region FollowAsync
        /// <summary>
        /// An action for following a user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpPost("{userId}")]
        public async Task<IActionResult> FollowAsync(string userId)
        {
            var result = await _service.FollowAsync(userId);

            if (result.Succeeded)
            {
                return new ObjectResult(_mapper.Map<FollowerItem>(result.Value))
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Fault.ErrorMessage),
                _ => BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion;

        #region GetFolloweeAsync
        /// <summary>
        /// Gets a <see cref="Follower"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFolloweeAsync(string userId)
        {
            var result = await _service.GetFolloweeAsync(userId);

            return result != null ? Ok(_mapper.Map<FollowerItem>(result)) : NotFound();
        }
        #endregion

        #region GetFollowerAsync
        /// <summary>
        /// Gets a <see cref="Follower"/>.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFollowerAsync(string userId)
        {
            var result = await _service.GetFollowerAsync(userId);

            return result != null ? Ok(_mapper.Map<FollowerItem>(result)) : NotFound();
        }
        #endregion

        #region GetFollowers
        /// <summary>
        /// Gets a list of <see cref="Follower"/>'s.
        /// </summary>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet]
        public IActionResult GetFollowers()
        {
            return Ok(_service.GetFollowers().ProjectTo<FollowerItem>(_mapper.ConfigurationProvider));
        }
        #endregion

        #region GetFollowing
        /// <summary>
        /// Gets a list of <see cref="Follower"/>'s.
        /// </summary>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpGet]
        public IActionResult GetFollowing()
        {
            return Ok(_service.GetFollowing().ProjectTo<FollowerItem>(_mapper.ConfigurationProvider));
        }
        #endregion

        #region UnFollowAsync
        /// <summary>
        /// An action for unfollowing a user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <returns>
        /// An <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>,
        /// containing details about the operation.
        /// </returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> UnFollowAsync(string userId)
        {
            var result = await _service.UnFollowAsync(userId);

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
