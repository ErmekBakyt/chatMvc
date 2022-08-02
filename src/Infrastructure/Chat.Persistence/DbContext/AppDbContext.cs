using System.Reflection;
using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Core.Entities;
using Chat.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat.Persistence.DbContext;

public class AppDbContext : IdentityDbContext<AppUser>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Message> Messages { get; set; }
    public DbSet<ChatList> ChatLists { get; set; }
    
    
    public override Task<int> SaveChangesAsync(CancellationToken token = new())
    {
        return base.SaveChangesAsync(token);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}