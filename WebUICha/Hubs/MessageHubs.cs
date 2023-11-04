
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using WebUICha.Data;
using WebUICha.Model;

namespace WebUICha.Hubs
{
    public class MessageHubs:Hub
    {
        private readonly UserManager<User> _userManager;

        public MessageHubs(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task JoinDefaultGroups()
        {
            var c = Context.GetHttpContext().User.Identity.Name;
            var a = await _userManager.FindByEmailAsync(c);
            var user = a.Firstname;
            string groupName = user;
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessage(string message)
        {
            var c = Context.GetHttpContext().User.Identity.Name;
            var a = await _userManager.FindByEmailAsync(c);
            var userName= a.Lastname;
            var user = a.Firstname;
            string groupName = user;
            await Clients.Group(groupName).SendAsync("ReceiveMessage", userName, message);
        }
    }


}
