using Chat.Application.Common.DTOs;

namespace Chat.Application.Features.Messages.Dto;

public class ChatListDto
{
    public LastMessageInfoDto LastMessageInfo { get; set; }
    public UserInfoDto UserInfo { get; set; }
}