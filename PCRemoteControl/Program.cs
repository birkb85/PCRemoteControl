// Creating a Windows Service including installer by following theese tutorials:
// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service?pivots=dotnet-7-0
// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service-with-installer?tabs=wix
// https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-7.0&tabs=visual-studio#current-directory-and-content-root

using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using PCRemoteControl.Services;
using PCRemoteControl.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

// OBS! Background Services cannot access user window....
// So maybe it is just better to run the application with a startupscript after user logs on...
// https://learn.microsoft.com/en-us/answers/questions/1003314/can-i-use-user32-dll-in-windows-service
// https://stackoverflow.com/questions/62117176/how-to-use-win32api-in-c-sharp-windows-service-app
//builder.Services.AddWindowsService(options =>
//{
//    options.ServiceName = "PC Remote Control Service";
//});

//if (OperatingSystem.IsWindows())
//{
//    LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);
//}

builder.Services.AddSingleton<InputService>();
//builder.Services.AddHostedService<WindowsBackgroundService>();

string? url = builder.Configuration["WebProtocolSettings:Url"];
if (url == null)
{
    url = "*";
}
string? port = builder.Configuration["WebProtocolSettings:Port"];
if (port == null)
{
    port = "8080";
}

var app = builder.Build();

app.MapRazorPages();
app.MapHub<ControlHub>("/controlhub");

app.Run($"http://{url}:{port}");