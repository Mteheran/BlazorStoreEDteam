using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorStore.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorStore.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<IHttpService, HttpService>()
                            .AddScoped<ILocalStorageService, LocalStorageService>()
                            .AddScoped<IAutheticationService, AuthenticationService>();

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();

            builder.Services.AddAuthorizationCore();

            string apiUrl = builder.Configuration["apiUrl"];

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

            await builder.Build().RunAsync();
        }
    }
}
