using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace blazor_mix_ssr.Shared;

public class MyCustomAuthenticationStateProvider : AuthenticationStateProvider {
    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        return await Task.FromResult(new AuthenticationState(AnonymousUser));
    }

    //Anonymous user can has no claims but requires an empty identity
    private ClaimsPrincipal AnonymousUser => new(new ClaimsIdentity(Array.Empty<Claim>()));
    private ClaimsPrincipal FakedUser {
        get {
            var claims = new[] {
                new Claim(ClaimTypes.Name, "ferry"),
                new Claim(ClaimTypes.Role, "admin"),
            };
            var identity = new ClaimsIdentity(claims, "whatever");
            return new ClaimsPrincipal(identity);
        }
    }

    public void FakedSignIn() {
        var result = Task.FromResult(new AuthenticationState(FakedUser));
        NotifyAuthenticationStateChanged(result);
    }

    public void FakedSignOut() {
        var result = Task.FromResult(new AuthenticationState(AnonymousUser));
        NotifyAuthenticationStateChanged(result);
    }
}
