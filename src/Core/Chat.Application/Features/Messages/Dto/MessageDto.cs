namespace Chat.Application.Features.Messages.Dto;

public class MessageDto
{
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
    public string TextMessage { get; set; }

    public string CommonChatListId { get; set; }
}