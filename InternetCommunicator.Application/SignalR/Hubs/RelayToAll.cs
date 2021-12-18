using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace InternetMessengerApp
{
    public class RelayToAll : Hub
    {
        public async Task SendMessage(string ComponentID, string PostText)
        {
            await Clients.All.SendAsync("ReceiveMessage", ComponentID, PostText);
        }
    }
}
