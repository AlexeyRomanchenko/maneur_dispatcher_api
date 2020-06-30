using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Web
{
    public class ConnectionHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
        }
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
