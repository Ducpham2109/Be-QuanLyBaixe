using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class Managements : Base
    {
        public string Username { get; set; }
  
        public int ParkingCode { get; set; }
        public Parkings Parking { get; set; }
        public Accounts Account { get; set; }

    }
}
