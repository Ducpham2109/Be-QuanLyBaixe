using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace DATN.Infastructure.Persistence.Configurations
{
    public static class BillsConfig
    {
        public static void BillsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(e =>
            {
                e.ToTable("Bills");
                e.HasKey(e => e.BillsId);
                e.HasOne<EntryVehicles>(s => s.EntryVehicle)
                   .WithMany(ss => ss.Bills)
                   .HasForeignKey(s => s.LisenseVehicle)
                   .OnDelete(DeleteBehavior.Cascade);
                //   .HasConstraintName("FK1_Bills_Entry")
                   //.HasForeignKey(s => s.EntryTime)
                   //.OnDelete(DeleteBehavior.Cascade);
                //  .HasConstraintName("FK_Bills_Etry");


                e.HasOne<Parkings>(s => s.Parking)
                    .WithMany(ss => ss.Bills)
                    .HasForeignKey(s => s.ParkingCode)
                    .OnDelete(DeleteBehavior.Cascade);

                //  .HasConstraintName("FK_Bills_Parkings")
                //OnDelete(DeleteBehavior.NoAction); 


            }); // <- add closing parenthesis here
        }
    }

}
