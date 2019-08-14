using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDevCore.Models.Events;
using WebDevCore.Models.Logging;
using WebDevCore.Models.Users;

namespace WebDevCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventureUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>())
        {

        }

        public DbSet<EventureEvent> EventureEvents { get; set; }

        public DbSet<CustomLog> Logs { get; set; }

        public DbSet<Order> Order { get; set; }
    }
}
