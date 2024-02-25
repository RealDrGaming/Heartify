using Heartify.Infrastructure.Constants;
using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Heartify.Data.Models
{
    [Comment("Gender")]
    public class Gender
    {
        [Key]
        [Comment("Gender Unique Identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.GenderMaxLength)]
        [Comment("Gender Name")]
        public string GenderName { get; set; } = string.Empty;

        public IList<PersonProfile> PersonProfiles { get; set;} = new List<PersonProfile>();
    }
}
