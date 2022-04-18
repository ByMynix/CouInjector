<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits MetroFramework.Forms.MetroForm

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.MetroProgressSpinner1 = New MetroFramework.Controls.MetroProgressSpinner()
        Me.MetroProgressBar1 = New MetroFramework.Controls.MetroProgressBar()
        Me.SuspendLayout()
        '
        'MetroProgressSpinner1
        '
        Me.MetroProgressSpinner1.Location = New System.Drawing.Point(132, 63)
        Me.MetroProgressSpinner1.Maximum = 100
        Me.MetroProgressSpinner1.Name = "MetroProgressSpinner1"
        Me.MetroProgressSpinner1.Size = New System.Drawing.Size(146, 146)
        Me.MetroProgressSpinner1.Speed = 2.0!
        Me.MetroProgressSpinner1.TabIndex = 1
        Me.MetroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroProgressSpinner1.UseSelectable = True
        '
        'MetroProgressBar1
        '
        Me.MetroProgressBar1.Location = New System.Drawing.Point(23, 215)
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        Me.MetroProgressBar1.Size = New System.Drawing.Size(366, 23)
        Me.MetroProgressBar1.TabIndex = 2
        Me.MetroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 242)
        Me.Controls.Add(Me.MetroProgressBar1)
        Me.Controls.Add(Me.MetroProgressSpinner1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Red
        Me.Text = "Updating..."
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.TransparencyKey = System.Drawing.Color.Snow
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MetroProgressSpinner1 As MetroFramework.Controls.MetroProgressSpinner
    Friend WithEvents MetroProgressBar1 As MetroFramework.Controls.MetroProgressBar
End Class
