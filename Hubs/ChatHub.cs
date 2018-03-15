using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTutorial.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "Joined !!!");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "Left !!!");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, message);
        }
    }
}
