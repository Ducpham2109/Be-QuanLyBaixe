using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace DATN.Infastructure.Persistence.Configurations
{
    //public class ParkingsConfigTable : IEntityTypeConfiguration<Parkings>
    //{
    //    //public void Configure(EntityTypeBuilder<Parkings> builder)
    //    //{
    //    //    builder.ToTable("Parkings");
    //    //    builder.HasKey(p => p.ParkingCode);

    //    //}

    //}
    public static class ParkingsConfig
    {
        public static void ParkingsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parkings>(e =>
            {
                e.ToTable("Parkings");
                e.HasKey(e => e.ParkingCode);
            
                
            }); // <- add closing parenthesis here
        }
    }

}
