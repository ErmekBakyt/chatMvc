namespace Chat.Application.Common.DTOs;

public class ChatMessageDto
{
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
    public string TextMessage { get; set; }
}