Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Private PRODUCT_ID As Integer
    Private NAME As String
    Private COLOR As String
    Private QUANTITY As Integer
    Private REGISTRATION_DATE As DateTime
    Private STATUS As String
    Private SPECIFICATION As String

    Private CONNECTION As New AccessConnection
    Private VALIDATION As ValidationTexts
    Private ReadOnly VALID As String = "VALID"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListProduct()
    End Sub

    Protected Sub ibtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnSearch.Click
        Dim dt As DataTable
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
            STATUS = checkStatus.Items(0).Text
            strSql.Append(" AND STATUS = '" & status & "'")
        End If

        If checkStatus.Items(1).Selected Then
            STATUS = checkStatus.Items(1).Text
            strSql.Append(" AND STATUS = '" & status & "'")
        End If

        If Not txtSpecification.Text.Equals("") Then
            SPECIFICATION = txtSpecification.Text
            strSql.Append(" AND SPECIFICATION LIKE '%" & SPECIFICATION & "%'")
        End If

        dt = CONNECTION.ExecuteDataTable(strSql.ToString)

        gridView.DataSource = dt
        gridView.DataBind()

        lblProducts_Quantity()

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim strSql As New StringBuilder

        VALIDATION = New ValidationTexts(txtProductid, txtName, txtQuantity, txtColor, txtRegistrationDate, checkStatus, txtSpecification)

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

        strSql.Append("INSERT INTO PRODUCTS VALUES (")
        strSql.Append(" '" & NAME & "' , ")
        strSql.Append(" '" & SPECIFICATION & "' , ")
        strSql.Append(" '" & QUANTITY & "' , ")
        strSql.Append(" '" & COLOR & "' , ")
        strSql.Append(" '" & REGISTRATION_DATE & "' , ")
        strSql.Append(" '" & STATUS & "' )")

        Dim rows As Integer = CONNECTION.ExecuteSqlCommand(strSql.ToString)

        If rows <= 0 Then
            ShowInformation("Falid while adding product!", False)

            Exit Sub
        End If

        ShowInformation("Product added successfully.")

        ListProduct()
        ClearLblRequired()

    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSql As New StringBuilder

        VALIDATION = New ValidationTexts(txtProductid, txtName, txtQuantity, txtColor, txtRegistrationDate, checkStatus, txtSpecification)

        Dim result As String = VALIDATION.Validate_Fields(isUpdate:=True)
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

        strSql.Append("UPDATE PRODUCTS SET")
        strSql.Append(" NAME = '" & NAME & "'")
        strSql.Append(" , QUANTITY = '" & QUANTITY & "'")
        strSql.Append(" , COLOR = '" & COLOR & "'")
        strSql.Append(" , SPECIFICATION = '" & SPECIFICATION & "'")
        strSql.Append(" , STATUS = '" & STATUS & "'")
        strSql.Append(" WHERE PRODUCT_ID = '" & PRODUCT_ID & "'")

        Dim rows As Integer = CONNECTION.ExecuteSqlCommand(strSql.ToString)

        If rows <= 0 Then
            ShowInformation("Product with this N° Product not found.", False)

            Exit Sub
        End If

        ShowInformation("Product updated successfully.")

        ListProduct()
        ClearLblRequired()

    End Sub

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtProductid.Text = ""
        txtName.Text = ""
        txtQuantity.Text = ""
        txtColor.Text = ""
        txtRegistrationDate.Text = ""
        checkStatus.Items(0).Selected = False
        checkStatus.Items(1).Selected = False
        txtSpecification.Text = ""
        lblInformation.Visible = False

        ClearMensageRules()

    End Sub

    Protected Sub gridview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gridView.SelectedIndexChanged
        Dim reader As SqlDataReader
        Dim strSql As New StringBuilder

        PRODUCT_ID = gridView.SelectedValue

        strSql.Append("SELECT * FROM PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'")

        reader = CONNECTION.ExecuteSqlCommandReader(strSql.ToString)

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

    End Sub

    Protected Sub ListProduct(Optional sort As String = "PRODUCT_ID")
        Dim dt As DataTable
        Dim strSql As New StringBuilder

        strSql.Append("SELECT * FROM PRODUCTS")
        strSql.Append(" ORDER BY '" & sort & "'")

        dt = CONNECTION.ExecuteDataTable(strSql.ToString)

        gridView.DataSource = dt
        gridView.DataBind()

        lblProducts_Quantity()

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

    Protected Sub gridView_Delete(ByVal source As Object, e As GridViewDeleteEventArgs) Handles gridView.RowDeleting
        Dim strSql As New StringBuilder
        Dim result = MsgBox("Are you sure to delete?", MsgBoxStyle.YesNo, "DELETE")

        If result.Equals(vbNo) Then
            Exit Sub
        End If

        PRODUCT_ID = gridView.DataKeys(e.RowIndex)("PRODUCT_ID").ToString

        strSql.Append("DELETE PRODUCTS WHERE PRODUCT_ID = '" & PRODUCT_ID & "'")

        Dim rows As Integer = CONNECTION.ExecuteSqlCommand(strSql.ToString)

        If rows <= 0 Then
            ShowInformation("Falid to delete the product!", False)

            Exit Sub
        End If

        ShowInformation("Product deleted successfully.")

        ListProduct()
    End Sub

    Protected Sub gridView_Sorting(ByVal source As Object, ByVal e As GridViewSortEventArgs) Handles gridView.Sorting
        ViewState("OrderBy") = e.SortExpression
        ListProduct(ViewState("OrderBy"))
    End Sub

    Protected Sub gridView_PageIndexChanging(ByVal source As Object, e As GridViewPageEventArgs) Handles gridView.PageIndexChanging
        gridView.PageIndex = e.NewPageIndex
        ListProduct()
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

    Private Sub ShowInformation(ByVal text As String, Optional status As Boolean = True)
        If status Then
            lblInformation.CssClass = "lblinformation-success"
        Else
            lblInformation.CssClass = "lblinformation-falid"
        End If

        lblInformation.Text = text
        lblInformation.Visible = True

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