using Chat.Core.Common;

namespace Chat.Core.Entities;

public class ChatList : BaseGuidEntity
{
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
}