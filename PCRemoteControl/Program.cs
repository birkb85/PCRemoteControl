using PCRemoteControl.Forms;

namespace PCRemoteControl;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    static Mutex mutex = new Mutex(true, "{1729B10F-EBDA-4EBC-BE01-B7EC33D618D1}");
    [STAThread]
    static void Main()
    {
        if (mutex.WaitOne(TimeSpan.Zero, true))
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
        else
        {
            MessageBox.Show("PC Remote Control is already running.");
        }
    }
}