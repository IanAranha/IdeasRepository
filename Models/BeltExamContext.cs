using beltexam.Models;
using Microsoft.EntityFrameworkCore;
 
namespace beltexam.Models
{
    public class BeltExamContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltExamContext(DbContextOptions<BeltExamContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Idea> ideas { get; set; }
        public DbSet<Likes> likes { get; set; }


    }
}

    