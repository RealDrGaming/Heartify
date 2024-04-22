using System.ComponentModel.DataAnnotations;
using static Heartify.Infrastructure.Data.Constants.ValidationConstants;

namespace Heartify.Core.Models.Gender
{
    /// <summary>
    /// Gender View Model
    /// </summary>
    public class GenderViewModel
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
        [StringLength(GenderMaxLength, MinimumLength = GenderMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string GenderName { get; set; } = string.Empty;
    }
}
