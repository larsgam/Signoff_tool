<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnDataGreen = New System.Windows.Forms.Button()
        Me.btnProcessGreen = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.gbxDailyData = New System.Windows.Forms.GroupBox()
        Me.gbxDailyProcess = New System.Windows.Forms.GroupBox()
        Me.dtpAsofdate = New System.Windows.Forms.DateTimePicker()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Location = New System.Drawing.Point(8, 37)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(839, 583)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.btnDataGreen)
        Me.TabPage1.Controls.Add(Me.btnProcessGreen)
        Me.TabPage1.Controls.Add(Me.btnUpdate)
        Me.TabPage1.Controls.Add(Me.gbxDailyData)
        Me.TabPage1.Controls.Add(Me.gbxDailyProcess)
        Me.TabPage1.Controls.Add(Me.dtpAsofdate)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage1.Size = New System.Drawing.Size(831, 557)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Daily Signoff"
        '
        'btnDataGreen
        '
        Me.btnDataGreen.Location = New System.Drawing.Point(275, 478)
        Me.btnDataGreen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnDataGreen.Name = "btnDataGreen"
        Me.btnDataGreen.Size = New System.Drawing.Size(87, 40)
        Me.btnDataGreen.TabIndex = 10
        Me.btnDataGreen.Text = "All Data Green"
        Me.btnDataGreen.UseVisualStyleBackColor = True
        '
        'btnProcessGreen
        '
        Me.btnProcessGreen.Location = New System.Drawing.Point(154, 478)
        Me.btnProcessGreen.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnProcessGreen.Name = "btnProcessGreen"
        Me.btnProcessGreen.Size = New System.Drawing.Size(87, 40)
        Me.btnProcessGreen.TabIndex = 9
        Me.btnProcessGreen.Text = "All Process Green"
        Me.btnProcessGreen.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(33, 478)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(87, 40)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'gbxDailyData
        '
        Me.gbxDailyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDailyData.Location = New System.Drawing.Point(420, 51)
        Me.gbxDailyData.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbxDailyData.Name = "gbxDailyData"
        Me.gbxDailyData.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbxDailyData.Size = New System.Drawing.Size(389, 396)
        Me.gbxDailyData.TabIndex = 2
        Me.gbxDailyData.TabStop = False
        Me.gbxDailyData.Text = "Data Signoff"
        '
        'gbxDailyProcess
        '
        Me.gbxDailyProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDailyProcess.Location = New System.Drawing.Point(7, 51)
        Me.gbxDailyProcess.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbxDailyProcess.Name = "gbxDailyProcess"
        Me.gbxDailyProcess.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbxDailyProcess.Size = New System.Drawing.Size(389, 396)
        Me.gbxDailyProcess.TabIndex = 1
        Me.gbxDailyProcess.TabStop = False
        Me.gbxDailyProcess.Text = "Process Signoff"
        '
        'dtpAsofdate
        '
        Me.dtpAsofdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAsofdate.Location = New System.Drawing.Point(16, 14)
        Me.dtpAsofdate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpAsofdate.Name = "dtpAsofdate"
        Me.dtpAsofdate.Size = New System.Drawing.Size(94, 20)
        Me.dtpAsofdate.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage2.Size = New System.Drawing.Size(831, 557)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Monthly Reporting"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(855, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 22)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(855, 628)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "CEM Database GUI"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dtpAsofdate As DateTimePicker
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents gbxDailyProcess As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents gbxDailyData As GroupBox
    Friend WithEvents btnProcessGreen As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDataGreen As Button
End Class
