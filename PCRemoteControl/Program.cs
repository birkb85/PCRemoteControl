// Creating a Windows Service including installer by following theese tutorials:
// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service?pivots=dotnet-7-0
// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service-with-installer?tabs=wix

using PCRemoteControl;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using PCRemoteControl.Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "PC Remote Control Service";
});

if (OperatingSystem.IsWindows())
{
    LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);
}

builder.Services.AddSingleton<InputService>();
builder.Services.AddHostedService<WindowsBackgroundService>();

IHost host = builder.Build();
host.Run();