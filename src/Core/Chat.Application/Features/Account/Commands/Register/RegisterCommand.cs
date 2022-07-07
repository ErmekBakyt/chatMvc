using Chat.Application.Common.DTOs;
using MediatR;

namespace Chat.Application.Features.Account.Commands.Register;

public record RegisterCommand(string UserName, string Password) : IRequest;


public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
{
    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
};