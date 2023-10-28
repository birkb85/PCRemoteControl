using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using PCRemoteControl.Services;
using PCRemoteControl.Hubs;
using System.Runtime.InteropServices;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

if (OperatingSystem.IsWindows())
{
    LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);
}

builder.Services.AddSingleton<InputService>();

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

app.UseStaticFiles();

app.MapRazorPages();
app.MapHub<ControlHub>("/controlhub");

app.Run($"http://{url}:{port}");