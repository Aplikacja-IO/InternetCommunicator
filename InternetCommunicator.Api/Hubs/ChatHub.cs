using InternetCommunicator.Domain.Models;
using InternetCommunicator.Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetCommunicator.Api.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public string GetConnectionId() => Context.ConnectionId; //ConnectionId - unique ID thta SignalR gives to every client
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string user, string message)
        {
            using (var context = new CommunicatorDbContext(Startup.ServiceProvider.GetRequiredService<DbContextOptions<CommunicatorDbContext>>())) {
                var comment = new Comment();
                comment.PostText = message;
                comment.ComponentId = 1;
                /*context.Comments.Add(comment);
                context.SaveChanges();*/
            }
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SencPrivateMessage(string toUser, string fromUser, string message)
        {
            await Clients.User(toUser).SendAsync("ReceivePrivateMessage", fromUser, message);
        }
    }
}
