Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private strStringConnection As String = ConfigurationManager.ConnectionStrings("PRODUCT_REGISTERConnectionString").ToString
    Private connection As New SqlConnection(strStringConnection)

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsave.Click

        Dim nameProduct As String = txtname.Text
        Dim specification As String = txtspecification.Text
        Dim quantity As Double = txtquantity.Text
        Dim color As String = txtcolor.Text
        Dim regitrationDate As DateTime = txtregistrationdate.Text
        Dim status As String

        If checkregular.Checked Then
            status = "Available"
        Else
            status = "Unavailable"
        End If

        Try
            connection.Open()

            Dim command As New SqlCommand("INSERT INTO PRODUCTS VALUES ('" & nameProduct & "', '" & specification & "', '" & quantity & "', '" & color & "', '" & regitrationDate & "', '" & status & "')", connection)

            command.ExecuteNonQuery()

            MsgBox("Successfylly saved!", MsgBoxStyle.Information, "Message")

            ListProduct()

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Protected Sub ListProduct()
        connection = New SqlConnection(strStringConnection)

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS", connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridview.DataSource = dt
        gridview.DataBind()
    End Sub

    Protected Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim idProduct As Integer = txtproductid.Text

        Try
            connection.Open()

            Dim command As New SqlCommand("DELETE PRODUCTS WHERE PRODUCT_ID = '" & idProduct & "'", connection)
            command.ExecuteNonQuery()

            MsgBox("Successfully deleted!", MsgBoxStyle.Information, "Message")

            ListProduct()
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Protected Sub btnuptade_Click(sender As Object, e As EventArgs) Handles btnuptade.Click
        Dim idProduct As Integer = txtproductid.Text
        Dim nameProduct As String = txtname.Text
        Dim specification As String = txtspecification.Text
        Dim quantity As Double = txtquantity.Text
        Dim color As String = txtcolor.Text
        Dim regitrationDate As DateTime = txtregistrationdate.Text
        Dim status As String

        If checkregular.Checked Then
            status = "Available"
        Else
            status = "Unavailable"
        End If

        Try
            connection.Open()

            Dim command As New SqlCommand("UPDATE PRODUCTS SET NAME = '" & nameProduct & "', SPECIFICATION = '" & specification & "', QUANTITY= '" & quantity & "', COLOR= '" & color & "',REGISTRATION_DATE= '" & regitrationDate & "', STATUS='" & status & "' WHERE PRODUCT_ID = '" & idProduct & "'", connection)

            command.ExecuteNonQuery()

            MsgBox("Successfylly uptaded!", MsgBoxStyle.Information, "Message")

            ListProduct()

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListProduct()
    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Dim idProduct As Integer = txtproductid.Text

        connection = New SqlConnection(strStringConnection)

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & idProduct & "'", connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridview.DataSource = dt
        gridview.DataBind()
    End Sub
End Class