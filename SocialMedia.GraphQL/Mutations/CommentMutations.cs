using HotChocolate.AspNetCore.Authorization;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enums;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Models.Comment;
using SocialMedia.Core.Objects;

namespace SocialMedia.GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CommentMutations
    {
        #region CommentAsync

        /// <summary>
        /// Used for commenting on a post.
        /// </summary>
        /// <param name="request">Represents the required data for commenting on a post.</param>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{Comment}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<Comment>> CommentAsync(CreateCommentRequest request, [Service] ICommentService service)
        {
            var result = await service.CommentAsync(request);

            if (result.Succeeded)
            {
                return Response<Comment>.Created(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.Problem => Response<Comment>.Problem(result.Fault.ErrorMessage),
                ErrorType.NotFound => Response<Comment>.NotFound(result.Fault.ErrorMessage),
                _ => Response<Comment>.BadRequest(result.Fault.ErrorMessage)
            };
        }

        #endregion CommentAsync

        #region UpdateCommentAsync

        /// <summary>
        /// Used for updating a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <param name="request">Represents the required data for updating a comment.</param>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{Comment}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<Comment>> UpdateCommentAsync(string id, UpdateCommentRequest request, [Service] ICommentService service)
        {
            var result = await service.UpdateCommentAsync(id, request);

            if (result.Succeeded)
            {
                return Response<Comment>.Ok(result.Value);
            }

            return result.Fault.ErrorType switch
            {
                ErrorType.NotFound => Response<Comment>.NotFound(result.Fault.ErrorMessage),
                _ => Response<Comment>.BadRequest(result.Fault.ErrorMessage)
            };
        }

        #endregion UpdateCommentAsync

        #region DeleteCommentAsync

        /// <summary>
        /// Used for deleting a comment.
        /// </summary>
        /// <param name="id">Represents the id of the comment.</param>
        /// <param name="service">A service for <see cref="Comment"/> related operations.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation.
        /// A <see cref="Response{bool}"/>, containing detailes of operation.
        /// </returns>
        [Authorize]
        public async Task<Response<bool>> DeleteCommentAsync(string id, [Service] ICommentService service)
        {
            var result = await service.DeleteCommentAsync(id);

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

        #endregion DeleteCommentAsync
    }
}