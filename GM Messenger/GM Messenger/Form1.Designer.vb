<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MsgBox = New System.Windows.Forms.TextBox()
        Me.sendBTN = New System.Windows.Forms.Button()
        Me.FilesBTN = New System.Windows.Forms.Button()
        Me.stgBTN = New System.Windows.Forms.Button()
        Me.SendBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'MsgBox
        '
        Me.MsgBox.Location = New System.Drawing.Point(12, 12)
        Me.MsgBox.Multiline = True
        Me.MsgBox.Name = "MsgBox"
        Me.MsgBox.ReadOnly = True
        Me.MsgBox.Size = New System.Drawing.Size(318, 270)
        Me.MsgBox.TabIndex = 0
        '
        'sendBTN
        '
        Me.sendBTN.Location = New System.Drawing.Point(255, 286)
        Me.sendBTN.Name = "sendBTN"
        Me.sendBTN.Size = New System.Drawing.Size(75, 23)
        Me.sendBTN.TabIndex = 1
        Me.sendBTN.Text = "Send"
        Me.sendBTN.UseVisualStyleBackColor = True
        '
        'FilesBTN
        '
        Me.FilesBTN.Location = New System.Drawing.Point(255, 315)
        Me.FilesBTN.Name = "FilesBTN"
        Me.FilesBTN.Size = New System.Drawing.Size(75, 23)
        Me.FilesBTN.TabIndex = 2
        Me.FilesBTN.Text = "Files"
        Me.FilesBTN.UseVisualStyleBackColor = True
        '
        'stgBTN
        '
        Me.stgBTN.Location = New System.Drawing.Point(12, 315)
        Me.stgBTN.Name = "stgBTN"
        Me.stgBTN.Size = New System.Drawing.Size(75, 23)
        Me.stgBTN.TabIndex = 3
        Me.stgBTN.Text = "Settings"
        Me.stgBTN.UseVisualStyleBackColor = True
        '
        'SendBox
        '
        Me.SendBox.Location = New System.Drawing.Point(12, 288)
        Me.SendBox.Name = "SendBox"
        Me.SendBox.Size = New System.Drawing.Size(237, 20)
        Me.SendBox.TabIndex = 4
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 354)
        Me.Controls.Add(Me.SendBox)
        Me.Controls.Add(Me.stgBTN)
        Me.Controls.Add(Me.FilesBTN)
        Me.Controls.Add(Me.sendBTN)
        Me.Controls.Add(Me.MsgBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "GM Messenger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MsgBox As TextBox
    Friend WithEvents sendBTN As Button
    Friend WithEvents FilesBTN As Button
    Friend WithEvents stgBTN As Button
    Friend WithEvents SendBox As TextBox
End Class
