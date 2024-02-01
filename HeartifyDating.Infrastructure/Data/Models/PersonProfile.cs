using static HeartifyDating.Infrastructure.Constants.ValidationConstants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace HeartifyDating.Infrastructure.Data.Models
{
    public class PersonProfile
    {
        [Key]
        [Comment("Person Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(NamesMaxLength)]
        [Comment("Person First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(NamesMaxLength)]
        [Comment("Person Last Name")]
        public string LastName { get; set; }

        [Required]
        [Comment("Person Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(GenderMaxLength)]
        [Comment("Person Sexual Orientation")]
        public string Gender { get; set; }

        [Required]
        [StringLength(GenderMaxLength)]
        [Comment("Seuxal Orientation of Wanted Person")]
        public string WantedGender { get; set; }

        [Required]
        [StringLength(RelationshipTypeMaxLength)]
        [Comment("Wanted Relationship Type")]
        public string RelationshipType { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("Person Description")]
        public string Description { get; set;}

        [Required]
        [Comment("Person Profile Picture")] //MAKE IMAGE
        public string ProfileImage { get; set; }

        [Required]
        [Comment("Person Username Picture")] //MAKE IMAGE
        public string UsernamePicture { get; set; }
        [Required]
        [Comment("Person Random Picture")] //MAKE IMAGE
        public string RandomPicture { get; set; }
    }
}
