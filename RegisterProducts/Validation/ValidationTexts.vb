Public Class ValidationTexts
    Private PRODUCT_ID As TextBox
    Private NAME As TextBox
    Private QUANTITY As TextBox
    Private COLOR As TextBox
    Private REGISTRATION_DATE As TextBox
    Private CHECK_LIST_STATUS As CheckBoxList
    Private SPECIFICATION As TextBox

    Public Sub ValidationTexts()

    End Sub

    Public Sub New(ByVal txtProductId As TextBox, ByVal txtName As TextBox, ByVal txtQuantity As TextBox, ByVal txtColor As TextBox,
                   ByVal txtRegistrationDate As TextBox, ByVal txtsStatus As CheckBoxList, ByVal txtSpecification As TextBox)
        Me.PRODUCT_ID = txtProductId
        Me.NAME = txtName
        Me.QUANTITY = txtQuantity
        Me.COLOR = txtColor
        Me.REGISTRATION_DATE = txtRegistrationDate
        Me.CHECK_LIST_STATUS = txtsStatus
        Me.SPECIFICATION = txtSpecification
    End Sub

    Public Function Validate_Fields(Optional isUpdate As Boolean = False)
        Dim resultEmpty = Validate_Empty(isUpdate)
        Dim resultRules = Validate_Rules()

        If Not resultEmpty.Equals("VALID") Then
            Return resultEmpty
        End If

        If Not resultRules.Equals("VALID") Then
            Return resultRules
        End If

        If QUANTITY.Text < 0 Then
            Return "lblQuantity"
        End If

        If CHECK_LIST_STATUS.Items(0).Selected And CHECK_LIST_STATUS.Items(1).Selected Then
            Return "lblStatus"
        End If

        If Not isUpdate Then

            If Left(REGISTRATION_DATE.Text, 4) < 1900 Then
                Return "lblRegistrationDate"
            Else
                Return "VALID"
            End If

        End If

        Return "VALID"

    End Function

    Public Function Validate_Empty(ByVal isUpdate As Boolean)
        If isUpdate Then
            If String.IsNullOrEmpty(PRODUCT_ID.Text) Then
                Return "lblProductId"
            End If
        End If

        If String.IsNullOrEmpty(NAME.Text) Then
            Return "lblName"
        End If

        If String.IsNullOrEmpty(QUANTITY.Text) Then
            Return "lblQuantity"
        End If

        If String.IsNullOrEmpty(COLOR.Text) Then
            Return "lblColor"
        End If

        If String.IsNullOrEmpty(REGISTRATION_DATE.Text) And Not isUpdate Then
            Return "lblRegistrationDate"
        End If

        If Not CHECK_LIST_STATUS.Items(0).Selected And Not CHECK_LIST_STATUS.Items(1).Selected Then
            Return "lblStatus"
        End If

        If String.IsNullOrEmpty(SPECIFICATION.Text) Then
            Return "lblSpecification"
        End If

        Return "VALID"

    End Function

    Public Function Validate_Rules()

        If NAME.Text.Length > 60 Then
            Return "lblRulesName"
        End If

        If COLOR.Text.Length > 30 Then
            Return "lblRulesColor"
        End If

        If SPECIFICATION.Text.Length > 255 Then
            Return "lblRulesSpecification"
        End If

        Return "VALID"

    End Function

End Class
