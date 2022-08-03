namespace Chat.Application.Common.DTOs;

public class ChatMessageDto
{
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
    public string TextMessage { get; set; }
    public string CommonChatListId { get; set; }
}