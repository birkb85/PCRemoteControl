using Microsoft.AspNetCore.SignalR;
using PCRemoteControl.Services;

namespace PCRemoteControl.Hubs;

public class ControlHub : Hub
{
    private readonly InputService inputService;
    private readonly ILogger<WindowsBackgroundService> logger;

    public ControlHub(
        InputService inputService,
        ILogger<WindowsBackgroundService> logger)
    {
        this.inputService = inputService;
        this.logger = logger;
    }

    public void MouseMove(int amountX, int amountY)
    {
        inputService.MouseMove(amountX, amountY);
    }
}
