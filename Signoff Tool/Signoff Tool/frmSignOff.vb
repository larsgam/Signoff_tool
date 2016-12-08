﻿Imports System.Data.SqlClient

Public Class Form1
    Private moDS As DataSet
    Private rbgInputControl As RadioButtonGroup
    Private rbgOutputControl As RadioButtonGroup
    Private rbgMTMControl As RadioButtonGroup

    'Dim ProcessIDs() As Integer
    'Dim ProcessNames() As String
    'Dim DataIDs() As Integer
    'Dim DataNames() As String

    'Private Sub defScope()

    'End Sub

    Dim ProcessIDs = {1, 2, 3, 4}
    Dim ProcessNames = {"Input Control", "Output Control", "MTM Comparison", "Model Performance"}
    Dim DataIDs = {1, 2, 3, 4}
    Dim DataNames = {"PFE", "CURRENT EXPOSURE", "REA", "REA ALLOCATION"}


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Quit Signoff Application?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Function SignoffDataSQLBuild()
        Dim strSQL As String
        strSQL = "Select * FROM Signoff_data"
        Return strSQL
    End Function

    Private Function SignoffProcessSQLBuild()
        Dim strSQL As String
        '        strSQL = "Select * FROM Signoff_process"
        strSQL = "Select a.ASOFDATE, "
        strSQL &= " a.PROCESS_ID as ID, "
        strSQL &= " a.RAG,"
        strSQL &= " a.SIGNOFF_COMMENT as COMMENT,"
        strSQL &= " a.SIGNOFF_DATETIME as DATETIME, "
        strSQL &= " a.USER_ID"
        strSQL &= " From PROCESS_SIGNOFF a"
        Return strSQL
    End Function


    Private Sub DataSetCreate()
        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim processAdapter As SqlClient.SqlDataAdapter
        Dim strDataSQL As String
        Dim strProcessSQL As String
        Dim strConn As String

        strDataSQL = SignoffDataSQLBuild()
        strProcessSQL = SignoffProcessSQLBuild()
        strConn = ConnectStringBuild()
        moDS = New DataSet()
        Try
            oAdapter = New SqlClient.SqlDataAdapter(strDataSQL, strConn)
            oAdapter.Fill(moDS, "Signoff_data")
            With moDS.Tables("Signoff_data")
                .PrimaryKey = New DataColumn() { .Columns("asofdate"), .Columns("data_type_id")}
            End With

            processAdapter = New SqlClient.SqlDataAdapter(strProcessSQL, strConn)
            processAdapter.Fill(moDS, "process_signoff")
            With moDS.Tables("process_signoff")
                .PrimaryKey = New DataColumn() { .Columns("asofdate"), .Columns("id")}
            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message & " in DataSetCreate Sub")
        End Try
    End Sub



    Private Function ConnectStringBuild()
        Dim strConn As String
        strConn = "Data Source=DESKTOP-7N67KRI\SQLEXPRESS;"
        strConn &= "Initial Catalog=SIGNOFF;"
        strConn &= "Integrated Security=True;"
        strConn &= "Connect Timeout=15;"
        strConn &= "TrustServerCertificate =True;"
        strConn &= "ApplicationIntent=ReadWrite;"
        strConn &= "MultiSubnetFailover =False"
        Return strConn
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbgInputControl = New RadioButtonGroup(rbnInputRed, rbnInputAmber, rbnInputGreen)
        DataSetCreate()
        Addbuttons()
    End Sub

    Private Sub dtpAsofdate_ValueChanged(sender As Object, e As EventArgs) Handles dtpAsofdate.ValueChanged
        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strDataSQL As String
        Dim strConn As String

        Dim intID As Integer
        Dim oDr As DataRow


        For Each intID In ProcessIDs
            InsertProcessRow(intID)
        Next


        intID = 2

        oDr = moDS.Tables("Signoff_data").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), intID})

        If oDr IsNot Nothing Then
            rbgInputControl.RAG() = oDr("RAG")
            tbxCommentInput.Text = oDr("Signoff_Comment")
            tbxUserInput.Text = oDr("User_ID") & " - " & oDr("SIGNOFF_DATETIME")
        Else
            'Add new record to table through dataset
            ' First add new row to dataset table
            oDr = moDS.Tables("Signoff_data").NewRow()
            oDr.BeginEdit()
            oDr("asofdate") = dtpAsofdate.Value.ToString("dd-MMM-yyyy")
            oDr("Data_type_id") = intID
            'oDr("Signoff_comment") = "skrevet ind af vb"
            oDr("RAG") = "N"
            oDr.EndEdit()

            moDS.Tables("Signoff_data").Rows.Add(oDr)

            Try
                'add row to SQL table
                '' get connectionstring
                strConn = ConnectStringBuild()
                '' Build SQL String
                strDataSQL = SignoffDataSQLBuild()
                '' Create data adapter
                oAdapter = New SqlClient.SqlDataAdapter(strDataSQL, strConn)
                '' Create commandbuilder for adapter
                '' This will build INSERT, UPDATE and DELETE SQL
                oBuild = New SqlClient.SqlCommandBuilder(oAdapter)

                '' Get Insert command from commandbuilder to adapter
                oAdapter.InsertCommand = oBuild.GetInsertCommand()

                '' Submit Insert statement through adapter
                oAdapter.Update(moDS, "Signoff_data")

                '' Tell Dataset that changes to data source are complete 
                moDS.AcceptChanges()

            Catch ex As Exception

            End Try

            rbgInputControl.RAG() = oDr("RAG")
            tbxCommentInput.Text = ""
            tbxUserInput.Text = "Not Signed Off"

        End If
    End Sub


    Private Sub InsertProcessRow(ByVal id As Integer)
        ' Checks if a record for a process signoff element is in the table - if not inserts it. 
        ' To be run for each control after changing date

        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strDataSQL As String
        Dim strConn As String

        Dim intID As Integer
        Dim oDr As DataRow


        oDr = moDS.Tables("process_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), id})

        If oDr Is Nothing Then

            'If no matching record, add new record to table through dataset
            ' First add new row to dataset table
            oDr = moDS.Tables("process_signoff").NewRow()
            oDr.BeginEdit()
            oDr("asofdate") = dtpAsofdate.Value.ToString("dd-MMM-yyyy")
            oDr("id") = id
            oDr("RAG") = "N" ' "N" = Not signed off 
            oDr.EndEdit()

            moDS.Tables("process_signoff").Rows.Add(oDr)

            Try
                'add row to SQL table
                '' get connectionstring
                strConn = ConnectStringBuild()
                '' Build SQL String
                strDataSQL = SignoffProcessSQLBuild()
                '' Create data adapter
                oAdapter = New SqlClient.SqlDataAdapter(strDataSQL, strConn)
                '' Create commandbuilder for adapter
                '' This will build INSERT, UPDATE and DELETE SQL
                oBuild = New SqlClient.SqlCommandBuilder(oAdapter)

                '' Get Insert command from commandbuilder to adapter
                oAdapter.InsertCommand = oBuild.GetInsertCommand()

                '' Submit Insert statement through adapter
                oAdapter.Update(moDS, "process_signoff")

                '' Tell Dataset that changes to data source are complete 
                moDS.AcceptChanges()

            Catch ex As Exception
                MessageBox.Show("Sub 'InsertProcessRow' says " & ex.Message)
            End Try

        End If

    End Sub 'InsertProcessRow

    Private Sub rbnInputGreen_Click(sender As Object, e As EventArgs) Handles _
                                           rbnInputGreen.Click,
                                           rbnInputAmber.Click,
                                           rbnInputRed.Click
        If rbgInputControl.RAG = "G" Then
            tbxCommentInput.Enabled = False
        Else
            tbxCommentInput.Enabled = True
        End If
    End Sub

    Private Sub btnUpdateInput_Click(sender As Object, e As EventArgs) Handles btnUpdateInput.Click
        DataUpdate()
    End Sub

    Private Sub DataUpdate()
        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strDataSQL As String
        Dim strConn As String


        Dim intID As Integer
        Dim oDr As DataRow

        intID = 2

        ' Find the row to update
        oDr = moDS.Tables("Signoff_data").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), intID})

        oDr.BeginEdit()
        oDr("RAG") = rbgInputControl.RAG
        oDr("Signoff_comment") = tbxCommentInput.Text
        oDr("User_id") = "BB5102"
        oDr("Signoff_Datetime") = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        oDr("Data_type_id") = intID
        oDr.EndEdit()

        Try
            'add row to SQL table

            '' get connectionstring
            strConn = ConnectStringBuild()
            ''Build SQL String
            strDataSQL = SignoffDataSQLBuild()
            ' Create data adapter
            oAdapter = New SqlClient.SqlDataAdapter(strDataSQL, strConn)
            ' 'Create commandbuilder for adapter
            '' 'This will build INSERT, UPDATE and DELETE SQL
            oBuild = New SqlClient.SqlCommandBuilder(oAdapter)

            '' Get UPDATE command from commandbuilder to adapter
            oAdapter.UpdateCommand = oBuild.GetUpdateCommand()

            '' Submit UPDATE statement through adapter
            oAdapter.Update(moDS, "Signoff_data")

            '' Tell Dataset that changes to data source are complete 
            moDS.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Addbuttons()
        Dim gbx As GroupBox
        Dim rbutton As RadioButton
        Dim tbx As TextBox

        Dim xStart As Integer
        Dim yStart As Integer
        Dim gbxHeight As Integer
        Dim gbxWide As Integer
        Dim gbxSpace As Integer

        Dim rbnxStart As Integer
        Dim rbnyStart As Integer
        Dim rbnWidth As Integer
        Dim rbnHSpace As Integer

        Dim tbxyStart As Integer
        Dim tbxHeight As Integer
        Dim tbxwidth As Integer


        Dim f As New System.Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)

        xStart = 10
        yStart = 30
        gbxHeight = 75
        gbxWide = 370
        gbxSpace = 10

        rbnxStart = 10
        rbnyStart = 20
        rbnWidth = 60
        rbnHSpace = 2

        tbxyStart = 15
        tbxHeight = 50
        tbxwidth = 170

        For i As Integer = 0 To 3
            gbx = New GroupBox
            gbx.Name = "gbxProcess" & ProcessIDs(i).ToString()
            gbx.Text = ProcessNames(i)
            gbx.Left = xStart
            gbx.Top = yStart + i * (gbxSpace + gbxHeight)
            gbx.Height = gbxHeight
            gbx.Width = gbxWide
            gbx.Font = f
            gbxDailyProcess.Controls.Add(gbx)


            rbutton = New RadioButton
            rbutton.Name = "rbnProcess" & ProcessIDs(i).ToString() & "Green"
            rbutton.Text = "Green"
            rbutton.TabIndex = 1 + i
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            rbutton = New RadioButton
            rbutton.Name = "rbnProcess" & ProcessIDs(i).ToString() & "Amber"
            rbutton.Text = "Amber"
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart + rbnWidth + rbnHSpace
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            rbutton = New RadioButton
            rbutton.Name = "rbnProcess" & ProcessIDs(i).ToString() & "Red"
            rbutton.Text = "Red"
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart + 2 * (rbnWidth + rbnHSpace)
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            ' Textbox for comments
            tbx = New TextBox
            tbx.Multiline = True
            tbx.ScrollBars = ScrollBars.Vertical

            tbx.Height = tbxHeight
            tbx.Width = tbxwidth
            tbx.Left = rbnxStart + 3 * (rbnWidth + rbnHSpace)
            tbx.Top = tbxyStart
            gbx.Controls.Add(tbx)

        Next i


        ' DATA Controls

        For i As Integer = 0 To 3
            gbx = New GroupBox
            gbx.Name = "gbxData" & ProcessIDs(i).ToString()
            gbx.Text = DataNames(i)
            gbx.Left = xStart
            gbx.Top = yStart + i * (gbxSpace + gbxHeight)
            gbx.Height = gbxHeight
            gbx.Width = gbxWide
            gbx.Font = f
            gbxDailyData.Controls.Add(gbx)


            rbutton = New RadioButton
            rbutton.Name = "rbnData" & ProcessIDs(i).ToString() & "Green"
            rbutton.Text = "Green"
            rbutton.TabIndex = 1 + i
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            rbutton = New RadioButton
            rbutton.Name = "rbnData" & ProcessIDs(i).ToString() & "Amber"
            rbutton.Text = "Amber"
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart + rbnWidth + rbnHSpace
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            rbutton = New RadioButton
            rbutton.Name = "rbnData" & ProcessIDs(i).ToString() & "Red"
            rbutton.Text = "Red"
            rbutton.Width = rbnWidth
            rbutton.Left = rbnxStart + 2 * (rbnWidth + rbnHSpace)
            rbutton.Top = rbnyStart
            rbutton.UseVisualStyleBackColor = True
            gbx.Controls.Add(rbutton)

            ' Textbox for comments
            tbx = New TextBox
            tbx.Multiline = True
            tbx.ScrollBars = ScrollBars.Vertical

            tbx.Height = tbxHeight
            tbx.Width = tbxwidth
            tbx.Left = rbnxStart + 3 * (rbnWidth + rbnHSpace)
            tbx.Top = tbxyStart
            gbx.Controls.Add(tbx)

        Next i




    End Sub


End Class


