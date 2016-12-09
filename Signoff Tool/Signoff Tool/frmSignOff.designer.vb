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
        Me.btnProcessGreen = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.gbxInput = New System.Windows.Forms.GroupBox()
        Me.tbxCommentInput = New System.Windows.Forms.TextBox()
        Me.btnUpdateInput = New System.Windows.Forms.Button()
        Me.tbxUserInput = New System.Windows.Forms.TextBox()
        Me.tbxInputUserTime = New System.Windows.Forms.TextBox()
        Me.rbnInputRed = New System.Windows.Forms.RadioButton()
        Me.rbnInputGreen = New System.Windows.Forms.RadioButton()
        Me.rbnInputAmber = New System.Windows.Forms.RadioButton()
        Me.gbxDailyData = New System.Windows.Forms.GroupBox()
        Me.gbxDailyProcess = New System.Windows.Forms.GroupBox()
        Me.dtpAsofdate = New System.Windows.Forms.DateTimePicker()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDataGreen = New System.Windows.Forms.Button()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxInput.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Location = New System.Drawing.Point(12, 57)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1259, 897)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.btnDataGreen)
        Me.TabPage1.Controls.Add(Me.btnProcessGreen)
        Me.TabPage1.Controls.Add(Me.btnUpdate)
        Me.TabPage1.Controls.Add(Me.gbxInput)
        Me.TabPage1.Controls.Add(Me.gbxDailyData)
        Me.TabPage1.Controls.Add(Me.gbxDailyProcess)
        Me.TabPage1.Controls.Add(Me.dtpAsofdate)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1251, 864)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Daily Signoff"
        '
        'btnProcessGreen
        '
        Me.btnProcessGreen.Location = New System.Drawing.Point(231, 736)
        Me.btnProcessGreen.Name = "btnProcessGreen"
        Me.btnProcessGreen.Size = New System.Drawing.Size(131, 62)
        Me.btnProcessGreen.TabIndex = 9
        Me.btnProcessGreen.Text = "All Process Green"
        Me.btnProcessGreen.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(50, 736)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(131, 62)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'gbxInput
        '
        Me.gbxInput.BackColor = System.Drawing.Color.Transparent
        Me.gbxInput.Controls.Add(Me.tbxCommentInput)
        Me.gbxInput.Controls.Add(Me.btnUpdateInput)
        Me.gbxInput.Controls.Add(Me.tbxUserInput)
        Me.gbxInput.Controls.Add(Me.tbxInputUserTime)
        Me.gbxInput.Controls.Add(Me.rbnInputRed)
        Me.gbxInput.Controls.Add(Me.rbnInputGreen)
        Me.gbxInput.Controls.Add(Me.rbnInputAmber)
        Me.gbxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxInput.Location = New System.Drawing.Point(654, 724)
        Me.gbxInput.Name = "gbxInput"
        Me.gbxInput.Size = New System.Drawing.Size(559, 107)
        Me.gbxInput.TabIndex = 5
        Me.gbxInput.TabStop = False
        Me.gbxInput.Text = "Input control"
        '
        'tbxCommentInput
        '
        Me.tbxCommentInput.Enabled = False
        Me.tbxCommentInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCommentInput.Location = New System.Drawing.Point(288, 25)
        Me.tbxCommentInput.Multiline = True
        Me.tbxCommentInput.Name = "tbxCommentInput"
        Me.tbxCommentInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxCommentInput.Size = New System.Drawing.Size(240, 72)
        Me.tbxCommentInput.TabIndex = 6
        '
        'btnUpdateInput
        '
        Me.btnUpdateInput.Location = New System.Drawing.Point(194, 66)
        Me.btnUpdateInput.Name = "btnUpdateInput"
        Me.btnUpdateInput.Size = New System.Drawing.Size(88, 35)
        Me.btnUpdateInput.TabIndex = 7
        Me.btnUpdateInput.Text = "Update"
        Me.btnUpdateInput.UseVisualStyleBackColor = True
        '
        'tbxUserInput
        '
        Me.tbxUserInput.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbxUserInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxUserInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxUserInput.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.tbxUserInput.Location = New System.Drawing.Point(13, 60)
        Me.tbxUserInput.Name = "tbxUserInput"
        Me.tbxUserInput.Size = New System.Drawing.Size(177, 14)
        Me.tbxUserInput.TabIndex = 7
        Me.tbxUserInput.Text = "Not Signed off"
        '
        'tbxInputUserTime
        '
        Me.tbxInputUserTime.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbxInputUserTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxInputUserTime.Enabled = False
        Me.tbxInputUserTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxInputUserTime.ForeColor = System.Drawing.Color.Gray
        Me.tbxInputUserTime.Location = New System.Drawing.Point(13, 60)
        Me.tbxInputUserTime.Name = "tbxInputUserTime"
        Me.tbxInputUserTime.Size = New System.Drawing.Size(100, 14)
        Me.tbxInputUserTime.TabIndex = 2
        '
        'rbnInputRed
        '
        Me.rbnInputRed.AutoSize = True
        Me.rbnInputRed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnInputRed.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rbnInputRed.Location = New System.Drawing.Point(205, 32)
        Me.rbnInputRed.Name = "rbnInputRed"
        Me.rbnInputRed.Size = New System.Drawing.Size(64, 24)
        Me.rbnInputRed.TabIndex = 3
        Me.rbnInputRed.TabStop = True
        Me.rbnInputRed.Text = "Red"
        Me.rbnInputRed.UseVisualStyleBackColor = True
        '
        'rbnInputGreen
        '
        Me.rbnInputGreen.AutoSize = True
        Me.rbnInputGreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnInputGreen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rbnInputGreen.Location = New System.Drawing.Point(13, 32)
        Me.rbnInputGreen.Name = "rbnInputGreen"
        Me.rbnInputGreen.Size = New System.Drawing.Size(79, 24)
        Me.rbnInputGreen.TabIndex = 1
        Me.rbnInputGreen.TabStop = True
        Me.rbnInputGreen.Text = "Green"
        Me.rbnInputGreen.UseVisualStyleBackColor = True
        '
        'rbnInputAmber
        '
        Me.rbnInputAmber.AutoSize = True
        Me.rbnInputAmber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnInputAmber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rbnInputAmber.Location = New System.Drawing.Point(109, 32)
        Me.rbnInputAmber.Name = "rbnInputAmber"
        Me.rbnInputAmber.Size = New System.Drawing.Size(81, 24)
        Me.rbnInputAmber.TabIndex = 2
        Me.rbnInputAmber.TabStop = True
        Me.rbnInputAmber.Text = "Amber"
        Me.rbnInputAmber.UseVisualStyleBackColor = True
        '
        'gbxDailyData
        '
        Me.gbxDailyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDailyData.Location = New System.Drawing.Point(630, 78)
        Me.gbxDailyData.Name = "gbxDailyData"
        Me.gbxDailyData.Size = New System.Drawing.Size(583, 609)
        Me.gbxDailyData.TabIndex = 2
        Me.gbxDailyData.TabStop = False
        Me.gbxDailyData.Text = "Data Signoff"
        '
        'gbxDailyProcess
        '
        Me.gbxDailyProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxDailyProcess.Location = New System.Drawing.Point(11, 78)
        Me.gbxDailyProcess.Name = "gbxDailyProcess"
        Me.gbxDailyProcess.Size = New System.Drawing.Size(583, 609)
        Me.gbxDailyProcess.TabIndex = 1
        Me.gbxDailyProcess.TabStop = False
        Me.gbxDailyProcess.Text = "Process Signoff"
        '
        'dtpAsofdate
        '
        Me.dtpAsofdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAsofdate.Location = New System.Drawing.Point(24, 21)
        Me.dtpAsofdate.Name = "dtpAsofdate"
        Me.dtpAsofdate.Size = New System.Drawing.Size(139, 26)
        Me.dtpAsofdate.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1251, 864)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1283, 33)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(50, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(124, 30)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'btnDataGreen
        '
        Me.btnDataGreen.Location = New System.Drawing.Point(412, 736)
        Me.btnDataGreen.Name = "btnDataGreen"
        Me.btnDataGreen.Size = New System.Drawing.Size(131, 62)
        Me.btnDataGreen.TabIndex = 10
        Me.btnDataGreen.Text = "All Data Green"
        Me.btnDataGreen.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1283, 966)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "p"
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gbxInput.ResumeLayout(False)
        Me.gbxInput.PerformLayout()
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
    Friend WithEvents rbnInputRed As RadioButton
    Friend WithEvents rbnInputAmber As RadioButton
    Friend WithEvents rbnInputGreen As RadioButton
    Friend WithEvents gbxInput As GroupBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tbxInputUserTime As TextBox
    Friend WithEvents tbxCommentInput As TextBox
    Friend WithEvents tbxUserInput As TextBox
    Friend WithEvents btnUpdateInput As Button
    Friend WithEvents gbxDailyData As GroupBox
    Friend WithEvents btnProcessGreen As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDataGreen As Button
End Class
