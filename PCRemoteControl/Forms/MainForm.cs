using PCRemoteControl.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCRemoteControl.Forms;
public partial class MainForm : Form
{
    readonly SettingsService settingsService;
    readonly WebApplicationService webApplicationService;
    bool shouldCloseForm = false;

    public MainForm()
    {
        InitializeComponent();

        settingsService = new SettingsService();

        string port = settingsService.ServerPort;
        portTextBox.Text = port;

        bool showAtStartup = settingsService.ShowAtStartup;
        showAtStartupCheckBox.Checked = showAtStartup;

        webApplicationService = new();
        StartServer();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        notifyIcon.Visible = true;

        if (!settingsService.ShowAtStartup)
        {
            MinimizeToTray();
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (shouldCloseForm)
        {
            webApplicationService.Stop();
        }
        else
        {
            e.Cancel = true;
            MinimizeToTray();
        }
    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
        if (this.WindowState == FormWindowState.Minimized)
        {
            MinimizeToTray();
        }
    }

    private void MinimizeToTray()
    {
        Hide();
    }

    private void OpenFromTray()
    {
        if (!Visible)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
        else
        {
            BringToFront();
        }
    }

    private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        OpenFromTray();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFromTray();
    }

    private void closePCRemoteControlToolStripMenuItem_Click(object sender, EventArgs e)
    {
        shouldCloseForm = true;
        Close();
    }

    private void showAtStartupCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        settingsService.ShowAtStartup = showAtStartupCheckBox.Checked;
        settingsService.Save();
        settingsService.Reload();
    }

    private void startStopButton_Click(object sender, EventArgs e)
    {
        if (webApplicationService.isRunning)
        {
            StopServer();
        }
        else
        {
            StartServer();
        }
    }

    private void StartServer()
    {
        string port = portTextBox.Text;
        if (port != settingsService.ServerPort)
        {
            settingsService.ServerPort = port;
            settingsService.Save();
            settingsService.Reload();
        }

        webApplicationService.Run(port);

        portTextBox.Enabled = false;
        startStopButton.Text = "Stop Server";

        string hostName = Dns.GetHostName();
        IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);
        string url = "";
        foreach (IPAddress ipAddress in ipHostEntry.AddressList)
        {
            if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                url = $"http://{ipAddress.ToString()}:{port}";
            }
        }
        urlLabel.Text = url;
    }

    private void StopServer()
    {
        webApplicationService.Stop();

        portTextBox.Enabled = true;
        startStopButton.Text = "Start Server";

        urlLabel.Text = "Start server to display url";
    }
}
