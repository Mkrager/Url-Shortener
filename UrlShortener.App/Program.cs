using Microsoft.AspNetCore.Authentication.Cookies;
using UrlShortener.App.Contracts;
using UrlShortener.App.Infrastructure.HttpHandlers;
using UrlShortener.App.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/authentication/unAuthorizedHandler";
        options.AccessDeniedPath = "/authentication/accessDeniedHandler";
    });

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IShortUrlDataService, ShortUrlDataService>();

builder.Services.AddTransient<AuthHeaderHandler>();

var baseUrl = builder.Configuration["App:BaseUrl"];
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
})
.AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();