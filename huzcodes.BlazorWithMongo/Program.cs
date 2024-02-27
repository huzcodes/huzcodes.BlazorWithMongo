using huzcodes.BlazorWithMongo.Components;
using huzcodes.BlazorWithMongo.Models;
using huzcodes.BlazorWithMongo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<BlazorDatabaseSettings>(
    builder.Configuration.GetSection("BlazorDatabase"));

builder.Services.AddSingleton<BooksService>();
builder.Services.AddTransient<IProvider, Provider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
