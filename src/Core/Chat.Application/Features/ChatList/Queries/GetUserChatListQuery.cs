using Chat.Application.Common.Models;
using MediatR;

namespace Chat.Application.Features.ChatList.Queries;

public record GsetUserChatListQuery : IRequest<Result>;