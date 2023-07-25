Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private strStringConnection As String = ConfigurationManager.ConnectionStrings("StringConectionRegisterProduct").ToString
    Private connection As New SqlConnection(strStringConnection)

    Private PRODUCT_ID As Integer
    Private NAME As String
    Private COLOR As String
    Private QUANTITY As Integer
    Private REGISTRATION_DATE As DateTime
    Private STATUS As String
    Private SPECIFICATION As String

    Private VALIDATION As ValidationTexts
    Private ReadOnly VALID As String = "VALID"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListProduct()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        connection = New SqlConnection(strStringConnection)
        VALIDATION = New ValidationTexts(txtProductid, txtName, txtQuantity, txtColor, txtRegistrationDate, checkStatus, txtSpecification)
        Dim strSql As New StringBuilder

        Dim result = VALIDATION.Validate_Fields
        If result.Equals(VALID) Then
            NAME = txtName.Text
            SPECIFICATION = txtSpecification.Text
            QUANTITY = txtQuantity.Text
            COLOR = txtColor.Text
            REGISTRATION_DATE = txtRegistrationDate.Text

            If checkStatus.Items(0).Selected Then
                STATUS = "Available"
            Else
                STATUS = "Unavailable"
            End If
        Else
            ShowLblRequired(result)

            Exit Sub
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        strSql.Append("INSERT INTO PRODUCTS VALUES (")
        strSql.Append(" '" & NAME & "' , ")
        strSql.Append(" '" & SPECIFICATION & "' , ")
        strSql.Append(" '" & QUANTITY & "' , ")
        strSql.Append(" '" & COLOR & "' , ")
        strSql.Append(" '" & REGISTRATION_DATE & "' , ")
        strSql.Append(" '" & STATUS & "' )")

        Dim command As New SqlCommand(strSql.ToString, connection)
        command.ExecuteNonQuery()

        Clear()
        ListProduct()
        ClearLblRequired()

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

        lblProducts_Quantity()
        connection.Close()
    End Sub

    Protected Sub lblProducts_Quantity()
        Dim counterProducts = DirectCast(gridView.DataSource, DataTable).Rows.Count

        If counterProducts <= 0 Then
            lblCounter.Visible = False
        Else
            lblCounter.Visible = True
            lblCounter.Text = counterProducts & " product(s)"
        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        connection = New SqlConnection(strStringConnection)
        VALIDATION = New ValidationTexts(txtProductid, txtName, txtQuantity, txtColor, txtRegistrationDate, checkStatus, txtSpecification)
        Dim strSql As New StringBuilder

        Dim result = VALIDATION.Validate_Fields(isUpdate:=True)
        If result.Equals(VALID) Then
            PRODUCT_ID = txtProductid.Text
            NAME = txtName.Text
            QUANTITY = txtQuantity.Text
            COLOR = txtColor.Text
            SPECIFICATION = txtSpecification.Text

            If checkStatus.Items(0).Selected Then
                STATUS = "Available"
            Else
                STATUS = "Unavailable"
            End If
        Else
            ShowLblRequired(result, isUpdate:=True)

            Exit Sub
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        strSql.Append("UPDATE PRODUCTS SET")
        strSql.Append(" NAME = '" & NAME & "'")
        strSql.Append(" , QUANTITY = '" & QUANTITY & "'")
        strSql.Append(" , COLOR = '" & COLOR & "'")
        strSql.Append(" , SPECIFICATION = '" & SPECIFICATION & "'")
        strSql.Append(" , STATUS = '" & STATUS & "'")
        strSql.Append(" WHERE PRODUCT_ID = '" & PRODUCT_ID & "'")

        Dim command As New SqlCommand(strSql.ToString, connection)
        Dim row As Integer = command.ExecuteNonQuery()

        If row <= 0 Then
            MsgBox("Product not updated!", MsgBoxStyle.Information)
        End If

        Clear()
        ListProduct()
        ClearLblRequired()

        connection.Close()
    End Sub

    Protected Sub gridview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridView.SelectedIndexChanged
        connection = New SqlConnection(strStringConnection)

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error!")
        End Try

        PRODUCT_ID = gridView.SelectedValue

        Dim command As New SqlCommand("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        Dim reader As SqlDataReader

        reader = command.ExecuteReader()

        If reader.HasRows Then

            While reader.Read()
                txtProductid.Text = reader("PRODUCT_ID").ToString()
                txtName.Text = reader("NAME").ToString()
                txtQuantity.Text = reader("QUANTITY").ToString()
                txtColor.Text = reader("COLOR").ToString()
                txtSpecification.Text = reader("SPECIFICATION").ToString()

                If reader("STATUS").ToString.Equals(checkStatus.Items(0).Text) Then
                    checkStatus.Items(0).Selected = True
                    checkStatus.Items(1).Selected = False
                Else
                    checkStatus.Items(1).Selected = True
                    checkStatus.Items(0).Selected = False
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

        Dim result = MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo, "DELETE")

        If result.Equals(vbNo) Then
            Exit Sub
        End If

        PRODUCT_ID = gridView.DataKeys(e.RowIndex)("PRODUCT_ID").ToString

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Dim command As New SqlCommand("DELETE PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'", connection)
        command.ExecuteNonQuery()

        Clear()
        ListProduct()
        connection.Close()
    End Sub

    Protected Sub gridView_Sorting(ByVal source As Object, ByVal e As GridViewSortEventArgs) Handles gridView.Sorting
        ViewState("OrderBy") = e.SortExpression
        ListProduct(ViewState("OrderBy"))
    End Sub

    Protected Sub gridView_PageIndexChanging(ByVal source As Object, e As GridViewPageEventArgs) Handles gridView.PageIndexChanging
        gridView.PageIndex = e.NewPageIndex
        ListProduct()
    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtProductid.Text = ""
        txtName.Text = ""
        txtQuantity.Text = ""
        txtColor.Text = ""
        txtRegistrationDate.Text = ""
        checkStatus.Items(0).Selected = False
        checkStatus.Items(1).Selected = False
        txtSpecification.Text = ""

        ClearMensageRules()
    End Sub
    Private Sub Clear()
        txtProductid.Text = ""
        txtName.Text = ""
        txtQuantity.Text = ""
        txtColor.Text = ""
        txtRegistrationDate.Text = ""
        checkStatus.Items(0).Selected = False
        checkStatus.Items(1).Selected = False
        txtSpecification.Text = ""
    End Sub

    Protected Sub ibtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearch.Click
        connection = New SqlConnection(strStringConnection)
        Dim strSql As New StringBuilder

        strSql.Append("SELECT * FROM PRODUCTS WHERE NAME IS NOT NULL")

        If Not txtProductid.Text.Equals("") Then
            PRODUCT_ID = txtProductid.Text
            strSql.Append(" AND PRODUCT_ID = '" & PRODUCT_ID & "'")
        End If

        If Not txtName.Text.Equals("") Then
            NAME = txtName.Text
            strSql.Append(" AND NAME LIKE '%" & NAME & "%'")
        End If

        If Not txtQuantity.Text.Equals("") Then
            QUANTITY = txtQuantity.Text
            strSql.Append(" AND QUANTITY = '" & QUANTITY & "'")
        End If

        If Not txtColor.Text.Equals("") Then
            COLOR = txtColor.Text
            strSql.Append(" AND COLOR LIKE '%" & COLOR & "%'")
        End If

        If checkStatus.Items(0).Selected Then
            Dim status As String = checkStatus.Items(0).Text
            strSql.Append(" AND STATUS = '" & status & "'")
        End If

        If checkStatus.Items(1).Selected Then
            Dim status As String = checkStatus.Items(1).Text
            strSql.Append(" AND STATUS = '" & status & "'")
        End If

        If Not txtSpecification.Text.Equals("") Then
            SPECIFICATION = txtSpecification.Text
            strSql.Append(" AND SPECIFICATION LIKE '%" & SPECIFICATION & "%'")
        End If

        Try
            connection.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Error Connection!")
        End Try

        Dim command As New SqlCommand(strSql.ToString, connection)
        command.ExecuteNonQuery()

        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable

        sd.Fill(dt)

        gridView.DataSource = dt
        gridView.DataBind()

        connection.Close()
    End Sub

    Private Sub ShowLblRequired(Optional lblExample As String = "", Optional isUpdate As Boolean = False)
        Dim requiredClass As String = " required"

        If isUpdate Then
            If lblExample.Equals(lblProductId.ID) Then
                lblProductId.CssClass += requiredClass

                Exit Sub
            Else
                lblProductId.CssClass = lblProductId.CssClass.Replace(requiredClass, "").Trim
            End If
        End If

        If lblExample.Equals(lblName.ID) Then
            lblName.CssClass += requiredClass

            Exit Sub
        Else
            lblName.CssClass = lblName.CssClass.Replace(requiredClass, "").Trim
        End If

        If lblExample.Equals(lblQuantity.ID) Then
            lblQuantity.CssClass += requiredClass

            Exit Sub
        Else
            lblQuantity.CssClass = lblQuantity.CssClass.Replace(requiredClass, "").Trim
        End If

        If lblExample.Equals(lblColor.ID) Then
            lblColor.CssClass += requiredClass

            Exit Sub
        Else
            lblColor.CssClass = lblColor.CssClass.Replace(requiredClass, "").Trim
        End If

        If lblExample.Equals(lblRegistrationDate.ID) Then
            lblRegistrationDate.CssClass += requiredClass

            Exit Sub
        Else
            lblRegistrationDate.CssClass = lblRegistrationDate.CssClass.Replace(requiredClass, "").Trim
        End If

        If lblExample.Equals(lblStatus.ID) Then
            lblStatus.CssClass += requiredClass

            Exit Sub
        Else
            lblStatus.CssClass = lblStatus.CssClass.Replace(requiredClass, "").Trim
        End If

        If lblExample.Equals(lblSpecification.ID) Then
            lblSpecification.CssClass += requiredClass

            Exit Sub
        Else
            lblSpecification.CssClass = lblSpecification.CssClass.Replace(requiredClass, "").Trim
        End If

        ShowMensageRules(lblExample)

    End Sub

    Private Sub ClearLblRequired()
        Dim requiredClass As String = "required"

        lblProductId.CssClass = lblProductId.CssClass.Replace(requiredClass, "").Trim
        lblName.CssClass = lblName.CssClass.Replace(requiredClass, "").Trim
        lblQuantity.CssClass = lblQuantity.CssClass.Replace(requiredClass, "").Trim
        lblColor.CssClass = lblColor.CssClass.Replace(requiredClass, "").Trim
        lblRegistrationDate.CssClass = lblRegistrationDate.CssClass.Replace(requiredClass, "").Trim
        lblStatus.CssClass = lblStatus.CssClass.Replace(requiredClass, "").Trim
        lblSpecification.CssClass = lblSpecification.CssClass.Replace(requiredClass, "").Trim
    End Sub

    Protected Sub ShowMensageRules(ByVal addRules As String)

        If addRules.Equals(lblRulesName.ID) Then
            lblRulesName.Visible = True
        Else
            lblRulesName.Visible = False
        End If

        If addRules.Equals(lblRulesColor.ID) Then
            lblRulesColor.Visible = True
        Else
            lblRulesColor.Visible = False
        End If

        If addRules.Equals(lblRulesSpecification.ID) Then
            lblRulesSpecification.Visible = True
        Else
            lblRulesSpecification.Visible = False
        End If

    End Sub

    Protected Sub ClearMensageRules()
        lblRulesName.Visible = False
        lblRulesColor.Visible = False
        lblRulesSpecification.Visible = False
    End Sub
End Class