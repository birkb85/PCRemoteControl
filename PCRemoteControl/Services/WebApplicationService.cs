using PCRemoteControl.Hubs;

namespace PCRemoteControl.Services;

public sealed class WebApplicationService
{
    readonly WebApplication app;

    public WebApplicationService()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();

        builder.Services.AddSingleton<InputService>();

        string? port = builder.Configuration["WebProtocolSettings:Port"];
        port ??= "8080";

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
}
