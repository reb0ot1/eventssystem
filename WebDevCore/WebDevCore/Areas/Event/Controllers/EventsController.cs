namespace WebDevCore.Areas.Event.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebDevCore.Areas.Event.ViewModels;
    using WebDevCore.Services.WebDevCore.Web.Services.Events.Contracts;

    [Area("Event")]
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        
        public EventsController(IEventsService es)
        {
            this.eventsService = es;
        }

        public IActionResult Index()
        {
            var events = this.eventsService.All();
            var eventsViewModels = events.Select(e =>
                new EventureEventViewModel {
                    End = e.End,
                    Name = e.Name,
                    Place = e.Place,
                    Start = e.Start,
                    PricePerTicket = e.PricePerTicket,
                    TotalTickets = e.TotalTickets
                });

            return View(eventsViewModels);
        }
    }
}