using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;



using DATN.Infastructure.Persistence.Configurations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AccountsConfigTable();
            modelBuilder.BillsConfigTable();
            modelBuilder.EntryVehiclesConfigTable();
            modelBuilder.ManagementsConfigTable();
            modelBuilder.ParkingsConfigTable();
            modelBuilder.TicketsConfigTable();
         
           
            
            //modelBuilder.SeedInitial();
        }

        public DbSet<Accounts> Accounts => Set<Accounts>();
        public DbSet<Bills> Bills => Set<Bills>();
        public DbSet<EntryVehicles> EntryVehicles => Set<EntryVehicles>();
        public DbSet<Managements> Managements => Set<Managements>();
        public DbSet<Parkings> Parkings => Set<Parkings>();
       
     
    }
}
