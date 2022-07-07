using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Core.Entities
{
    /// <summary>
    /// Represents a unique entity that holds common properties
    /// shared between different entities.
    /// </summary>
    public abstract class AbstractEntity
    {
        /// <summary>
        /// Represents a unique identifier.
        /// </summary>
        [Required]
        [MaxLength(450)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Represents when a record was added to the system.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Represents when a record was modified.
        /// </summary>
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
    }
}