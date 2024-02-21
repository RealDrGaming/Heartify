using Heartify.Models;
using System.ComponentModel.DataAnnotations;
using static Heartify.Constants.ValidationConstants;

namespace HeartifyDating.Core.Models
{
    /// <summary>
    /// Person Profile Data Transfer Model
    /// </summary>
    public class PersonProfileFormModel
    {
        /// <summary>
        /// Person Profile Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Person First Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Person Last Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Person Age
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinAge, MaxAge, ErrorMessage = AgeIsntInRangeErrorMessage)]
        public int Age { get; set; }

        /// <summary>
        /// Person Gender
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int GenderId { get; set; }

        /// <summary>
        /// Gender wanted by Person
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int WantedGenderId { get; set; }

        /// <summary>
        /// Relationship type wanted by Person
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int RelationshipId { get; set; }

        /// <summary>
        /// Person Description
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ProfileImage { get; set; } = string.Empty; //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string UsernamePicture { get; set; } = string.Empty; //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RandomPicture { get; set; } = string.Empty; //MAKE IMAGE

        public IEnumerable<GenderViewModel> Genders { get; set; } = new List<GenderViewModel>();

        public IEnumerable<RelationshipViewModel> Relationships { get; set; } = new List<RelationshipViewModel>();
    }
}
