using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Core.Common;

namespace DATN.Core.Entities
{

    public class Accounts : Base
    {
        public string Username { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public ICollection<EntryVehicles> EntryVehicles { get; set; }
       
        public Managements Management { get; set; }

    }
}
