using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDevCore.Data;
using WebDevCore.Models.Events;
using WebDevCore.Services.WebDevCore.Web.Services.Events.Contracts;

namespace WebDevCore.Services.WebDevCore.Web.Services.Events
{
    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext context;

        public EventsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<EventureEvent> All() => this.context.EventureEvents;
        
    }
}
