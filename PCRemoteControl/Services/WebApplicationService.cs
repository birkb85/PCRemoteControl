using PCRemoteControl.Hubs;

namespace PCRemoteControl.Services;

public sealed class WebApplicationService
{
    private WebApplication? app;
    public bool isRunning { get; private set; } = false;

    public void Run(string port)
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();

        builder.Services.AddSingleton<InputService>();

        app = builder.Build();

        app.UseStaticFiles();

        app.MapRazorPages();
        app.MapHub<ControlHub>("/controlhub");

        app.RunAsync($"http://*:{port}");
        isRunning = true;
    }

    public void Stop()
    {
        if (app != null)
        {
            _ = app.StopAsync();
        }
        isRunning = false;
    }
}
