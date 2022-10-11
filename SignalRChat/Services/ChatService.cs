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
    }
}
