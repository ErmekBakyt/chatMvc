using Chat.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Chat.Core.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }

    public List<Message> Messages { get; set; }
}