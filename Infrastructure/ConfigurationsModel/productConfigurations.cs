using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfigurationsModel
{
    public class productConfigurations : IEntityTypeConfiguration<Product>

    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", schema: "Test");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Name).IsRequired().HasColumnType("Nvarchar(100)");
            builder.Property(x => x.Price).IsRequired(false);
            builder.Property(x => x.Description).IsRequired(false).HasColumnType("Nvarchar(500)");
        }
    }
}
