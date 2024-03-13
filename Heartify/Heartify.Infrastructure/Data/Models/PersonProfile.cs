using Heartify.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Heartify.Infrastructure.Constants.ValidationConstants;


namespace HeartifyDating.Infrastructure.Data.Models
{
    [Comment("Person Profiles Table")]
    public class PersonProfile
    {
        [Key]
        [Comment("Person Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(NamesMaxLength)]
        [Comment("Person First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(NamesMaxLength)]
        [Comment("Person Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Comment("Person Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        [Comment("Person Sexual Orientation")]
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; } = null!;

        [Required]
        public int WantedGenderId { get; set; }

        [Required]
        [Comment("Seuxal Orientation of Wanted Person")]
        [ForeignKey(nameof(WantedGenderId))]
        public Gender WantedGender { get; set; } = null!;

        [Required]
        public int RelationshipId { get; set; }

        [Required]
        [Comment("Wanted Relationship Type")]
        [ForeignKey(nameof(RelationshipId))]
        public Relationship Relationship { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Person Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Person Profile Picture")]
        public byte[] ProfilePicture { get; set; } = null!;

        [Required]
        [Comment("Person Username Picture")]
        public byte[] UsernamePicture { get; set; } = null!;

        [Required]
        [Comment("Person Random Picture")]
        public byte[] RandomPicture { get; set; } = null!;

		[Required]
		public string DaterId { get; set; } = string.Empty;

        [Required]
		[ForeignKey(nameof(DaterId))]
		public IdentityUser Dater { get; set; } = null!;
	}
}
