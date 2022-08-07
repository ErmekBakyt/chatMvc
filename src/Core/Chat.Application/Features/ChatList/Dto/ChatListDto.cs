using Chat.Application.Common.DTOs;
using Chat.Core.Common;

namespace Chat.Application.Features.ChatList.Dto;

public class ChatListDto : BaseGuidEntity
{
    public string LastMessageText { get; set; }
    public DateTime LastMessageTime { get; set; }
    public int UnreadMessageCount { get; set; }
    public string CommonChatListId { get; set; }
    public UserInfoDto UserInfo { get; set; }
}