using System.ComponentModel.DataAnnotations;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Core.Models.PersonProfile
{
    /// <summary>
    /// Delete Fnfo of Profile View Model
    /// </summary>
    public class DeleteShowInfoPersonProfileModel
    {
        /// <summary>
        /// Delete Info View Model identification
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        /// <summary>
        /// First Name of Profile
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string FirstName { get; set; } = string.Empty;
    }
}
