using Heartify.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Heartify.Constants.ValidationConstants;


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
        [Comment("Person Age")]
        public int Age { get; set; }

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
        [StringLength(RelationshipTypeMaxLength)]
        [Comment("Wanted Relationship Type")]
        public string RelationshipType { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Person Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Person Profile Picture")] //MAKE IMAGE
        public string ProfileImage { get; set; } = string.Empty;

        [Required]
        [Comment("Person Username Picture")] //MAKE IMAGE
        public string UsernamePicture { get; set; } = string.Empty;
        [Required]
        [Comment("Person Random Picture")] //MAKE IMAGE
        public string RandomPicture { get; set; } = string.Empty;
    }
}
