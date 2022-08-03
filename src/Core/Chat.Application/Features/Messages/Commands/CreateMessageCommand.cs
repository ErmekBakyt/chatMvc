using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Application.Common.Models;
using Chat.Core.Entities;
using MediatR;

namespace Chat.Application.Features.Messages.Commands;

public class CreateMessageCommand : IRequest<Result>
{
    public string TextMessage { get; set; }
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
    public string CommonChatListId { get; set; }
}

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Result>
{
    private readonly IAppDbContext _context;

    public CreateMessageCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        await _context.Messages.AddAsync(new Message
        {
            TextMessage = request.TextMessage,
            From = request.FromUserId,
            To = request.ToUserId,
            CommonChatListId = new Guid(request.CommonChatListId),
            CreatedDate = DateTime.Now.ToUniversalTime()
        }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}