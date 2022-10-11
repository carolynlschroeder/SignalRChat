using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SignalRChat.Data;

namespace SignalRChat.Services
{
    public class ChatService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public ChatService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<IdentityUser> GetUsers()
        {
            ApplicationDbContext context = _contextFactory.CreateDbContext();
            return context.Users.ToList();
        }

        public List<Message> GetUserMessages(string userName)
        {
            ApplicationDbContext context = _contextFactory.CreateDbContext();
            var userMessages = context.Messages.Where(m => m.To == userName || m.From == userName);
            return userMessages.OrderBy(m => m.Id)
                .Skip(Math.Max(0, userMessages.Count() - 5)).ToList();
        }

        public void AddMessage(Message message)
        {
            ApplicationDbContext context = _contextFactory.CreateDbContext();
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
