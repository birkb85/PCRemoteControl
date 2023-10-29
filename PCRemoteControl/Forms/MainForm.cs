using PCRemoteControl.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCRemoteControl.Forms;
public partial class MainForm : Form
{
    readonly WebApplicationService webApplicationService;
    bool shouldCloseForm = false;

    public MainForm()
    {
        InitializeComponent();

        webApplicationService = new();
    }

    private void MainForm_Shown(object sender, EventArgs e)
    {
        notifyIcon.Visible = true;
        MinimizeToTray();
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
}
