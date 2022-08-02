using Chat.Application.Common.DTOs;
using Chat.Core.Common;

namespace Chat.Application.Features.ChatList.Dto;

public class ChatListDto : BaseGuidEntity
{
    public LastMessageInfoDto LastMessageInfo { get; set; }
    public UserInfoDto UserInfo { get; set; }
}