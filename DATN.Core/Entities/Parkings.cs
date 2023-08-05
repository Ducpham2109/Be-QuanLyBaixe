using DATN.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Entities
{
    public class Parkings : Base
    {
        public int ParkingCode { get; set; }
        public string ParkingAddress { get; set; }
        public string ParkingName { get; set; }
        public int MnPrice { get; set; }
        public int MmPrice { get; set; }
        public int NnPrice { get; set; }
        public int NmPrice { get; set; }
        public int Capacity { get; set; }
        public int PreLoading { get; set; }
        public ICollection<Bills> Bills { get; set; }
        public ICollection<Managements> Managements { get; set; }
        
        public ICollection<EntryVehicles> EntryVehicles { get; set; }
    }
}
