using HotChocolate.AspNetCore.Authorization;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Objects;

namespace SocialMedia.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class FollowerMutations
    {
        #region FollowAsync
        /// <summary>
        /// Used for following a user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <param name="service">A service for <see cref="SocialMedia.Core.Entities.Follower"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{Follower}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<Follower>> FollowAsync(string userId, [Service] IFollowerService service)
        {
            var result = await service.FollowAsync(userId);

            if (result.Succeeded)
            {
                return Response<Follower>.Created(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => Response<Follower>.NotFound(result.Fault.ErrorMessage),
                _ => Response<Follower>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region UnFollowAsync
        /// <summary>
        /// Used for unfollowing a user.
        /// </summary>
        /// <param name="userId">Represents the id of the user.</param>
        /// <param name="service">A service for <see cref="SocialMedia.Core.Entities.Follower"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{bool}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<bool>> UnFollowAsync(string userId, [Service] IFollowerService service)
        {
            var result = await service.UnFollowAsync(userId);

            if (result.Succeeded)
            {
                return Response<bool>.NoContent(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => Response<bool>.NotFound(result.Fault.ErrorMessage),
                _ => Response<bool>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
