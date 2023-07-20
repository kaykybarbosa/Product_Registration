Public Class ValidationTexts
    Private PRODUCT_ID As TextBox
    Private NAME As TextBox
    Private QUANTITY As TextBox
    Private COLOR As TextBox
    Private REGISTRATION_DATE As TextBox
    Private CHECK_AVAILABLE As CheckBox
    Private CHECK_UNAVAILABLE As CheckBox
    Private SPECIFICATION As TextBox

    Public Sub ValidationTexts()

    End Sub
    Public Sub New(ByVal txtProductId As TextBox, ByVal txtName As TextBox, ByVal txtQuantity As TextBox, ByVal txtColor As TextBox,
                   ByVal txtRegistrationDate As TextBox, ByVal checkAvailable As CheckBox, ByVal checkUnavailable As CheckBox, ByVal txtSpecification As TextBox)
        Me.PRODUCT_ID = txtProductId
        Me.NAME = txtName
        Me.QUANTITY = txtQuantity
        Me.COLOR = txtColor
        Me.REGISTRATION_DATE = txtRegistrationDate
        Me.CHECK_AVAILABLE = checkAvailable
        Me.CHECK_UNAVAILABLE = checkUnavailable
        Me.SPECIFICATION = txtSpecification
    End Sub
    Public Function Validate_Fields(Optional isUpdate As Boolean = False)
        Dim resultEmpty = Validate_Empty(isUpdate)

        If Not resultEmpty.Equals("VALID") Then
            Return resultEmpty

        ElseIf QUANTITY.Text < 0 Then
            Return "lblQuantity"

        ElseIf CHECK_AVAILABLE.Checked And CHECK_UNAVAILABLE.Checked Then
            Return "lblStatus"

        ElseIf Not isUpdate Then

            If Left(REGISTRATION_DATE.Text, 4) < 1900 Then
                Return "lblRegistrationDate"
            Else
                Return "VALID"
            End If

        Else
            Return "VALID"

        End If
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

        ElseIf Not CHECK_AVAILABLE.Checked And Not CHECK_UNAVAILABLE.Checked Then
            Return "lblStatus"

        ElseIf String.IsNullOrEmpty(SPECIFICATION.Text) Then
            Return "lblSpecification"

        Else
            Return "VALID"
        End If
    End Function

End Class
