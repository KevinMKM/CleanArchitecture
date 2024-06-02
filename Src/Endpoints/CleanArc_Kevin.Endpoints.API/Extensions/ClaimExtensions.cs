using System.Security.Claims;

namespace CleanArc_Kevin.Endpoints.API.Extensions;

public static class ClaimExtensions
{
    public static string? GetClaim(this ClaimsPrincipal userClaimsPrincipal, string claimType)
        => userClaimsPrincipal.Claims?.FirstOrDefault(x => x.Type == claimType)?.Value;
}