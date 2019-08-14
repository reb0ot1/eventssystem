using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Filters;
using WebDevCore.Services.WebDevCore.Web.Services.Events.Contracts;

namespace WebDevCore.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private IEventsService eventsService;

        public EventsController(IEventsService es)
        {
            this.eventsService = es;
        }

        //[ServiceFilter(typeof(LogUserActivityActionFilter))]
        public IActionResult Index()
        {
            var events = this.eventsService.All();

            return this.View();
        }

    }
}
