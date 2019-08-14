using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDevCore.Areas.Event.ViewModels
{
    public class EventureEventViewModel
    {
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }

        public double PricePerTicket { get; set; }
    }
}
