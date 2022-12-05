using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public class EntityContext:DbContext
    {
        public EntityContext() : base(){

        }
        public EntityContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student>students { get; set; }
        public DbSet<School>schools { get; set; }
    }
}
