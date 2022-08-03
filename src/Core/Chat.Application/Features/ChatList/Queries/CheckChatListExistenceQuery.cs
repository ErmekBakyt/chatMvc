using Chat.Application.Common.Interfaces.AppDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Features.ChatList.Queries;

public record CheckChatListExistenceQuery(string FromUserId, string ToUserId) : IRequest<string>;

public class CheckChatListExistenceQueryHandler : IRequestHandler<CheckChatListExistenceQuery, string>
{
    private readonly IAppDbContext _context;

    public CheckChatListExistenceQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public  Task<string> Handle(CheckChatListExistenceQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_context.ChatLists
            .SingleOrDefault(x => x.FromUserId == request.FromUserId && x.ToUserId == request.ToUserId)?.CommonChatListId);
    }
}
