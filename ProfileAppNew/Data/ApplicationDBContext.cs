using Microsoft.EntityFrameworkCore;
using ProfileAppNew.Models;

namespace ProfileAppNew.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options):base(options)    
        {

        }
        public DbSet<Information> Information { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}
