using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class EntryVehicles : Base
    {
        public string Username { get; set; }
        public int IDCard { get; set; }
        public string LisenseVehicle { get; set; }
        public string VehicleyType { get; set; }
        public string EntryTime { get; set; }
        public int ParkingCode { get; set; }
        public string Image { get; set; }
        public Parkings Parking { get; set; }
        public Accounts Account { get; set; }
        public ICollection<Bills> Bills { get; set; }
    }
}
