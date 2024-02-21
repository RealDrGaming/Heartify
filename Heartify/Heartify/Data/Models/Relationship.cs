using Heartify.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Heartify.Data.Models
{
    public class Relationship
    {
        [Key]
        [Comment("Relationship Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.RelationshipTypeMaxLength)]
        [Comment("Relationship Type")]
        public string RelationshipType { get; set; } = string.Empty;
    }
}