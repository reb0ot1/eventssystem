using WebDevCore.Models.Events;
using System.Linq;

namespace WebDevCore.Services.WebDevCore.Web.Services.Events.Contracts
{
    public interface IEventsService
    {
        IQueryable<EventureEvent> All();
    }
}
