using Chat.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Chat.Application.Common.Extensions;

public static class IdentityResultExtension
{
    public static Result ToApplicationResult(this IdentityResult identityResult, string message = null)
    {
        return identityResult.Succeeded
            ? Result.Success(message)
            : Result.Failure(identityResult.Errors.Select(x => x.Description).ToArray());
    }
}