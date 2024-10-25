using Foody.Business.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Foody.Business.DAL
{
    public class FityDbContext : DbContext
    {
        public FityDbContext(DbContextOptions<FityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

            base.OnModelCreating(builder);
        }

        public DbSet<ClientUserRecord> Clients { get; set; }

        public DbSet<RequestedTrainingRecord> Trainings { get; set; }

    }
}