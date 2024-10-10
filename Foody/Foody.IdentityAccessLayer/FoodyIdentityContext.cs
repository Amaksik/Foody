using Foody.Domain.Entities;
using Foody.IdentityAccessLayer.Record;
using Foody.IdentityAccessLayer.Records;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Foody.IdentityAccessLayer
{
    public class FoodyIdentityContext : IdentityDbContext<ApplicationUserRecord, ApplicationUserRoleRecord, int, 
                                                        IdentityUserClaim<int>, ApplicationUserRecordApplicationUserRoleRecord, 
                                                        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public FoodyIdentityContext(DbContextOptions<FoodyIdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

            modelBuilder.Entity<ApplicationUserRecordApplicationUserRoleRecord>()
                .HasOne(ur => ur.Role)
                .WithMany().HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRecord>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            //modelBuilder.Entity<ApplicationUserRecord>()
            //    .HasOne(e => e.Role)
            //    .WithOne(u => u.ApplicationUserRecord)
            //    .HasForeignKey<ApplicationUserRecordApplicationUserRoleRecord>(ur => ur.ApplicationUserRecordId)
            //    .IsRequired();

            //one-to-one relation configuration identityUser to domain Entities
            modelBuilder.Entity<ApplicationUserRecord>()
               .HasOne(e => e.Client)
               .WithOne(e => e.User)
               .HasForeignKey<ClientUserRecord>(e => e.UserId)
               .IsRequired(false);

            modelBuilder.Entity<ApplicationUserRecord>()
              .HasOne(e => e.Trainer)
              .WithOne(e => e.User)
              .HasForeignKey<TrainerUserRecord>(e => e.UserId)
              .IsRequired(false);

            modelBuilder.Entity<ApplicationUserRecord>()
              .HasOne(e => e.Organization)
              .WithOne(e => e.User)
              .HasForeignKey<OrganizationUserRecord>(e => e.UserId)
              .IsRequired(false);
            
            // configuration of the domain entities
            modelBuilder.Entity<TrainerUserRecord>()
                .HasMany(x => x.Clients)
                .WithOne(x => x.Trainer)
                .HasForeignKey(k => k.TrainerId)
                .IsRequired(false);

            modelBuilder.Entity<OrganizationUserRecord>()
               .HasMany(x => x.Trainers)
               .WithOne(x => x.Organization)
               .HasForeignKey(k => k.OrganizationId)
               .IsRequired(false);
        }

        public DbSet<ClientUserRecord> Clients { get; set; }
        public DbSet<TrainerUserRecord> Trainers { get; set; }
        public DbSet<OrganizationUserRecord> Organizations { get; set; }

    }

}