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
        label=new Label();
        notifyIcon=new NotifyIcon(components);
        contextMenuStrip=new ContextMenuStrip(components);
        openToolStripMenuItem=new ToolStripMenuItem();
        closePCRemoteControlToolStripMenuItem=new ToolStripMenuItem();
        urlLabel=new Label();
        contextMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // label
        // 
        label.AutoSize=true;
        label.Font=new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
        label.Location=new Point(12, 9);
        label.Name="label";
        label.Size=new Size(359, 20);
        label.TabIndex=0;
        label.Text="Connect to PC Remote Control with the following url:";
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
        urlLabel.Location=new Point(12, 29);
        urlLabel.Name="urlLabel";
        urlLabel.Size=new Size(94, 37);
        urlLabel.TabIndex=1;
        urlLabel.Text="http://";
        // 
        // MainForm
        // 
        AutoScaleDimensions=new SizeF(7F, 15F);
        AutoScaleMode=AutoScaleMode.Font;
        ClientSize=new Size(384, 161);
        Controls.Add(urlLabel);
        Controls.Add(label);
        FormBorderStyle=FormBorderStyle.FixedSingle;
        Icon=(Icon)resources.GetObject("$this.Icon");
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

    private Label label;
    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStrip;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem closePCRemoteControlToolStripMenuItem;
    private Label urlLabel;
}