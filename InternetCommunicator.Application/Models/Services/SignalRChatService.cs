using InternetCommunicator.Domain.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace InternetMessengerApp.Services
{
    public class SignalRChatService
    {


        private readonly HubConnection _connection;

        public event Action<Post> MessageReceived;
        public SignalRChatService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<Post>("ReceiveMessage", (post) => MessageReceived?.Invoke(post));
        }

        public async Task Connect()
        {
            await _connection.StartAsync();
        }

        public async Task SendMessage(Post post)
        {
            await _connection.SendAsync("SendMessage", post);
        }
    }
}
