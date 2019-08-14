using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDevCore.Data;
using WebDevCore.Models.Events;
using WebDevCore.Models.Users;

namespace WebDevCore.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;
        
        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            ApplicationDbContext dbContext,
            UserManager<EventureUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.EventureEvents.Any())
            {
                //this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
                //await this.SeedRoles(userManager, roleManager);
            }

            await this.next(context);
        }

        private async Task SeedRoles(UserManager<EventureUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Administrator"));

            if (result.Succeeded && userManager.Users.Any())
            {
                var firstUser = userManager.Users.FirstOrDefault();
                await userManager.AddToRoleAsync(firstUser, "Administrator");
            }
        }

        private void SeedEvents(ApplicationDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                var sampleEvent = new EventureEvent
                {
                    Name = $"Sample event number {i}",
                    Place = $"Sample event address 100{i}",
                    Start = DateTime.Now.Add(TimeSpan.FromDays(i)),
                    End = DateTime.Now.Add(TimeSpan.FromDays(i * 2)),
                    PricePerTicket = 10 + 1,
                    TotalTickets = i * 100
                };

                context.EventureEvents.Add(sampleEvent);
            }

            context.SaveChanges();
        }
    }
}
