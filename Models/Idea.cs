using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace beltexam.Models
{
    [Table("ideas")]
    public class Idea : BaseEntity
    {
        [Key]
        public int IdeaId { get; set; }

        [Required]
        [MinLength(3)]
        public string IdeaData { get; set; }
        public User Writer { get; set; }
        public int UserId { get; set; }
        public List<Likes> Likers { get; set; }
    }


}

