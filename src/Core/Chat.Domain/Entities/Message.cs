namespace Chat.Core.Entities;

public class Message
{
    public string TextMessage { get; set; }
    public Guid From { get; set; }
    public Guid To { get; set; }
}