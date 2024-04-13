Imports MaterialSkin
Imports ThoughtWorks.QRCode.Codec
Imports ThoughtWorks.QRCode
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.IO
Partial Class Form1
    Private printDoc As New PrintDocument()
    Dim directorio As String = "Log\" & DateTime.Now.ToString("yyyy") & "\" & DateTime.Now.ToString("MM") & "\" & DateTime.Now.ToString("dd") & "\"
    Dim ContadorN As String = Nothing
    Dim ContadorM As String = Nothing

    'Variables de la confugacion de la aplicacion
    Dim MostrarCMD As String = Nothing

    Dim NamePaper As String = Nothing
    Dim PaperSizeW As System.Int32 = Nothing
    Dim PaperSizeH As System.Int32 = Nothing

    Dim desiredWidthMM As System.Int32 = Nothing
    Dim desiredHeightMM As System.Int32 = Nothing
    Dim desiredWidthDPI As System.Int32 = Nothing
    Dim desiredHeightDPI As System.Int32 = Nothing

    Dim RectangleX As System.Int32 = Nothing
    Dim RectangleY As System.Int32 = Nothing

    Dim FontemSize As System.Double = Nothing

    Dim PointFX As System.Int32 = Nothing
    Dim PointFY As System.Int32 = Nothing
    ' Importación de la función AllocConsole de la biblioteca de enlace dinámico Kernel32
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function AllocConsole() As Boolean
    End Function

    ' Importación de la función FreeConsole de la biblioteca de enlace dinámico Kernel32
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function FreeConsole() As Boolean
    End Function
