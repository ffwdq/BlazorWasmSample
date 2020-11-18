using System;
using System.Net.Http;
using BlazorWasmSample.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmSample
{
    public static class DependencyInjectionServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, string baseAddress)
        {
            services.AddScoped<IInternationalizationService, InternationalizationService>();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            return services;
        }
    }
}
