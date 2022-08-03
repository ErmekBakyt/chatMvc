using Chat.Core.Common;
using Chat.Core.Identity;

namespace Chat.Core.Entities;

public class ChatList : BaseGuidEntity
{
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
    public string CommonChatListId { get; set; }

    public List<Message> Messages { get; set; }
    public AppUser AppUser { get; set; }
}