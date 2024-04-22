using System.ComponentModel.DataAnnotations;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Core.Models.Relationship
{
    /// <summary>
    /// Gender View Model
    /// </summary>
    public class RelationshipViewModel
    {
        /// <summary>
        /// Gender Identification
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        /// <summary>
        /// The Gender name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RelationshipTypeMaxLength, MinimumLength = RelationshipTypeMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string RelationshipType { get; set; } = string.Empty;
    }
}
