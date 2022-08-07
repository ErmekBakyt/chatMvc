using System.ComponentModel.DataAnnotations.Schema;
using Chat.Core.Common;
using Chat.Core.Identity;

namespace Chat.Core.Entities;

public class ChatList : BaseGuidEntity
{
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
    public string CommonChatListId { get; set; }
    public string LastMessageText { get; set; }
    public DateTime LastMessageTime { get; set; }
    public AppUser AppUser { get; set; }
}