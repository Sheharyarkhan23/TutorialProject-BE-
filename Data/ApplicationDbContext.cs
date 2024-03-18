using TutorialProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TutorialProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ScreenInfo> ScreenInfo { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectInformation> ProjectInformation { get; set; }
        public DbSet<InfoAboutScreen> InfoAboutScreen { get; set; }
        public DbSet<Blog> Blog { get; set; }

    }
}
