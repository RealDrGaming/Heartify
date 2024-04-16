using HeartifyDating.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heartify.Infrastructure.Data.Models
{
    [Comment("Likes of a Person Profile")]
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Liker")]
        public string LikerId { get; set; } = string.Empty;
        public IdentityUser Liker { get; set; } = null!;

        [ForeignKey("LikedProfile")]
        public int LikedProfileId { get; set; }
        public PersonProfile LikedProfile { get; set; } = null!;
    }
}
