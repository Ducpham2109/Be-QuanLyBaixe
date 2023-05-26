using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class ManagementsConfig
    {
        public static void ManagementsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Managements>(e =>
            {
                e.ToTable("Managements");
                e.HasKey(e =>  e.Username);
                e.HasOne<Accounts>(s => s.Account)
                    .WithOne(ss => ss.Management)
                    .HasForeignKey<Managements>(s => s.Username);
                e.HasOne<Parkings>(s => s.Parking)
                    .WithMany(ss => ss.Managements)
                    .HasForeignKey(s => s.ParkingCode);



            }); // <- add closing parenthesis here
        }
    }
}
