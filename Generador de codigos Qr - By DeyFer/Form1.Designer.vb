<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    'Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Imprimir = New MaterialSkin.Controls.MaterialButton()
        Me.Modelo = New MaterialSkin.Controls.MaterialComboBox()
        Me.Impresion_Multiple = New MaterialSkin.Controls.MaterialSwitch()
        Me.ImagenCodigoQr = New System.Windows.Forms.PictureBox()
        Me.Num_Impresiones = New System.Windows.Forms.NumericUpDown()
        Me.CantidadIMPN = New MaterialSkin.Controls.MaterialLabel()
        Me.CantidadIMPM = New MaterialSkin.Controls.MaterialLabel()
        Me.llamados = New System.Windows.Forms.Timer(Me.components)
        CType(Me.ImagenCodigoQr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_Impresiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Imprimir
        '
        Me.Imprimir.AutoSize = False
        Me.Imprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Imprimir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
        Me.Imprimir.Depth = 0
        Me.Imprimir.HighEmphasis = True
        Me.Imprimir.Icon = Nothing
        Me.Imprimir.Location = New System.Drawing.Point(7, 570)
        Me.Imprimir.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Imprimir.MouseState = MaterialSkin.MouseState.HOVER
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.NoAccentTextColor = System.Drawing.Color.Empty
        Me.Imprimir.Size = New System.Drawing.Size(368, 36)
        Me.Imprimir.TabIndex = 0
        Me.Imprimir.Text = "IMPRIMIR"
        Me.Imprimir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        Me.Imprimir.UseAccentColor = False
        Me.Imprimir.UseVisualStyleBackColor = True
        '
        'Modelo
        '
        Me.Modelo.AutoResize = False
        Me.Modelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Modelo.Depth = 0
        Me.Modelo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.Modelo.DropDownHeight = 174
        Me.Modelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Modelo.DropDownWidth = 121
        Me.Modelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.Modelo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Modelo.FormattingEnabled = True
        Me.Modelo.IntegralHeight = False
        Me.Modelo.ItemHeight = 43
        Me.Modelo.Location = New System.Drawing.Point(7, 465)
        Me.Modelo.MaxDropDownItems = 4
        Me.Modelo.MouseState = MaterialSkin.MouseState.OUT
        Me.Modelo.Name = "Modelo"
        Me.Modelo.Size = New System.Drawing.Size(368, 49)
        Me.Modelo.StartIndex = 0
        Me.Modelo.TabIndex = 5
        '
        'Impresion_Multiple
        '
        Me.Impresion_Multiple.AutoSize = True
        Me.Impresion_Multiple.Depth = 0
        Me.Impresion_Multiple.Location = New System.Drawing.Point(7, 523)
        Me.Impresion_Multiple.Margin = New System.Windows.Forms.Padding(0)
        Me.Impresion_Multiple.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.Impresion_Multiple.MouseState = MaterialSkin.MouseState.HOVER
        Me.Impresion_Multiple.Name = "Impresion_Multiple"
        Me.Impresion_Multiple.Ripple = True
        Me.Impresion_Multiple.Size = New System.Drawing.Size(189, 37)
        Me.Impresion_Multiple.TabIndex = 11
        Me.Impresion_Multiple.Text = "Impresion multiple"
        Me.Impresion_Multiple.UseVisualStyleBackColor = True
        '
        'ImagenCodigoQr
        '
        Me.ImagenCodigoQr.Location = New System.Drawing.Point(6, 111)
        Me.ImagenCodigoQr.Name = "ImagenCodigoQr"
        Me.ImagenCodigoQr.Size = New System.Drawing.Size(368, 348)
        Me.ImagenCodigoQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImagenCodigoQr.TabIndex = 12
        Me.ImagenCodigoQr.TabStop = False
        '
        'Num_Impresiones
        '
        Me.Num_Impresiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Num_Impresiones.Location = New System.Drawing.Point(228, 526)
        Me.Num_Impresiones.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.Num_Impresiones.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Num_Impresiones.Name = "Num_Impresiones"
        Me.Num_Impresiones.Size = New System.Drawing.Size(146, 38)
        Me.Num_Impresiones.TabIndex = 13
        Me.Num_Impresiones.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CantidadIMPN
        '
        Me.CantidadIMPN.Depth = 0
        Me.CantidadIMPN.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.CantidadIMPN.Location = New System.Drawing.Point(6, 65)
        Me.CantidadIMPN.MouseState = MaterialSkin.MouseState.HOVER
        Me.CantidadIMPN.Name = "CantidadIMPN"
        Me.CantidadIMPN.Size = New System.Drawing.Size(368, 23)
        Me.CantidadIMPN.TabIndex = 14
        Me.CantidadIMPN.Text = "Numero de impresiones N:9999999999"
        Me.CantidadIMPN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CantidadIMPM
        '
        Me.CantidadIMPM.Depth = 0
        Me.CantidadIMPM.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.CantidadIMPM.Location = New System.Drawing.Point(6, 89)
        Me.CantidadIMPM.MouseState = MaterialSkin.MouseState.HOVER
        Me.CantidadIMPM.Name = "CantidadIMPM"
        Me.CantidadIMPM.Size = New System.Drawing.Size(368, 19)
        Me.CantidadIMPM.TabIndex = 14
        Me.CantidadIMPM.Text = "Numero de impresiones M:9999999999"
        Me.CantidadIMPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'llamados
        '
        Me.llamados.Enabled = True
        Me.llamados.Interval = 250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 732)
        Me.Controls.Add(Me.CantidadIMPM)
        Me.Controls.Add(Me.CantidadIMPN)
        Me.Controls.Add(Me.Num_Impresiones)
        Me.Controls.Add(Me.ImagenCodigoQr)
        Me.Controls.Add(Me.Impresion_Multiple)
        Me.Controls.Add(Me.Modelo)
        Me.Controls.Add(Me.Imprimir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Sizable = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generador de codigo Qr - By DeyFer"
        CType(Me.ImagenCodigoQr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_Impresiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Imprimir As MaterialSkin.Controls.MaterialButton
    Friend WithEvents Modelo As MaterialSkin.Controls.MaterialComboBox
    Friend WithEvents Impresion_Multiple As MaterialSkin.Controls.MaterialSwitch
    Friend WithEvents ImagenCodigoQr As PictureBox
    Friend WithEvents Num_Impresiones As NumericUpDown
    Friend WithEvents CantidadIMPN As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents CantidadIMPM As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents llamados As Timer
End Class
