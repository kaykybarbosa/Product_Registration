Public Class ValidationTexts
    Private PRODUCT_ID As TextBox
    Private NAME As TextBox
    Private SPECIFICATION As TextBox
    Private QUANTITY As TextBox
    Private COLOR As TextBox
    Private REGISTRATION_DATE As TextBox
    Private CHECK_AVAILABLE As CheckBox
    Private CHECK_UNAVAILABLE As CheckBox

    Public Sub ValidationTexts()

    End Sub
    Public Sub New(ByVal txtProductId As TextBox, ByVal txtName As TextBox, ByVal txtSpecification As TextBox, ByVal txtQuantity As TextBox,
                               ByVal txtColor As TextBox, ByVal txtRegistrationDate As TextBox, ByVal checkAvailable As CheckBox, ByVal checkUnavailable As CheckBox)
        Me.PRODUCT_ID = txtProductId
        Me.NAME = txtName
        Me.SPECIFICATION = txtSpecification
        Me.QUANTITY = txtQuantity
        Me.COLOR = txtColor
        Me.REGISTRATION_DATE = txtRegistrationDate
        Me.CHECK_AVAILABLE = checkAvailable
        Me.CHECK_UNAVAILABLE = checkUnavailable
    End Sub
    Public Function Validate_Fields(Optional isUpdate As Boolean = False)
        Dim resultEmpty = Validate_Empty(isUpdate)

        If Not resultEmpty.Equals("VALID") Then
            Return resultEmpty
        ElseIf QUANTITY.Text < 0 Then
            Return "Quantity must be greater than 0."
        ElseIf Left(REGISTRATION_DATE.Text, 4) < 1900 Then
            Return "Year invalid."
        ElseIf CHECK_AVAILABLE.Checked And CHECK_UNAVAILABLE.Checked Then
            Return "Just Status."
        Else
            Return "VALID"
        End If
    End Function

    Public Function Validate_Empty(ByVal isUpdate As Boolean)
        If isUpdate Then
            If String.IsNullOrEmpty(PRODUCT_ID.Text) Then
                Return "N° Product is required."
            End If
        End If

        If String.IsNullOrEmpty(NAME.Text) Then
            Return "Name is required."
        ElseIf String.IsNullOrEmpty(SPECIFICATION.Text) Then
            Return "Specification is required."
        ElseIf String.IsNullOrEmpty(COLOR.Text) Then
            Return "Color is required."
        ElseIf String.IsNullOrEmpty(REGISTRATION_DATE.Text) Then
            Return "Registration Date is required."
        ElseIf Not CHECK_AVAILABLE.Checked And Not CHECK_UNAVAILABLE.Checked Then
            Return "Status required."
        Else
            Return "VALID"
        End If
    End Function

End Class
