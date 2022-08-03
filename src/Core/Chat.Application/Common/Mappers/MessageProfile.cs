using AutoMapper;
using Chat.Application.Features.Messages.Dto;
using Chat.Core.Entities;

namespace Chat.Application.Common.Mappers;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, MessageDto>()
            .ForMember(x => x.FromUserId, c => c.MapFrom(x => x.From))
            .ForMember(x => x.ToUserId, c => c.MapFrom(x => x.To))
            .ForMember(x => x.CommonChatListId, c => c.MapFrom(x => x.CommonChatListId))
            .ReverseMap();
    }
}