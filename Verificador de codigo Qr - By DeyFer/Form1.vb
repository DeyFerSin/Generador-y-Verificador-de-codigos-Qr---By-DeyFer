Imports Wizard.Comun.Config
Imports System.Threading
Imports MaterialSkin
Public Class Form1
    Dim RutaConfig As String = "Configuracion\Config.ini"
    Dim ConexionPuertoCOM As String = Nothing
    Dim DelayEsperaNo1 As Integer = Nothing
    Dim DelayEsperaNo2 As Integer = Nothing
    Dim Buffer__ As String = Nothing
    Delegate Sub SetTextCallback(ByVal [text] As String)
#Region "Inicio de la aplicacion"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Iniciamos la aplicacion en estado READY
        Estados("READY")

        'Iniciamos la carga de las configuraciones de la aplicacion
        Configuraciones_String(RutaConfig, "Escaner Puerto COM", ConexionPuertoCOM, ":")
        Configuraciones_String(RutaConfig, "Delay inicial", DelayEsperaNo1, ":")
        Configuraciones_String(RutaConfig, "Delay final", DelayEsperaNo2, ":")

        'Agregamos el intervalo para la inspeccion del timer
        llamados.Interval = DelayEsperaNo1
        Final.Interval = DelayEsperaNo2

        Buffer_.Clear()

        'Iniciamos la conexion del puerto del escaner automatico
        Conexion_Puerto_COM()

        'Realizamos la carga de los modelos
        Modelos_Inspeccion()
    End Sub
    Private Sub Modelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Modelo.KeyPress
        e.Handled = True
    End Sub
    Private Sub Conexion_Puerto_COM()
        'Iniciamos con la conexion del puerto COM para el escaneo (Por ahora se mantiene como escaner de forma manual)
        SerialPortEscaner.PortName = ConexionPuertoCOM
        SerialPortEscaner.Open()

        Console.WriteLine("Estado:" & SerialPortEscaner.IsOpen)
    End Sub
    Private Sub Estados(Tipo As String)
        'Mostramos el mismo tipo de estado, en la label
        Status_.Text = Tipo

        If Tipo = "NG" Then Status_.BackColor = Color.Red
        If Tipo = "OK" Then Status_.BackColor = Color.Lime
        If Tipo = "READY" Then Status_.BackColor = Color.Gray
    End Sub
    Private Sub Modelos_Inspeccion()
        Dim filePath As String = "Codigos\Modelos.ini"
        Dim lines() As String = System.IO.File.ReadAllLines(filePath)

        For Each line As String In lines
            Modelo.Items.Add(line)
        Next
    End Sub
    Private Sub SerialPortEscaner_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortEscaner.DataReceived
        ReceivedText(SerialPortEscaner.ReadExisting())
    End Sub
    Private Sub ReceivedText(ByVal [text] As String)
        If Me.Buffer_.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.Buffer_.Text &= [text]
        End If
    End Sub
#End Region
    Private Sub Buffer__TextChanged(sender As Object, e As EventArgs) Handles Buffer_.TextChanged
        Estados("READY")
        Buffer__ = Buffer_.Text
        If Buffer__.Length > 9 Then
            Console.WriteLine("Datos:" & Buffer__ & " - Longitud:" & Buffer__.Length)
            'Iniciamos el analisis del dato
            llamados.Start()
        End If
    End Sub

    Private Sub llamados_Tick(sender As Object, e As EventArgs) Handles llamados.Tick
        'Verificamos el codigo que tenemos asta este momento
        Console.WriteLine(Buffer__)

        'Iniciamos la verificacion del codigo
        If Buffer__.Contains(Modelo.Text) Then Estados("OK") Else Estados("NG")

        Final.Start()
        llamados.Stop()
    End Sub

    Private Sub Final_Tick(sender As Object, e As EventArgs) Handles Final.Tick
        Console.WriteLine("FIN")
        Buffer_.Clear()

        Final.Stop()
    End Sub
End Class