using Heartify.Constants;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Heartify.Data.Models
{
    [Comment("Relationships users want")]
    public class Relationship
    {
        [Key]
        [Comment("Relationship Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.RelationshipTypeMaxLength)]
        [Comment("Relationship Type")]
        public string RelationshipType { get; set; } = string.Empty;

        public IList<PersonProfile> PersonProfiles { get; set; } = new List<PersonProfile>();
    }
}