using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace WebClient.Net
{
    public class AzureAuthorizationMessageHandler: AuthorizationMessageHandler 
    {
        public AzureAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(provider, navigation)
        {
            ConfigureHandler(
                new [] {"https://localhost:7016/"},
                new [] { "api://a5ee5b5b-fd23-4ada-a7d2-6e65f8f6637d/Inventory.Read" });
        }
    }
}