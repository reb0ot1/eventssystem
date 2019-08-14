namespace WebDevCore.Models.Events
{
    using System;

    public class EventureEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalTickets { get; set; }
            
        public double PricePerTicket { get; set; }
    }
}
