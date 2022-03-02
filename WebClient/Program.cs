using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebClient;
using WebClient.Net;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AzureAuthorizationMessageHandler>();
builder.Services.AddHttpClient("myapi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7016/");    
}).AddHttpMessageHandler<AzureAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://a5ee5b5b-fd23-4ada-a7d2-6e65f8f6637d/Inventory.Read");
});

await builder.Build().RunAsync();
