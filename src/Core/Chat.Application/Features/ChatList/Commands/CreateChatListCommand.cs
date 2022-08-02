using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Application.Common.Models;
using MediatR;

namespace Chat.Application.Features.ChatList.Commands;

public class CreateChatListCommand : IRequest<(Result,string)>
{
    public string FromUserId { get; set; }
    public string ToUserId { get; set; }
}

public class CreateChatListCommandHandler : IRequestHandler<CreateChatListCommand, (Result,string)>
{
    private readonly IAppDbContext _context;

    public CreateChatListCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<(Result,string)> Handle(CreateChatListCommand request, CancellationToken cancellationToken)
    {
        var chatList = await _context.ChatLists.AddAsync(new Core.Entities.ChatList
        {
            FromUserId = request.FromUserId,
            ToUserId = request.ToUserId,
            CorrespondedUserId = request.ToUserId
        }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return (Result.Success(),chatList.Entity.Id.ToString());
    }
}