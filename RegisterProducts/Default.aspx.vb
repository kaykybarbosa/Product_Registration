Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private strStringConnection As String = ConfigurationManager.ConnectionStrings("PRODUCT_REGISTERConnectionString").ToString
    Private connection As New SqlConnection(strStringConnection)

    Private PRODUCT_ID As Integer
    Private NAME As String
    Private SPECIFICATION As String
    Private QUANTITY As Integer
    Private COLOR As String
    Private REGISTRATION_DATE As DateTime
    Private STATUS As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListProduct()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsave.Click

        NAME = txtname.Text
        SPECIFICATION = txtspecification.Text
        QUANTITY = txtquantity.Text
        COLOR = txtcolor.Text
        REGISTRATION_DATE = txtregistrationdate.Text

        If checkavailable.Checked Then
            STATUS = "Available"
        Else
            STATUS = "Unavailable"
        End If

        Try
            connection.Open()

            Dim command As New SqlCommand("INSERT INTO PRODUCTS VALUES ('" & NAME & "', '" & SPECIFICATION & "', '" & QUANTITY & "', '" & COLOR & "', '" & REGISTRATION_DATE & "', '" & STATUS & "')", connection)

            command.ExecuteNonQuery()

            ListProduct()
            Clear()

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Protected Sub ListProduct()
        connection = New SqlConnection(strStringConnection)

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS", connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridview.DataSource = dt
        gridview.DataBind()

        connection.Close()

        lblProducts_Quantity()

    End Sub

    Protected Sub lblProducts_Quantity()
        lblProducts.Text = DirectCast(gridview.DataSource, DataTable).Rows.Count & " product(s)"
    End Sub

    Protected Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        PRODUCT_ID = txtproductid.Text

        Try
            connection.Open()

            Dim command As New SqlCommand("DELETE PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
            command.ExecuteNonQuery()

            ListProduct()
            Clear()

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Protected Sub btnuptade_Click(sender As Object, e As EventArgs) Handles btnuptade.Click
        PRODUCT_ID = txtproductid.Text
        NAME = txtname.Text
        SPECIFICATION = txtspecification.Text
        QUANTITY = txtquantity.Text
        COLOR = txtcolor.Text
        REGISTRATION_DATE = txtregistrationdate.Text

        If checkavailable.Checked Then
            STATUS = "Available"
        Else
            STATUS = "Unavailable"
        End If

        Try
            connection.Open()

            Dim command As New SqlCommand("UPDATE PRODUCTS SET NAME = '" & NAME & "', SPECIFICATION = '" & SPECIFICATION & "', QUANTITY= '" & QUANTITY & "', COLOR= '" & COLOR & "',REGISTRATION_DATE= '" & REGISTRATION_DATE & "', STATUS='" & STATUS & "' WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)

            command.ExecuteNonQuery()

            ListProduct()
            Clear()

            connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        PRODUCT_ID = txtproductid.Text

        connection = New SqlConnection(strStringConnection)

        Try
            connection.Open()
        Catch ex As Exception

        End Try

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridview.DataSource = dt
        gridview.DataBind()

        connection.Close()
    End Sub

    Protected Sub gridview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridview.SelectedIndexChanged
        connection = New SqlConnection(strStringConnection)

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!")
        End Try

        'If txtproductid.Text.Equals("") Then
        'Else
        'PRODUCT_ID = txtproductid.Text
        'End If
        PRODUCT_ID = gridview.SelectedValue

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim reader As SqlDataReader

        reader = command.ExecuteReader()

        If reader.HasRows Then

            While reader.Read()
                txtproductid.Text = reader("PRODUCT_ID").ToString()
                txtname.Text = reader("NAME").ToString()
                txtspecification.Text = reader("SPECIFICATION").ToString()
                txtquantity.Text = reader("QUANTITY").ToString()
                txtcolor.Text = reader("COLOR").ToString()
                txtregistrationdate.Text = Left(reader("REGISTRATION_DATE").ToString, 10)

                If (reader("STATUS").ToString.ToLower().Equals("available")) Then
                    checkavailable.Checked = True
                    checkiunavailable.Checked = False
                Else
                    checkiunavailable.Checked = True
                    checkavailable.Checked = False
                End If

            End While
        End If

        reader.Close()
        connection.Close()

    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtproductid.Text = ""
        txtname.Text = ""
        txtspecification.Text = ""
        txtcolor.Text = ""
        txtquantity.Text = ""
        txtregistrationdate.Text = ""
        checkavailable.Checked = False
        checkiunavailable.Checked = False
    End Sub
    Private Sub Clear()
        txtproductid.Text = ""
        txtname.Text = ""
        txtspecification.Text = ""
        txtcolor.Text = ""
        txtquantity.Text = ""
        txtregistrationdate.Text = ""
        checkavailable.Checked = False
        checkiunavailable.Checked = False
    End Sub

End Class