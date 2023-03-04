using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PoliciesBlazorApp;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        options.Debounce = true;
        //options.Immediate = false;

    })
    .AddMaterialProviders()
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
    //.AddMaterialIcons();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44391") });


await builder.Build().RunAsync();
