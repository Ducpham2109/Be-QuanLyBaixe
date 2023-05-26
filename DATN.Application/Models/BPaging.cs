using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Models
{
    public class BPaging<T> where T : class
    {
        public IReadOnlyList<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalWifiActive { get; set; }
    }
}
