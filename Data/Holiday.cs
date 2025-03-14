using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime HolidayDate { get; set; }
        public string Description { get; set; }
    }
}
