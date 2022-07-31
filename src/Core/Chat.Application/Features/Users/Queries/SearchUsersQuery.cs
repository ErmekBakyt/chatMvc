using Chat.Application.Common.Interfaces.Users;
using Chat.Core.Identity;
using MediatR;



namespace Chat.Application.Features.Users.Queries
{
    public record SearchUsersQuery(string UserNameOrEmail) : IRequest<List<AppUser>>;
    
    public class SearchUserQueryHandler : IRequestHandler<SearchUsersQuery, List<AppUser>>
    {
        private readonly IUserService _userService;

        public SearchUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<AppUser>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.SearchUsersAsync(request.UserNameOrEmail);
        }
    }
}
