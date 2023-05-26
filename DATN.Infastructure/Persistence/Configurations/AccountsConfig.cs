using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class AccountsConfig
    {
        public static void AccountsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(e =>
            {
                e.ToTable("Accounts");
                e.HasKey(e => e.Username);
                //e.HasMany<EntryVehicles>(s => s.EntryVehicle)
                //    .WithOne(ss => ss.Account)
                //    .HasForeignKey(s => s.Username);
                //e.HasMany<VehicleInParkings>(s => s.VehicleInParking)
                //   .WithOne(ss => ss.Account)
                //   .HasForeignKey(s => s.Username);

            }); // <- add closing parenthesis here
        }
    }
}
