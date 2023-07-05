using DATN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infastructure.Persistence.Configurations
{
    public static class TicketsConfig
    {
        public static void TicketsConfigTable(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>(e =>
            {
                e.ToTable("Tickets");
                e.HasKey(e => e.IDCard);
            }); // <- add closing parenthesis here
        }
    }
}
