﻿using Heartify.Core.Attributes;
using Heartify.Core.Models.Gender;
using Heartify.Core.Models.Relationship;
using System.ComponentModel.DataAnnotations;
using static Heartify.Infrastructure.Constants.ValidationConstants;

namespace Heartify.Core.Models.PersonProfile
{
    /// <summary>
    /// Person Profile Data Transfer Model
    /// </summary>
    public class PersonProfileFormModel
    {
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
        [IsAdult(18, 99, ErrorMessage = "Your age must be between 18 and 99!")]
        public string DateOfBirth { get; set; } = string.Empty;

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

        /*[Required(ErrorMessage = RequiredErrorMessage)]
        public byte[] ProfilePicture { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public byte[] UsernamePicture { get; set; } = null!;

        [Required(ErrorMessage = RequiredErrorMessage)]
        public byte[] RandomPicture { get; set; } = null!;*/

        public IEnumerable<GenderViewModel> Genders { get; set; } = new List<GenderViewModel>();
        public IEnumerable<RelationshipViewModel> Relationships { get; set; } = new List<RelationshipViewModel>();
    }
}
