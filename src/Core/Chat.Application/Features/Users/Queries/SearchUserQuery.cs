using Chat.Application.Common.Interfaces.Users;
using Chat.Core.Identity;
using MediatR;



namespace Chat.Application.Features.Users.Queries
{
    public record SearchUserQuery(string UserNameOrEmail) : IRequest<AppUser>;
    
    public class SearchUserQueryHandler : IRequestHandler<SearchUserQuery, AppUser>
    {
        private readonly IUserService _userService;

        public SearchUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AppUser> Handle(SearchUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.SearchUserAsync(request.UserNameOrEmail);
        }
    }
}
