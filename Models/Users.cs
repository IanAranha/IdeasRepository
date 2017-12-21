using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using beltexam.Models;

namespace beltexam.Models
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Email{ get; set; }

        public string Password { get; set; }
        public List<Idea> myIdeas { get; set; }

        public List<Likes> LikedIdeas { get; set; }
        
    }
}
