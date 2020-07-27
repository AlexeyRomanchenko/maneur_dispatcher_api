using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web.Frontend.App
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var id = Context.ConnectionId;
        }
        public async Task Send(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
