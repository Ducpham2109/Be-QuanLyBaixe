using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace DATN.Infastructure.Persistence.Configurations
{
    public static class EntryVehiclesConfig
    {
        public static void EntryVehiclesConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntryVehicles>(e =>
            {
                e.ToTable("EntryVehicles");
                e.HasKey(e => new { e.LisenseVehicle, e.EntryTime });
                //e.HasMany<Bills>(s => s.Bills)
                //    .WithOne(ss => ss.EntryVehicle)
                //    .HasForeignKey(s => s.LisenseVehicle);
                e.HasOne<Accounts>(s => s.Account)
                   .WithMany(ss => ss.EntryVehicles);
                   
                e.HasOne<Parkings>(s => s.Parking)
                  .WithMany(ss => ss.EntryVehicles)
                  .HasForeignKey(s => s.ParkingCode);

            }); // <- add closing parenthesis here
        }
    }
}
