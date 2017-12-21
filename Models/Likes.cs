using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace beltexam.Models
{
    
    public class Likes
    {
        [Key]
        public int LikesId { get; set; }

        public User Liker { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public Idea LikedIdea { get; set; }
        [ForeignKey("IdeaId")]
        public int IdeaId { get; set; }

    }
}

