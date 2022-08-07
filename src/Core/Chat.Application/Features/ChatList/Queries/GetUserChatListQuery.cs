using Chat.Application.Common.DTOs;
using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Application.Common.Interfaces.Users;
using Chat.Application.Common.Models;
using Chat.Application.Features.ChatList.Dto;
using Chat.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Features.ChatList.Queries;

public record GetUserChatListQuery : IRequest<List<ChatListDto>>;

public class GetUserChatListQueryHandler : IRequestHandler<GetUserChatListQuery, List<ChatListDto>>
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

        var chatList = await _context.ChatLists
            .Where(x => x.FromUserId == currentUserId)
            .Include(x => x.AppUser)
            .ToListAsync(cancellationToken);
        var chatListDto = chatList
            .Select(s => new ChatListDto
            {
                Id = s.Id,
                UserInfo = new UserInfoDto
                {
                    FullName = s.AppUser.UserName,
                    ProfileImageUrl = "",
                    UserId = s.AppUser.Id
                },
                LastMessageText = s.LastMessageText,
                LastMessageTime = s.LastMessageTime,
                CommonChatListId = s.CommonChatListId
                
            }).ToList();
            
        return chatListDto;
    }
}