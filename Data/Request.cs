using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class Request
    {
        public int RequestId { get; set; }
        public int WorkerId { get; set; }
        public string RequestType { get; set; } // ShiftChange or Leave
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // Pending, Approved, or Rejected
        public int? ShiftId { get; set; }
        public string Comment { get; set; }

        public User Worker { get; set; }
        public Shift Shift { get; set; }
    }
}

