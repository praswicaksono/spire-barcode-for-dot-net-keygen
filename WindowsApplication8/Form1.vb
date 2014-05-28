Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Private rand As New System.Random(Environment.TickCount)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function byteToChar(ByVal bytes)
        Dim i As Integer

        i = CInt((bytes Mod 36))
        If (i < 10) Then
            Return CChar(ChrW((i + 48)))
        Else
            Return CChar(ChrW((i - 10 + 65)))
        End If

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = genRamdomString(11)
        Dim array As Byte()
        Dim i As Integer = 0
        Dim sb As New StringBuilder()

        array = Encoding.UTF8.GetBytes(str + "sbpaire")
        Dim mD As MD5 = New MD5CryptoServiceProvider()
        array = mD.ComputeHash(array)

        While (i < 15)
            If (i Mod 5 = 0) Then
                sb.Append("-")
            End If
            sb.Append(byteToChar(array(i)))
            i += 1
        End While
        Dim serial As String = str + sb.ToString()
        TextBox1.Text = serial
    End Sub

    Private Function genRamdomString(ByVal lenght As Integer)
        Dim validchars As String = "1234567890ABCEFGHIJKLMNOPQRSTUVWXYZ"
        Dim sb As New StringBuilder()

        For i As Integer = 1 To lenght Step 1
            sb.Append(validchars(rand.Next(0, validchars.Length)))
        Next

        Return sb.ToString()
    End Function
End Class
