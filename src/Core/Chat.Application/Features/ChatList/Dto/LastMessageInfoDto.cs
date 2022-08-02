namespace Chat.Application.Features.ChatList.Dto;

public class LastMessageInfoDto
{
    public string LastMessage { get; set; }
    public DateTime LastMessageTime { get; set; }
    public int UnreadMessageCount { get; set; }
}