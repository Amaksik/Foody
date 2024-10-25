using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foody.Business.DAL.Entities.IdentityModels;

namespace Foody.Business.DAL.EntityConfigurations
{
    public class ApplicationUserRoleRecordEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUserRoleRecord>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRoleRecord> builder)
        {
            builder.ToTable("roles");
            builder.Property(ir => ir.Id).HasColumnName("id");
            builder.Property(ir => ir.Name).HasColumnName("name");
        }
    }
}
