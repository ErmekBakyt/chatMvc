using AutoMapper;
using Chat.Application.Common.Interfaces.AppDbContext;
using Chat.Application.Common.Interfaces.Users;
using Chat.Application.Features.Messages.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Features.Messages.Queries;

public record GetUserChatMessagesQuery(string CommonChatListId) : IRequest<List<MessageDto>>;

public class GetUserChatMessagesQueryHandler : IRequestHandler<GetUserChatMessagesQuery, List<MessageDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetUserChatMessagesQueryHandler(IAppDbContext context, ICurrentUserService currentUserService, IMapper mapper)
    {
        _context = context;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<List<MessageDto>> Handle(GetUserChatMessagesQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.CurrentUserId;
        var messages = await _context.Messages
            .Where(x => x.CommonChatListId == request.CommonChatListId)
            .ToListAsync(cancellationToken);
        var messagesDto = _mapper.Map<List<MessageDto>>(messages);
        return messagesDto;
    }
}
