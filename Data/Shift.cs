using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int ScheduleId { get; set; }
        public int WorkerId { get; set; }
        public DateTime ShiftDate { get; set; }
        public bool IsWorking { get; set; }

        public Schedule Schedule { get; set; }
        public User Worker { get; set; }
        public Request Request { get; set; }

    }
}
