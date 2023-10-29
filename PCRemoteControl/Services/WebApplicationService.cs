using PCRemoteControl.Hubs;

namespace PCRemoteControl.Services;

public sealed class WebApplicationService
{
    readonly WebApplication app;
    readonly string port;

    public WebApplicationService()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();

        builder.Services.AddSingleton<InputService>();

        string? configPort = builder.Configuration["WebProtocolSettings:Port"];
        configPort ??= "8080";
        port = configPort;

        app = builder.Build();

        app.UseStaticFiles();

        app.MapRazorPages();
        app.MapHub<ControlHub>("/controlhub");

        app.RunAsync($"http://*:{port}");
    }

    public void Stop()
    {
        _ = app.StopAsync();
    }

    public string GetPort()
    {
        return port;
    }
}
