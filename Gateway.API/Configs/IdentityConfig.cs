using IdentityServer4.Models;

namespace Gateway.API.Configs;

internal sealed class IdentityConfig
{
    public required string Url { get; init; }
    public required string ClientId { get; init; }
    public required string ClientSecret { get; init; }
}