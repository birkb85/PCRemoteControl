namespace PCRemoteControl.Forms;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components=new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        connectLabel=new Label();
        notifyIcon=new NotifyIcon(components);
        contextMenuStrip=new ContextMenuStrip(components);
        openToolStripMenuItem=new ToolStripMenuItem();
        closePCRemoteControlToolStripMenuItem=new ToolStripMenuItem();
        urlLabel=new Label();
        showAtStartupCheckBox=new CheckBox();
        portTextBox=new TextBox();
        portLabel=new Label();
        startStopButton=new Button();
        contextMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // connectLabel
        // 
        connectLabel.AutoSize=true;
        connectLabel.Font=new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        connectLabel.Location=new Point(12, 46);
        connectLabel.Name="connectLabel";
        connectLabel.Size=new Size(359, 20);
        connectLabel.TabIndex=0;
        connectLabel.Text="Connect to PC Remote Control with the following url:";
        // 
        // notifyIcon
        // 
        notifyIcon.ContextMenuStrip=contextMenuStrip;
        notifyIcon.Icon=(Icon)resources.GetObject("notifyIcon.Icon");
        notifyIcon.Text="PC Remote Control";
        notifyIcon.Visible=true;
        notifyIcon.MouseDoubleClick+=notifyIcon_MouseDoubleClick;
        // 
        // contextMenuStrip
        // 
        contextMenuStrip.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, closePCRemoteControlToolStripMenuItem });
        contextMenuStrip.Name="contextMenuStrip1";
        contextMenuStrip.Size=new Size(209, 48);
        // 
        // openToolStripMenuItem
        // 
        openToolStripMenuItem.Name="openToolStripMenuItem";
        openToolStripMenuItem.Size=new Size(208, 22);
        openToolStripMenuItem.Text="Open";
        openToolStripMenuItem.Click+=openToolStripMenuItem_Click;
        // 
        // closePCRemoteControlToolStripMenuItem
        // 
        closePCRemoteControlToolStripMenuItem.Name="closePCRemoteControlToolStripMenuItem";
        closePCRemoteControlToolStripMenuItem.Size=new Size(208, 22);
        closePCRemoteControlToolStripMenuItem.Text="Close PC Remote Control";
        closePCRemoteControlToolStripMenuItem.Click+=closePCRemoteControlToolStripMenuItem_Click;
        // 
        // urlLabel
        // 
        urlLabel.AutoSize=true;
        urlLabel.Font=new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        urlLabel.Location=new Point(12, 66);
        urlLabel.Name="urlLabel";
        urlLabel.Size=new Size(94, 37);
        urlLabel.TabIndex=1;
        urlLabel.Text="http://";
        // 
        // showAtStartupCheckBox
        // 
        showAtStartupCheckBox.AutoSize=true;
        showAtStartupCheckBox.Location=new Point(327, 119);
        showAtStartupCheckBox.Margin=new Padding(3, 4, 3, 4);
        showAtStartupCheckBox.Name="showAtStartupCheckBox";
        showAtStartupCheckBox.Size=new Size(214, 24);
        showAtStartupCheckBox.TabIndex=2;
        showAtStartupCheckBox.Text="Show this window at startup";
        showAtStartupCheckBox.UseVisualStyleBackColor=true;
        showAtStartupCheckBox.CheckedChanged+=showAtStartupCheckBox_CheckedChanged;
        // 
        // portTextBox
        // 
        portTextBox.Location=new Point(56, 14);
        portTextBox.Margin=new Padding(3, 4, 3, 4);
        portTextBox.Name="portTextBox";
        portTextBox.Size=new Size(114, 27);
        portTextBox.TabIndex=4;
        portTextBox.Text="test";
        // 
        // portLabel
        // 
        portLabel.AutoSize=true;
        portLabel.Location=new Point(12, 17);
        portLabel.Name="portLabel";
        portLabel.Size=new Size(38, 20);
        portLabel.TabIndex=5;
        portLabel.Text="Port:";
        // 
        // startStopButton
        // 
        startStopButton.Location=new Point(176, 12);
        startStopButton.Name="startStopButton";
        startStopButton.Size=new Size(142, 31);
        startStopButton.TabIndex=6;
        startStopButton.Text="Start Server";
        startStopButton.UseVisualStyleBackColor=true;
        startStopButton.Click+=startStopButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions=new SizeF(8F, 20F);
        AutoScaleMode=AutoScaleMode.Font;
        ClientSize=new Size(553, 156);
        Controls.Add(startStopButton);
        Controls.Add(portLabel);
        Controls.Add(portTextBox);
        Controls.Add(showAtStartupCheckBox);
        Controls.Add(urlLabel);
        Controls.Add(connectLabel);
        Font=new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle=FormBorderStyle.FixedSingle;
        Icon=(Icon)resources.GetObject("$this.Icon");
        Margin=new Padding(3, 4, 3, 4);
        MaximizeBox=false;
        MdiChildrenMinimizedAnchorBottom=false;
        Name="MainForm";
        Text="PC Remote Control";
        FormClosing+=MainForm_FormClosing;
        Shown+=MainForm_Shown;
        Resize+=MainForm_Resize;
        contextMenuStrip.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label connectLabel;
    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem closePCRemoteControlToolStripMenuItem;
    private Label urlLabel;
    private CheckBox showAtStartupCheckBox;
    private TextBox portTextBox;
    private Label portLabel;
    private Button startStopButton;
}