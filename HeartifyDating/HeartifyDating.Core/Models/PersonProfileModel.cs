using System.ComponentModel.DataAnnotations;
using static HeartifyDating.Infrastructure.Constants.ValidationConstants;

namespace HeartifyDating.Core.Models
{
    /// <summary>
    /// Person Profile Data Transfer Model
    /// </summary>
    public class PersonProfileModel
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
        public string FirstName { get; set; }

        /// <summary>
        /// Person Last Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string LastName { get; set; }

        /// <summary>
        /// Person Age
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinAge, MinAge, ErrorMessage = AgeIsntInRangeErrorMessage)]
        public int Age { get; set; }

        /// <summary>
        /// Person Gender
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GenderMaxLength, MinimumLength = GenderMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Gender { get; set; }

        /// <summary>
        /// Gender wanted by Person
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GenderMaxLength, MinimumLength = GenderMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string WantedGender { get; set; }

        /// <summary>
        /// Relationship type wanted by Person
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RelationshipTypeMaxLength, MinimumLength = RelationshipTypeMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string RelationshipType { get; set; }

        /// <summary>
        /// Person Description
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string ProfileImage { get; set; } //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string UsernamePicture { get; set; } //MAKE IMAGE

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string RandomPicture { get; set; } //MAKE IMAGE
    }
}
