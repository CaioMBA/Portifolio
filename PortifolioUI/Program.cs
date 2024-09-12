using Microsoft.Extensions.Options;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioInjections;
using PortifolioUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCors();

var AppConfigurations = new AppSettingsModel();
new ConfigureFromConfigurationOptions<AppSettingsModel>(
              builder.Configuration.GetSection("Settings"))
                  .Configure(AppConfigurations);

InjectionConfiguration.ConfigureDependencies(builder.Services, AppConfigurations);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(opt => opt.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
