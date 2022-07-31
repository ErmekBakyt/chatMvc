using Chat.Application.Common.DTOs;
using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Application.Common.Interfaces.Users;
using Chat.Application.Features.Messages.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Features.Messages.Queries;

public record GetUserChatListQuery : IRequest<List<ChatListDto>>;

public class GetUserChatListQueryHandler : IRequestHandler<GetUserChatListQuery,List<ChatListDto>>
{
    private readonly IAppDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetUserChatListQueryHandler(IAppDbContext context, ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<List<ChatListDto>> Handle(GetUserChatListQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.CurrentUserId;

        var userMessages = await _context.Messages
            .Where(x => x.From.ToString() == currentUserId || x.CorrespondedUserId.ToString() == currentUserId)
            .Include(i=>i.AppUser)
            .DistinctBy(x=>new {x.From,x.To})
            .Select(s=>new ChatListDto
            {
                UserInfo = new UserInfoDto
                {
                  FullName  = s.AppUser.FullName
                },
                LastMessageInfo = new LastMessageInfoDto
                {
                    LastMessage = s.TextMessage,
                    LastMessageTime = s.CreatedDate
                }
            }).ToListAsync(cancellationToken);
        return userMessages;
    }
}

