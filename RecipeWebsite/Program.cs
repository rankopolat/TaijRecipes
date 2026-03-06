using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RecipeWebsite;
using RecipeWebsite.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Supabase config — replace with your project values
var supabaseUrl = builder.Configuration["Supabase:Url"] ?? "https://YOUR_PROJECT.supabase.co";
var supabaseKey = builder.Configuration["Supabase:AnonKey"] ?? "YOUR_ANON_KEY";

// Services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
});

var supabaseService = new SupabaseService(supabaseUrl, supabaseKey);
builder.Services.AddSingleton(supabaseService);
builder.Services.AddSingleton<StorageService>();
builder.Services.AddSingleton<RecipeService>();
builder.Services.AddSingleton<CommentService>();
builder.Services.AddSingleton<ProfileService>();

builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<AuthenticationStateProvider>(sp => sp.GetRequiredService<AuthService>());
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

// Initialize Supabase client
await supabaseService.InitializeAsync();

// Restore auth session from local storage
var authService = host.Services.GetRequiredService<AuthService>();
await authService.InitializeAsync();

await host.RunAsync();
