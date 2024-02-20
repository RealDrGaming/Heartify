using Heartify.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Heartify.Data.Models
{
    public class Gender
    {
        [Key]
        [Comment("Gender Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.GenderMaxLength)]
        [Comment("Gender Name")]
        public string GenderName { get; set; } = string.Empty;
    }
}
