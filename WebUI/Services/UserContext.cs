using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Persistence.Models;

namespace WebUI.Services;

public class UserContext
{
    private AuthenticationStateProvider _authenticationStateProvider { get; set; }
    private UserManager<UserProfile> _userManager { get; set; }

    public UserContext(AuthenticationStateProvider authenticationStateProvider, UserManager<UserProfile> userManager)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _userManager = userManager;
    }

    public async Task<string?> UserId()
    {
        var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = state.User;

        var details = await _userManager.GetUserAsync(user);

        if (details is not null)
            return await _userManager.GetUserIdAsync(details);

        return null;
    }
}
