using Heartify.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using static Heartify.Infrastructure.Constants.ValidationConstants;

namespace Heartify.Core.Models.PersonProfile
{
    /// <summary>
    /// Person Profile View Model
    /// </summary>
    public class PersonProfileInfoViewModel
    {
        public PersonProfileInfoViewModel(
            int id,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string gender,
            string wantedGender,
            string relationship,
            string description)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.ToString(DateFormat);
            Gender = gender;
            WantedGender = wantedGender;
            Relationship = relationship;
            Description = description;
        }

        /// <summary>
        /// Person Profile View Model Identification
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public int Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Date of Birth
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        public string DateOfBirth { get; set; } = string.Empty;

        /// <summary>
        /// Gender Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GenderMaxLength, MinimumLength = GenderMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Gender { get; set; }

        /// <summary>
        /// Wanted Gender Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(GenderMaxLength, MinimumLength = GenderMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string WantedGender { get; set; }

        /// <summary>
        /// Relationship Name
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(RelationshipTypeMaxLength, MinimumLength = RelationshipTypeMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Relationship { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMaxLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = string.Empty;
    }
}