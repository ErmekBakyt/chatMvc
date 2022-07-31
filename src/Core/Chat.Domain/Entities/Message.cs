using Chat.Core.Common;
using Chat.Core.Identity;

namespace Chat.Core.Entities;

public class Message : BaseGuidEntity
{
    public string TextMessage { get; set; }
    public Guid From { get; set; }
    public Guid To { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid CorrespondedUserId { get; set; }

    public AppUser AppUser { get; set; }
}