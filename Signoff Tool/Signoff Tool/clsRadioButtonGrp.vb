Public Class RadioButtonGroup
    Private radiobuttonsInput(2) As RadioButton
    Private mRButton As RadioButton
    Private mAButton As RadioButton
    Private mGButton As RadioButton
    Private mRAG As String

    Public Sub New()

    End Sub
    Public Sub New(ByRef RButton As RadioButton,
                   ByRef AButton As RadioButton,
                   ByRef GButton As RadioButton)
        mRButton = RButton
        mAButton = AButton
        mGButton = GButton
    End Sub

    'Public Sub checkRAG(ByVal RAG As String)
    '    Select Case RAG
    '        Case "R" 
    '            mRButton.Checked = True
    '        Case "A"
    '            mAButton.Checked = True
    '        Case "G"
    '            mGButton.Checked = True
    '    End Select
    'End Sub

    Public Property RAG() As String
        Get
            If mRButton.Checked = True Then
                mRAG = "R"
            ElseIf mAButton.Checked = True Then
                mRAG = "A"
            ElseIf mGButton.Checked = True Then
                mRAG = "G"
            Else
                mRAG = "R"
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