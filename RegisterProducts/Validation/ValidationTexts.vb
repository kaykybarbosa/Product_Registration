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
        Dim result As String
        Dim resultEmpty = Validate_Empty(isUpdate)

        If Not resultEmpty.Equals("VALID") Then
            Return resultEmpty

        ElseIf QUANTITY.Text < 0 Then
            result = "lblQuantity"

        ElseIf CHECK_LIST_STATUS.Items(0).Selected And CHECK_LIST_STATUS.Items(1).Selected Then
            result = "lblStatus"

        ElseIf Not isUpdate Then

            If Left(REGISTRATION_DATE.Text, 4) < 1900 Then
                result = "lblRegistrationDate"
            Else
                result = "VALID"
            End If

        Else
            result = "VALID"
        End If

        Return result

    End Function

    Public Function Validate_Empty(ByVal isUpdate As Boolean)
        If isUpdate Then
            If String.IsNullOrEmpty(PRODUCT_ID.Text) Then
                Return "lblProductId"
            End If
        End If

        If String.IsNullOrEmpty(NAME.Text) Then
            Return "lblName"

        ElseIf String.IsNullOrEmpty(QUANTITY.Text) Then
            Return "lblQuantity"

        ElseIf String.IsNullOrEmpty(COLOR.Text) Then
            Return "lblColor"

        ElseIf String.IsNullOrEmpty(REGISTRATION_DATE.Text) And Not isUpdate Then
            Return "lblRegistrationDate"

        ElseIf Not CHECK_LIST_STATUS.Items(0).Selected And Not CHECK_LIST_STATUS.Items(1).Selected Then
            Return "lblStatus"

        ElseIf String.IsNullOrEmpty(SPECIFICATION.Text) Then
            Return "lblSpecification"

        Else
            Return "VALID"
        End If
    End Function

End Class
