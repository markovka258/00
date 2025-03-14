using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int EmployerId { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; }
    
        public User Employer { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }
}
