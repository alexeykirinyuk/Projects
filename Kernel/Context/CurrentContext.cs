using Projects.DataTypes;
using System.Data.Entity;

namespace Projects.Context
{
    public class CurrentContext : DbContext
    {
        public CurrentContext() : base("ProjectsDB") { }

        public DbSet<Project> ProjectsBase { get; set; }
        public DbSet<Person> PersonsBase { get; set; }
    }
}
