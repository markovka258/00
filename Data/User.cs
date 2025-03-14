using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Employer or Worker
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Shift> Shifts { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
