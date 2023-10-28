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

    public void MouseLeftClick()
    {
        inputService.MouseLeftClick();
    }

    public void MouseRightClick()
    {
        inputService.MouseRightClick();
    }

    public void MouseScrollVertical(int amount)
    {
        inputService.MouseScrollVertical(amount);
    }

    public void MouseScrollHorizontal(int amount)
    {
        inputService.MouseScrollHorizontal(amount);
    }

    public void Keyboard(string text)
    {
        inputService.Keyboard(text);
    }

    public void KeyboardBackspace()
    {
        inputService.KeyboardBackspace();
    }

    public void KeyboardEnter()
    {
        inputService.KeyboardEnter();
    }

    public void KeyboardLeftArrow()
    {
        inputService.KeyboardLeftArrow();
    }

    public void KeyboardRightArrow()
    {
        inputService.KeyboardRightArrow();
    }

    public void KeyboardPlayPause()
    {
        inputService.KeyboardPlayPause();
    }

    public void KeyboardVolumeMute()
    {
        inputService.KeyboardVolumeMute();
    }

    public void KeyboardVolumeDown()
    {
        inputService.KeyboardVolumeDown();
    }

    public void KeyboardVolumeUp()
    {
        inputService.KeyboardVolumeUp();
    }

    public void KeyboardEscape()
    {
        inputService.KeyboardEscape();
    }
}
