using Blazored.Modal;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("ECommerceAPI", hc =>
            {
                hc.BaseAddress = new Uri("https://localhost:5001");
            })
           .AddHttpMessageHandler(mh =>
           {
               var handler = mh.GetService<AuthorizationMessageHandler>()
               .ConfigureHandler(
                   authorizedUrls: new[] { "https://localhost:5001" },
                   scopes: new[] { "ECommerceAPI.Read", "ECommerceAPI.Write" }
                   );

               return handler;
           });

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("ECommerceAPI"));

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            builder.Services.AddAntDesign();

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
