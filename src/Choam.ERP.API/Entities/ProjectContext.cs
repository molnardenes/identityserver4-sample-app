using Microsoft.EntityFrameworkCore;

namespace Choam.ERP.API.Entities
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}