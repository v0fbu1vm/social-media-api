using HotChocolate.AspNetCore.Authorization;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Post;
using SocialMedia.Core.Objects;

namespace SocialMedia.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PostMutations
    {
        #region UpdatePostAsync
        /// <summary>
        /// Used for updating a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="request">Represents the required data for updating a post.</param>
        /// <param name="service">A service for <see cref="Post"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{Post}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<Post>> UpdatePostAsync(string postId, UpdatePostRequest request, [Service] IPostService service)
        {
            var result = await service.UpdatePostAsync(postId, request);

            if(result.Succeeded)
            {
                return Response<Post>.Ok(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => Response<Post>.NotFound(result.Fault.ErrorMessage),
                _ => Response<Post>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion

        #region DeletePostAsync
        /// <summary>
        /// Used for deleting a post.
        /// </summary>
        /// <param name="postId">Represents the id of the post.</param>
        /// <param name="service">A service for <see cref="Post"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{bool}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<bool>> DeletePostAsync(string postId, [Service] IPostService service)
        {
            var result = await service.DeletePostAsync(postId);

            if (result.Succeeded)
            {
                return Response<bool>.NoContent(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.Problem => Response<bool>.Problem(result.Fault.ErrorMessage),
                ErrorType.NotFound => Response<bool>.NotFound(result.Fault.ErrorMessage),
                _ => Response<bool>.BadRequest(result.Fault.ErrorMessage)
            };
        }
        #endregion
    }
}