#Region "Inicio de la aplicacion"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargamos las configuraciones
        If File.Exists("Configuraciones\Config.txt") Then
            For Each lineaConfig As String In File.ReadAllLines("Configuraciones\Config.txt")
                'Opcion para mostrar la CMD
                If lineaConfig.Contains("Mostrar ventana CMD:") Then MostrarCMD = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()

                'Propiedades del tipo de papel
                If lineaConfig.Contains("Tipo de papel:") Then NamePaper = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Width:") Then PaperSizeW = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Height:") Then PaperSizeH = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()

                'Print page handler
                If lineaConfig.Contains("Desired Width X MM:") Then desiredWidthMM = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Desired Height Y MM:") Then desiredHeightMM = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Desired Width X DPI:") Then desiredWidthDPI = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Desired Width Y DPI:") Then desiredHeightDPI = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()

                If lineaConfig.Contains("Rectangle X:") Then RectangleX = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("Rectangle Y:") Then RectangleY = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()

                If lineaConfig.Contains("Font emSize:") Then FontemSize = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()

                If lineaConfig.Contains("PointF DrawString X:") Then PointFX = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
                If lineaConfig.Contains("PointF DrawString Y:") Then PointFY = lineaConfig.Substring(lineaConfig.IndexOf(":") + 1).Trim()
            Next
        Else
            Console.WriteLine("El archivo no existe.")
        End If

        If MostrarCMD = "Si" Then AllocConsole()

        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        SkinManager.ColorScheme = New ColorScheme(Primary.LightBlue400, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
        Me.Width = 383
        Me.Height = 617
        AddHandler printDoc.PrintPage, AddressOf PrintPageHandler

        'Verificamos primero si existe la ruta "Raiz" de los Log
        If Not System.IO.Directory.Exists(directorio) Then System.IO.Directory.CreateDirectory(directorio)

        'Verificamos si existe el archivo del contador .ini
        If Not System.IO.File.Exists(directorio & "COUNT.ini") Then CrearArchivoIni("0", "0") Else LeerArchivoIni()

        'Cargamos los codigos
        Carga_Lista_Model()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FreeConsole()
    End Sub
    Private Sub CrearArchivoIni(CantidadN As String, CantidadM As String)
        ' Crea un nuevo archivo INI y escribe los datos
        Using escritor As New StreamWriter(directorio & "COUNT.ini")
            escritor.WriteLine("[COUNT]")
            escritor.WriteLine("")
            escritor.WriteLine("Normal:" & CantidadN)
            escritor.WriteLine("Multiple:" & CantidadM)
        End Using

        LeerArchivoIni()
    End Sub
    Private Sub LeerArchivoIni()
        Console.WriteLine("Cargando contador")


        If File.Exists(directorio & "COUNT.ini") Then
            For Each linea As String In File.ReadAllLines(directorio & "COUNT.ini")
                If linea.Contains("Normal:") Then ContadorN = linea.Substring(linea.IndexOf(":") + 1).Trim()
                If linea.Contains("Multiple:") Then ContadorM = linea.Substring(linea.IndexOf(":") + 1).Trim()
            Next

            Console.WriteLine("Normal:" & ContadorN)
            Console.WriteLine("Multiple:" & ContadorM)
        Else
            Console.WriteLine("El archivo no existe.")
        End If
    End Sub
    Private Sub Modelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Modelo.KeyPress
        e.Handled = True
    End Sub
    Private Sub Carga_Lista_Model()
        Dim filePath As String = "Codigos\Modelos.ini"
        Dim lines() As String = System.IO.File.ReadAllLines(filePath)

        For Each line As String In lines
            Modelo.Items.Add(line)
        Next
    End Sub
#End Region
#Region "Generar Qr y imprimir"
    'Generamos el codigo Qr
    Private Sub Generar_Codigo_Qr()
        ' Obtenemos el texto del modelo
        Dim texto As String = Modelo.Text

        'Primero generamos el codigo Qr
        'Dim qrEncoder As New QRCodeEncoder()
        Dim qrCodeEncoder As QRCodeEncoder = New QRCodeEncoder

        'qrEncoder.QRCodeScale = Int32.Parse(2)
        'ImagenCodigoQr.Image = qrEncoder.Encode(texto)


        qrCodeEncoder.QRCodeEncodeMode = Codec.QRCodeEncoder.ENCODE_MODE.BYTE

        qrCodeEncoder.QRCodeScale = Int32.Parse(2)
        qrCodeEncoder.QRCodeErrorCorrect = Codec.QRCodeEncoder.ERROR_CORRECTION.L
        qrCodeEncoder.QRCodeVersion = 0
        qrCodeEncoder.QRCodeBackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
        qrCodeEncoder.QRCodeForegroundColor = System.Drawing.Color.FromArgb(255, 0, 0, 0)

        ImagenCodigoQr.Image = qrCodeEncoder.Encode(Modelo.Text, System.Text.Encoding.UTF8)

        'Imprimimos el resultado final
        Imprimir_Resultado()
    End Sub
    'Imprimimos el codigo Qr
    Private Sub Imprimir_Resultado()
        ' Configura el tamaño del papel en milímetros
        printDoc.DefaultPageSettings.PaperSize = New PaperSize(NamePaper, PaperSizeW, PaperSizeH)

        ' Establece los márgenes en cero
        printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

        ' Inicia el proceso de impresión
        printDoc.Print()
    End Sub
    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        ' Obtiene el contenido del PictureBox
        Dim image As Image = ImagenCodigoQr.Image

        ' Calcula el tamaño de la imagen para que sea de 20 mm por 20 mm
        Dim desiredWidth As Integer = e.Graphics.DpiX * desiredWidthMM / desiredWidthDPI ' Conversión de mm a dpi
        Dim desiredHeight As Integer = e.Graphics.DpiY * desiredHeightMM / desiredHeightDPI ' Conversión de mm a dpi

        ' Dibuja la imagen en la página de impresión con el tamaño calculado
        e.Graphics.DrawImage(image, New Rectangle(RectangleX, RectangleY, desiredWidth, desiredHeight))

        ' Obtiene el texto que se encuentra en el PictureBox
        Dim qrText As String = Modelo.Text

        ' Crea una fuente y un pincel para el texto
        Using font As New Font("Arial Black", FontemSize)
            Using brush As New SolidBrush(Color.Black)
                ' Dibuja el texto debajo del código QR
                e.Graphics.DrawString(qrText, font, brush, New PointF(PointFX, desiredHeight + PointFY)) ' Cambia 10 según el espaciado deseado
            End Using
        End Using

        'Generamos un log
        Log()
    End Sub
#End Region
    'Boton para generar y imprimir el codigo Qr
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
#Region "Contador de impresiones y logs"
    'Pequeño log
    Private Sub Log()
        Dim rutaArchivo As String = directorio & "\Log.txt"

        Using escritor As New System.IO.StreamWriter(rutaArchivo, True)
            escritor.WriteLine("Hora:" & DateTime.Now.ToString("HH:mm:ss") & "                  Codigo:" & Modelo.Text)
        End Using

        'Almacenamos el contador
        If Impresion_Multiple.Checked = False Then Contador("N")
        If Impresion_Multiple.Checked = True Then Contador("M")
    End Sub
    'Contador de impresiones
    Private Sub Contador(Tipo As String)
        Dim rutaArchivo As String = directorio & "\COUNT.ini"

        If Tipo = "N" Then ContadorN = Val(ContadorN) + 1
        If Tipo = "M" Then ContadorM = Val(ContadorM) + 1

        CrearArchivoIni(ContadorN, ContadorM)
    End Sub

    Private Sub llamados_Tick(sender As Object, e As EventArgs) Handles llamados.Tick
        CantidadIMPN.Text = "Numero de impresiones N:" & ContadorN
        CantidadIMPM.Text = "Numero de impresiones M:" & ContadorM
    End Sub

    Private Sub Imprimir_Click(sender As Object, e As EventArgs) Handles Imprimir.Click
        Console.WriteLine("Imprimir")
        Dim cantidad As Integer = Convert.ToInt32(Num_Impresiones.Value)

        If Impresion_Multiple.Checked = False Then Generar_Codigo_Qr()
        If Impresion_Multiple.Checked = True Then
            For i As Integer = 1 To cantidad
                Generar_Codigo_Qr()
                If i < cantidad Then
                    Num_Impresiones.Value -= 1
                End If
                If i = cantidad Then Impresion_Multiple.Checked = False
            Next i
        End If
    End Sub
#End Region
End Class
