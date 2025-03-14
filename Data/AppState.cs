using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class AppState
    {
        static public string Username { get; set; } = "";

        public event Action OnChange;

        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
