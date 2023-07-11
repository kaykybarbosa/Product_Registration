Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim connection As New SqlConnection("DESKTOP-ND6PEOM\SEDUC2023KAYKY;Initial Catalog=PRODUCT_REGISTER;Integrated Security=True")

        Dim nameProduct As String = txtname.Text
        Dim specification As String = txtspecification.Text
        Dim quantity As Integer = txtquantity.Text
        Dim color As String = txtcolor.Text
        Dim regitrationDate As DateTime = txtregistrationdate.Text
        Dim status As String

        If checkregular.Checked Then
            status = "Available"
        Else
            status = "Unavailable"
        End If

        connection.Open()
        Dim command As New SqlCommand("INSERT INTO PRODUCT_REGISTER VALUES ('" & nameProduct & "', '" & specification & "', '" & quantity & "', '" & color & "', '" & regitrationDate & "', '" & status & "')", connection)
        command.ExecuteNonQuery()

        MsgBox("Successfylly saved!", MsgBoxStyle.Information, "Message")
        connection.Close()
    End Sub
End Class