using Chat.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Common.Interfaces.AppDbContext;

public interface IAppDbContext 
{
    public DbSet<Message> Messages { get; set; }
    Task<int> SaveChangesAsync(CancellationToken token);
}