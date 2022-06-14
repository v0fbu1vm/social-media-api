using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Objects
{
    /// <summary>
    /// Represents a model which can be used to provide detailes about an operation,
    /// incase of failure.
    /// </summary>
    public class ResultFailure
    {
        /// <summary>
        /// Represents an error type.
        /// </summary>
        public ErrorType ErrorType { get; set; } = default!;
        /// <summary>
        /// Represents an error message.
        /// </summary>
        public string ErrorMessage { get; set; } = default!;
    }
}
