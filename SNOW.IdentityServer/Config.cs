using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNOW.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {

                new ApiResource
                {
                    Name = "api1",
                    Description = "My API",
                    Scopes =
                {
                    new Scope("snowApi", "Snow API")
                 },
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {

                new Client
                {
                    ClientId = "ro.client",
                    ClientName = "test client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        "snowApi"
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {

                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new TestUser
                {
                   SubjectId = "2",
                   Username = "bob",
                   Password = "password"
                }
            };
        }
    }
}
