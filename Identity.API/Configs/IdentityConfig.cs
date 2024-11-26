using IdentityServer4.Models;

namespace Identity.API.Configs;

internal sealed class IdentityConfig
{
    public IReadOnlyList<string> Scopes { get; init; } = [];
    public IReadOnlyList<Client> Clients { get; init; } = [];

    internal sealed class Client
    {
        public required string ClientId { get; init; }
        public required string ClientSecret { get; init; }
        public IReadOnlyList<string> AllowedScopes { get; init; } = [];
    }
    
    public IEnumerable<IdentityServer4.Models.Client> GetClients()
    {
        return Clients.Select(x => new IdentityServer4.Models.Client
        {
            ClientId = x.ClientId,
            ClientSecrets =
            {
                new Secret(x.ClientSecret.Sha256())
            },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = [.. x.AllowedScopes]
        });
    }
    
    public IEnumerable<ApiScope> GetApiScopes()
    {
        return Scopes.Select(x => new ApiScope(x));
    }
}