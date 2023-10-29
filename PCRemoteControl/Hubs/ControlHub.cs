using Microsoft.AspNetCore.SignalR;
using PCRemoteControl.Services;

namespace PCRemoteControl.Hubs;

public class ControlHub : Hub
{
    private readonly InputService inputService;
    private readonly ILogger<ControlHub> logger;

    public ControlHub(
        InputService inputService,
        ILogger<ControlHub> logger)
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
        inputService.KeyboardVK(InputService.VK_BACK);
    }

    public void KeyboardEnter()
    {
        inputService.KeyboardVK(InputService.VK_RETURN);
    }

    public void KeyboardLeftArrow()
    {
        inputService.KeyboardVK(InputService.VK_LEFT);
    }

    public void KeyboardRightArrow()
    {
        inputService.KeyboardVK(InputService.VK_RIGHT);
    }

    public void KeyboardPlayPause()
    {
        inputService.KeyboardVK(InputService.VK_MEDIA_PLAY_PAUSE);
    }

    public void KeyboardVolumeMute()
    {
        inputService.KeyboardVK(InputService.VK_VOLUME_MUTE);
    }

    public void KeyboardVolumeDown()
    {
        inputService.KeyboardVK(InputService.VK_VOLUME_DOWN);
    }

    public void KeyboardVolumeUp()
    {
        inputService.KeyboardVK(InputService.VK_VOLUME_UP);
    }

    public void KeyboardEscape()
    {
        inputService.KeyboardVK(InputService.VK_ESCAPE);
    }
}
