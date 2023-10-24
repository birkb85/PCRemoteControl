using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PCRemoteControl.Services;

public sealed class MouseService
{
    // https://learn.microsoft.com/da-dk/windows/win32/api/winuser/nf-winuser-mouse_event?redirectedfrom=MSDN

    [Flags]
    public enum MouseEventFlags
    {
        Absolute = 0x00008000,
        LeftDown = 0x00000002,
        LeftUp = 0x00000004,
        MiddleDown = 0x00000020,
        MiddleUp = 0x00000040,
        Move = 0x00000001,
        RightDown = 0x00000008,
        RightUp = 0x00000010,
        Wheel = 0x00000800,
        HWheel = 0x00001000
    }

    [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out MousePoint lpMousePoint);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private void SetCursorPosition(int x, int y)
    {
        SetCursorPos(x, y);
    }

    private void SetCursorPosition(MousePoint point)
    {
        SetCursorPos(point.X, point.Y);
    }

    private MousePoint GetCursorPosition()
    {
        MousePoint currentMousePoint;
        var gotPoint = GetCursorPos(out currentMousePoint);
        if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
        return currentMousePoint;
    }

    public void MoveCursor(int amountX, int amountY)
    {
        MouseEvent(MouseEventFlags.Move, amountX, amountY);
    }

    public void LeftClick()
    {
        MouseEvent(MouseEventFlags.LeftDown);
        MouseEvent(MouseEventFlags.LeftUp);
    }

    public void RightClick()
    {
        MouseEvent(MouseEventFlags.RightDown);
        MouseEvent(MouseEventFlags.RightUp);
    }

    public void ScrollVertical(int amount)
    {
        MouseEvent(MouseEventFlags.Wheel, amount);
    }

    public void ScrollHorizontal(int amount)
    {
        MouseEvent(MouseEventFlags.HWheel, amount);
    }

    private void MouseEvent(MouseEventFlags value)
    {
        MousePoint position = GetCursorPosition();
        mouse_event((int)value, position.X, position.Y, 0, 0);
    }

    private void MouseEvent(MouseEventFlags value, int x, int y)
    {
        mouse_event((int)value, x, y, 0, 0);
    }

    private void MouseEvent(MouseEventFlags value, int data)
    {
        MousePoint position = GetCursorPosition();
        mouse_event((int)value, position.X, position.Y, data, 0);
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}