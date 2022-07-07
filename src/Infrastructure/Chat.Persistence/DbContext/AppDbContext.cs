using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.DbContext;

public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}