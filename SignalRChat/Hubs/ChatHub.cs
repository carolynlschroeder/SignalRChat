using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public const string HubUrl = "/chat";
        public async Task JoinToRoom(string userName)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userName}");

        }


        public async Task SendMessage(string from, string to, string message)
        {

                await Clients.Group($"user_{to}").SendAsync("ReceiveMessage", from, message);
        }
    }
}
