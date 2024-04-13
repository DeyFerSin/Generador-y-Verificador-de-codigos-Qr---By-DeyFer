<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    'Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Modelo = New System.Windows.Forms.ComboBox()
        Me.Status_ = New System.Windows.Forms.Label()
        Me.Buffer_ = New System.Windows.Forms.TextBox()
        Me.llamados = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPortEscaner = New System.IO.Ports.SerialPort(Me.components)
        Me.Final = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(11, 692)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Codigo:"
        '
        'Modelo
        '
        Me.Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Modelo.FormattingEnabled = True
        Me.Modelo.Location = New System.Drawing.Point(125, 689)
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Size = New System.Drawing.Size(696, 39)
        Me.Modelo.TabIndex = 2
        '
        'Status_
        '
        Me.Status_.Font = New System.Drawing.Font("Microsoft Sans Serif", 150.0!)
        Me.Status_.Location = New System.Drawing.Point(0, 98)
        Me.Status_.Name = "Status_"
        Me.Status_.Size = New System.Drawing.Size(833, 587)
        Me.Status_.TabIndex = 3
        Me.Status_.Text = "Label2"
        Me.Status_.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Buffer_
        '
        Me.Buffer_.Enabled = False
        Me.Buffer_.Location = New System.Drawing.Point(5, 748)
        Me.Buffer_.Name = "Buffer_"
        Me.Buffer_.Size = New System.Drawing.Size(100, 20)
        Me.Buffer_.TabIndex = 4
        '
        'llamados
        '
        '
        'SerialPortEscaner
        '
        '
        'Final
        '
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!)
        Me.Label2.Location = New System.Drawing.Point(-1, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(834, 34)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Contador total:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 734)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Buffer_)
        Me.Controls.Add(Me.Status_)
        Me.Controls.Add(Me.Modelo)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificacion de codigo Qr - By DeyFer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Modelo As ComboBox
    Friend WithEvents Status_ As Label
    Friend WithEvents Buffer_ As TextBox
    Friend WithEvents llamados As Timer
    Friend WithEvents SerialPortEscaner As IO.Ports.SerialPort
    Friend WithEvents Final As Timer
    Friend WithEvents Label2 As Label
End Class
