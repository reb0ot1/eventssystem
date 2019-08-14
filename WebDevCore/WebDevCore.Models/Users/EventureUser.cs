using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Models.Events;

namespace WebDevCore.Models.Users
{
    public class EventureUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UCN { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
