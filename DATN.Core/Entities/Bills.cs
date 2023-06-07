using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class Bills : Base
    {
        public int BillsId { get; set; }
        public string Username { get; set; }
        public string VehicleyType { get; set; }
        public string LisenseVehicle { get; set; }
        public string EntryTime { get; set; }
        public string OutTime { get; set; }
        public int ParkingCode { get; set; }
        public int Cost { get; set; }
        public Parkings Parking { get; set; }
        public EntryVehicles EntryVehicle { get; set; }
    }
}
