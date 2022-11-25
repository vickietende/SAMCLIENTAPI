using Microsoft.EntityFrameworkCore;
using SAMCLIENTAPI.models;

namespace SAMCLIENTAPI.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<user> users => Set<user>();
        public DbSet<customer> customers => Set<customer>();

        public DbSet<city> cities => Set<city>();
    }
}
