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

    Private VALIDATION As ValidationTexts
    Private ReadOnly VALID As String = "VALID"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListProduct()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        connection = New SqlConnection(strStringConnection)
        VALIDATION = New ValidationTexts(txtProductid, txtName, txtSpecification, txtQuantity, txtColor, txtRegistrationDate, checkAvailable, checkUnavailable)

        Dim result = VALIDATION.Validate_Fields
        If result.Equals(VALID) Then
            NAME = txtName.Text
            SPECIFICATION = txtSpecification.Text
            QUANTITY = txtQuantity.Text
            COLOR = txtColor.Text
            REGISTRATION_DATE = txtRegistrationDate.Text

            'SEE ROLES
            If QUANTITY > 0 Then
                STATUS = "Available"
            Else
                STATUS = "Unavailable"
            End If

            If checkAvailable.Checked Then
                STATUS = "Available"
            Else
                STATUS = "Unavailable"
            End If
        Else
            MsgBox(result, MsgBoxStyle.Information, "Error!")
            Exit Sub
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Dim command As New SqlCommand("INSERT INTO PRODUCTS VALUES ('" & NAME & "', '" & SPECIFICATION & "', '" & QUANTITY & "', '" & COLOR & "', '" & REGISTRATION_DATE & "', '" & STATUS & "')", connection)
        command.ExecuteNonQuery()

        ListProduct()
        Clear()

        connection.Close()

    End Sub
    Protected Sub ListProduct(Optional sort As String = "PRODUCT_ID")
        connection = New SqlConnection(strStringConnection)
        Dim strSql As New StringBuilder

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try

        strSql.Append("SELECT * FROM PRODUCTS")
        strSql.Append(" ORDER BY '" & sort & "'")

        Dim command As New SqlCommand(strSql.ToString, connection)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridView.DataSource = dt
        gridView.DataBind()

        connection.Close()

        lblProducts_Quantity()

    End Sub

    Protected Sub lblProducts_Quantity()
        lblProducts.Text = DirectCast(gridView.DataSource, DataTable).Rows.Count & " product(s)"
    End Sub

    Protected Sub btnUptade_Click(sender As Object, e As EventArgs) Handles btnUptade.Click
        connection = New SqlConnection(strStringConnection)
        VALIDATION = New ValidationTexts(txtProductid, txtName, txtSpecification, txtQuantity, txtColor, txtRegistrationDate, checkAvailable, checkUnavailable)

        Dim result = VALIDATION.Validate_Fields(isUpdate:=True)
        If result.Equals(VALID) Then
            PRODUCT_ID = txtProductid.Text
            NAME = txtName.Text
            SPECIFICATION = txtSpecification.Text
            QUANTITY = txtQuantity.Text
            COLOR = txtColor.Text
            REGISTRATION_DATE = txtRegistrationDate.Text

            If checkAvailable.Checked Then
                STATUS = "Available"
            Else
                STATUS = "Unavailable"
            End If
        Else
            MsgBox(result, MsgBoxStyle.Information, "Error!")
            Exit Sub
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Dim command As New SqlCommand("UPDATE PRODUCTS SET NAME = '" & NAME & "', SPECIFICATION = '" & SPECIFICATION & "', QUANTITY= '" & QUANTITY & "', COLOR= '" & COLOR & "',REGISTRATION_DATE= '" & REGISTRATION_DATE & "', STATUS='" & STATUS & "' WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim rows As Integer = command.ExecuteNonQuery()

        If rows = 0 Then
            MsgBox("It was not possible to update, because the N° Product does not exist.", MsgBoxStyle.Information, "Not found.")
            Exit Sub
        End If

        ListProduct()
        Clear()

        connection.Close()
    End Sub

    'SEM USO
    Protected Sub gridview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridView.SelectedIndexChanged
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
        PRODUCT_ID = gridView.SelectedValue

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim reader As SqlDataReader

        reader = command.ExecuteReader()

        If reader.HasRows Then

            While reader.Read()
                txtProductid.Text = reader("PRODUCT_ID").ToString()
                txtName.Text = reader("NAME").ToString()
                txtSpecification.Text = reader("SPECIFICATION").ToString()
                txtQuantity.Text = reader("QUANTITY").ToString()
                txtColor.Text = reader("COLOR").ToString()
                txtRegistrationDate.Text = Left(reader("REGISTRATION_DATE").ToString, 10)

                If (reader("STATUS").ToString.ToLower().Equals("available")) Then
                    checkAvailable.Checked = True
                    checkUnavailable.Checked = False
                Else
                    checkUnavailable.Checked = True
                    checkAvailable.Checked = False
                End If

            End While
        End If

        reader.Close()
        connection.Close()

    End Sub

    Protected Sub gridView_RowCommand(ByVal source As Object, ByVal e As GridViewCommandEventArgs) Handles gridView.RowCommand
    End Sub

    Protected Sub gridView_Delete(ByVal source As Object, e As GridViewDeleteEventArgs) Handles gridView.RowDeleting
        connection = New SqlConnection(strStringConnection)

        If txtProductid.Text.Equals("") Then
            MsgBox("N° product is required.", MsgBoxStyle.Information, "Required!")
            Exit Sub
        Else
            PRODUCT_ID = txtProductid.Text
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Dim command As New SqlCommand("DELETE PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim rows As Integer = command.ExecuteNonQuery()

        If rows = 0 Then
            MsgBox("It was not possible to delete, because the N° Product does not exist.", MsgBoxStyle.Information, "Not found.")
            Exit Sub
        End If

        ListProduct()
        Clear()

        connection.Close()
    End Sub

    Private Sub gridView_Sorting(ByVal source As Object, ByVal e As GridViewSortEventArgs) Handles gridView.Sorting
        ViewState("OrderBy") = e.SortExpression
        ListProduct(ViewState("OrderBy"))
    End Sub

    Protected Sub gridView_PageIndexChanging(ByVal source As Object, ByVal e As GridViewPageEventArgs) Handles gridView.PageIndexChanging
        gridView.PageIndex = e.NewPageIndex
        ListProduct()
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtProductid.Text = ""
        txtName.Text = ""
        txtSpecification.Text = ""
        txtColor.Text = ""
        txtQuantity.Text = ""
        txtRegistrationDate.Text = ""
        checkAvailable.Checked = False
        checkUnavailable.Checked = False
    End Sub
    Private Sub Clear()
        txtProductid.Text = ""
        txtName.Text = ""
        txtSpecification.Text = ""
        txtColor.Text = ""
        txtQuantity.Text = ""
        txtRegistrationDate.Text = ""
        checkAvailable.Checked = False
        checkUnavailable.Checked = False
    End Sub

    Protected Sub ibtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearch.Click
        connection = New SqlConnection(strStringConnection)
        Dim strSql As New StringBuilder

        strSql.Append("SELECT * FROM PRODUCTS WHERE")

        If Not txtProductid.Text.Equals("") Then
            PRODUCT_ID = txtProductid.Text
            strSql.Append(" PRODUCT_ID = '" & PRODUCT_ID & "'")
        End If

        If Not txtName.Text.Equals("") Then
            NAME = txtName.Text
            strSql.Append(" NAME LIKE '%" & NAME & "%'")
        End If

        If Not txtSpecification.Text.Equals("") Then
            SPECIFICATION = txtSpecification.Text
            strSql.Append(" AND SPECIFICATION LIKE '%" & SPECIFICATION & "%'")
        End If

        If Not txtQuantity.Text.Equals("") Then
            QUANTITY = txtQuantity.Text
            strSql.Append(" AND QUANTITY = '" & QUANTITY & "'")
        End If

        If Not txtColor.Text.Equals("") Then
            COLOR = txtColor.Text
            strSql.Append(" AND COLOR LIKE '%" & QUANTITY & "%'")
        End If

        If checkAvailable.Checked Then
            strSql.Append(" AND STATUS = 'AVAILABLE'")
        End If

        If checkUnavailable.Checked Then
            strSql.Append(" AND STATUS = 'UNAVAILABLE'")
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Try
            Dim command As New SqlCommand(strSql.ToString, connection)
            Dim rows As Integer = command.ExecuteNonQuery()

            If rows = 0 Then
                Exit Sub
            End If

            Dim sd As New SqlDataAdapter(command)
            Dim dt As New DataTable

            sd.Fill(dt)

            gridView.DataSource = dt
            gridView.DataBind()
        Catch ex As Exception
            ListProduct()
            'MsgBox("Select some filter.", MsgBoxStyle.Information, "Values empty.")
        End Try

        connection.Close()
    End Sub
End Class