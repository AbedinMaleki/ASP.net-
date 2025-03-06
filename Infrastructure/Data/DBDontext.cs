using Infrastructure.ConfigurationsModel;
using Microsoft.EntityFrameworkCore;
using Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SampleDB : DbContext
    {
        public SampleDB(DbContextOptions<SampleDB> options):base(options)
        {
            
        }
        public DbSet<Product> Pruducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new productConfigurations());
        }
    }
}
