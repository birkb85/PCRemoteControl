using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PCRemoteControl.Services.MouseService;

namespace PCRemoteControl.Services;

public sealed class InputService
{
    // Source: https://www.codeproject.com/Articles/5264831/How-to-Send-Inputs-using-Csharp
    // Keyboard virtual keycodes: https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    // Keyboard scancodes: https://www.win.tue.nl/~aeb/linux/kbd/scancodes-1.html
    // Keyboard unicodes: https://www.compart.com/en/unicode/U+0077

    // ----
    // SendInput function
    // ----
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mi;
        [FieldOffset(0)] public KeyboardInput ki;
        [FieldOffset(0)] public HardwareInput hi;
    }

    public struct Input
    {
        public int type;
        public InputUnion u;
    }

    [Flags]
    public enum InputType
    {
        Mouse = 0,
        Keyboard = 1,
        Hardware = 2
    }

    [Flags]
    public enum KeyEventF
    {
        KeyDown = 0x0000,
        ExtendedKey = 0x0001,
        KeyUp = 0x0002,
        Unicode = 0x0004,
        Scancode = 0x0008
    }

    [Flags]
    public enum MouseEventF
    {
        Absolute = 0x8000,
        HWheel = 0x01000,
        Move = 0x0001,
        MoveNoCoalesce = 0x2000,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        VirtualDesk = 0x4000,
        Wheel = 0x0800,
        XDown = 0x0080,
        XUp = 0x0100
    }

    private static int WHEEL_DELTA = 120;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();

    // ----
    // GetCursorPos function
    // ----
    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    // ----
    // SetCursorPos function
    // ----
    [DllImport("User32.dll")]
    public static extern bool SetCursorPos(int x, int y);

    // ----
    // Mouse
    // ----
    public void TestMouse()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dx = 100,
                        dy = 100,
                        dwFlags = (uint)(MouseEventF.Move | MouseEventF.RightDown),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint)MouseEventF.RightUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void MouseMove(int amountX, int amountY)
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dx = amountX,
                        dy = amountY,
                        dwFlags = (uint)MouseEventF.Move,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void MouseLeftClick()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint)MouseEventF.LeftDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint)MouseEventF.LeftUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void MouseRightClick()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint)MouseEventF.RightDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dwFlags = (uint)MouseEventF.RightUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void MouseScrollVertical(int amount)
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        mouseData = (uint)amount,
                        dwFlags = (uint)MouseEventF.Wheel,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void MouseScrollHorizontal(int amount)
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int) InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        mouseData = (uint)amount,
                        dwFlags = (uint)MouseEventF.HWheel,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    // ----
    // Keyboard
    // ----
    public void TestKeyboard()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11, // W
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11, // W
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void Keyboard(char character)
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = character,
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Unicode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = character,
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Unicode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void Keyboard(string text)
    {
        if (string.IsNullOrEmpty(text)) return;

        List<Input> inputList = new();
        for (int i = 0; i < text.Length; i++)
        {
            Input input = new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = text[i],
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Unicode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            };
            inputList.Add(input);

            input = new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = text[i],
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Unicode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            };
            inputList.Add(input);
        }

        Input[] inputs = inputList.ToArray();
        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardBackspace()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x08,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x08,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardEnter()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x0d,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x0d,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardLeftArrow()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x25,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x25,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardRightArrow()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x27,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x27,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardPlayPause()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xb3,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xb3,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardVolumeMute()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xad,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xad,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardVolumeDown()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xae,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xae,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardVolumeUp()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xaf,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0xaf,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void KeyboardEscape()
    {
        Input[] inputs = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x1b,
                        dwFlags = (uint)KeyEventF.KeyDown,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0x1b,
                        dwFlags = (uint)KeyEventF.KeyUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }
}