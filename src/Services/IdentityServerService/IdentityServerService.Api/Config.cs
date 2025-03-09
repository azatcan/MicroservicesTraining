using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServerService.Api;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("resource_catalog"){Scopes={"catalog_fullpermisson"}},
        new ApiResource("resource_photo_stock"){Scopes={ "photo_stock_fullpermisson" }},
        new ApiResource("resource_basket"){Scopes={ "basket_fullpermisson" }},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.Email(),
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(){Name="roles",DisplayName="Roles",Description="Kullanıcı rolleri",UserClaims=new[]{"role" }}
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("catalog_fullpermisson","Catalog API için full erişim"),
            new ApiScope("photo_stock_fullpermisson","Photo Stock API için full erişim"),
            new ApiScope("basket_fullpermisson","basket API için full erişim"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // m2m client credentials flow client
            new Client
            {
                ClientName = "Asp.Net Core MVC",
                ClientId ="WebMvcClient",
                ClientSecrets = {new Secret("secret".ToSha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "catalog_fullpermisson" , "photo_stock_fullpermisson",IdentityServerConstants.LocalApi.ScopeName },

            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientName = "Asp.Net Core MVC User",
                ClientId = "WebMvcClientForUser",
                AllowOfflineAccess = true,
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                AllowedScopes = { "basket_fullpermisson",IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile ,IdentityServerConstants.StandardScopes.OfflineAccess,IdentityServerConstants.LocalApi.ScopeName,"roles"},
                AccessTokenLifetime = 1*60*60,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,
                RefreshTokenUsage = TokenUsage.ReUse,
            },
        };
}
