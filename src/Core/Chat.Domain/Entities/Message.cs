using Chat.Core.Common;
using Chat.Core.Identity;

namespace Chat.Core.Entities;

public class Message : BaseGuidEntity
{
    public string TextMessage { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid ChatListId { get; set; }

    public ChatList ChatList { get; set; }
}