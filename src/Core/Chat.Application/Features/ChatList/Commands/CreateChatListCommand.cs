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
        var commonChatListId = Guid.NewGuid().ToString();
        await _context.ChatLists.AddAsync(new Core.Entities.ChatList
        {
            FromUserId = request.FromUserId,
            ToUserId = request.ToUserId,
            CommonChatListId = commonChatListId
        }, cancellationToken);
        
        await _context.ChatLists.AddAsync(new Core.Entities.ChatList
        {
            FromUserId = request.ToUserId,
            ToUserId = request.FromUserId,
            CommonChatListId = commonChatListId
        }, cancellationToken);
        
        await _context.SaveChangesAsync(cancellationToken);
        return (Result.Success(),commonChatListId);
    }
}