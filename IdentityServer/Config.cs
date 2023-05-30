using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        /// <summary>
        /// API范围
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("gatewayScope")
        };

        /// <summary>
        /// API资源
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("server", "服务")
            {
                Scopes = {"gatewayScope"}
            }
        };

        /// <summary>
        /// 客户端
        /// </summary>
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                  ClientId = "test",
                  ClientName = "测试客户端",
                  ClientSecrets = { new Secret("test".Sha256())},
                  AllowedGrantTypes = {GrantType.ResourceOwnerPassword },
                  AllowedScopes = {"gatewayScope"}


            }

        };



        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser 
                {
                    Username = "Pthero",
                    Password = "123456",
                    SubjectId = "1"
                }
            };
        }
    }
    public class UserInfo
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
