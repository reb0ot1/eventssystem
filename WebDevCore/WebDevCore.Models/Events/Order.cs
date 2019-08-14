using System;
using System.Collections.Generic;
using System.Text;
using WebDevCore.Models.Users;

namespace WebDevCore.Models.Events
{
    public class Order
    {
        public Guid ID { get; set; }

        public DateTime OrderOn { get; set; }

        public EventureEvent Event { get; set; }

        public EventureUser User { get; set; }

        public int TicketCount { get; set; }
    }
}
