using InternetCommunicator.Domain.Models;
using InternetCommunicator.Infrastructure.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace InternetMessengerApp
{
    public class RelayToAll : Hub
    {
        public async Task SendMessage(string ComponentID, string PostText)
        {
            await Clients.All.SendAsync("ReceiveMessage", ComponentID, PostText);

            using (var context = new CommunicatorDbContext(Startup.serviceProvider.GetRequiredService<DbContextOptions<CommunicatorDbContext>>()))
            {

                var comment = new Comment();
                comment.PostText = PostText;
                comment.ComponentId = 1;
                context.Comments.Add(comment);
                context.SaveChanges();

            }
        }
    }
}