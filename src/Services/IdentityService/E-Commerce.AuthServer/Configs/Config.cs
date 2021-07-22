using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Commerce.AuthServer.Configs
{
    public static class Config
    {
        #region Scopes
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("ECommerceAPI.Read", "ECommerceAPI read permission"),
                new ApiScope("ECommerceAPI.Write", "ECommerceAPI write permission")
            };
        }
        #endregion

        #region Resources
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("ECommerceAPI", "ECommerce API"){ Scopes = { "ECommerceAPI.Read", "ECommerceAPI.Write" } }
            };
        }
        #endregion

        #region Clients
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                #region Api
                new Client
                {
                    ClientId = "ECommerceAPI",
                    ClientName = "ECommerceAPI",
                    ClientSecrets = { new Secret("ecommerceapi".Sha256()) },
                    AllowedGrantTypes = { GrantType.ClientCredentials },
                    AllowedScopes = { 
                        "ECommerceAPI.Read", "ECommerceAPI.Write", 
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email
                    }
                },
	            #endregion
                
                #region Blazor
                new Client
                {
                    ClientId = "BlazorWeb",
                    ClientName = "Blazor Web Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    AllowedScopes =
                    {
                        "ECommerceAPI.Read", "ECommerceAPI.Write",
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    RedirectUris = { "https://localhost:6001/authentication/login-callback" },
                    AllowedCorsOrigins = { "https://localhost:6001" },
                    PostLogoutRedirectUris = { "https://localhost:6001/authentication/logout-callback" }
                },
	            #endregion
            };
        }
        #endregion

        #region Test Users
        public static IEnumerable<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "cancanbolat",
                    Username = "cancanbolat",
                    Password = "123456789",
                    Claims =
                    {
                        new Claim(JwtRegisteredClaimNames.Email, "can@gmail.com"),
                        new Claim("role", "admin"),
                        new Claim("authority", "true"),
                        new Claim(JwtClaimTypes.Name, "Can Canbolat"),
                        new Claim("given_name", "Can")
                    }
                },
                new TestUser
                {
                    SubjectId = "testuser",
                    Username = "testuser",
                    Password = "987654321",
                    Claims =
                    {
                        new Claim(JwtRegisteredClaimNames.Email, "testuser@gmail.com"),
                        new Claim("role", "admin"),
                        new Claim("authority", "true"),
                        new Claim(JwtClaimTypes.Name, "Test User"),
                        new Claim("given_name", "Test")
                    }
                },
                new TestUser
                {
                    SubjectId = "pelliero",
                    Username = "pelliero",
                    Password = "qwertyu",
                    Claims =
                    {
                        new Claim(JwtRegisteredClaimNames.Email, "pelliero@gmail.com"),
                        new Claim("role", "admin"),
                        new Claim("authority", "true"),
                        new Claim(JwtClaimTypes.Name, "Pel Liero"),
                        new Claim("given_name", "Pel")
                    }
                }
            };
        }
        #endregion

        #region IdentityResources
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
                /*,
                new IdentityResource
                {
                    Name = "Roles",
                    DisplayName = "Roles",
                    Description = "User roles",
                    UserClaims = { "role", "authority" }
                }*/
            };
        }

        #endregion
    }
}
