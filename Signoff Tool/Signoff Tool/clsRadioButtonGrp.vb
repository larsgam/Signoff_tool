Public Class RadioButtonGroup
    Private radiobuttonsInput(2) As RadioButton
    Private mGButton As RadioButton
    Private mAButton As RadioButton
    Private mRButton As RadioButton
    Private mRAG As String

    Public Sub New()

    End Sub
    Public Sub New(ByRef GButton As RadioButton,
                   ByRef AButton As RadioButton,
                   ByRef RButton As RadioButton)
        mGButton = GButton
        mAButton = AButton
        mRButton = RButton
    End Sub

    Public Property RAG() As String
        Get
            If mRButton.Checked = True Then
                mRAG = "R"
            ElseIf mAButton.Checked = True Then
                mRAG = "A"
            ElseIf mGButton.Checked = True Then
                mRAG = "G"
            Else
                mRAG = "N"
            End If
            Return mRAG
        End Get
        Set(value As String)
            mRAG = value
            Select Case mRAG
                Case "R"
                    mRButton.Checked = True
                Case "A"
                    mAButton.Checked = True
                Case "G"
                    mGButton.Checked = True
            End Select
        End Set
    End Property
End Class