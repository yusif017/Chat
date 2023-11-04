
using Microsoft.AspNetCore.SignalR;

namespace WebUI.Hubs
{
    public class MessageHubs:Hub
    {
        
        public async Task SendMessage(string user, string message)
        {
            
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
