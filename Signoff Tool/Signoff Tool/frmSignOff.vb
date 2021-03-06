﻿Imports System.Data.SqlClient

Public Class Form1
    Private moDS As DataSet
    Private rbgInputControl As RadioButtonGroup
    Private rbgOutputControl As RadioButtonGroup
    Private rbgMTMControl As RadioButtonGroup
    Private db As String = "CEM_TEST" ' "CEM_PROD", "Hugo"


    ' Scope of Signoffs
    Dim ProcessIDs = {1, 2, 3, 4}
    Dim ProcessNames = {"Input Control", "Output Control", "MTM Comparison", "Model Performance"}
    Dim DataIDs = {1, 2, 3, 4}
    Dim DataNames = {"PFE", "CURRENT EXPOSURE", "REA", "REA ALLOCATION"}
    Dim RAGs = {"Green", "Amber", "Red"}

    ' Define controls on form as global variables
    '' Arrays of radiobutton groups  - one for process and one for data
    Private rbgProcessRadioButtonGroups(ProcessIDs.length - 1) As RadioButtonGroup
    Private rbgDataRadioButtonGroups(DataIDs.length - 1) As RadioButtonGroup
    '' Arrays of textboxes for comments
    Private tbxProcessComments(ProcessIDs.length - 1) As TextBox
    Private tbxDataComments(DataIDs.length - 1) As TextBox
    '' Arrays of textboxes for update status
    Private tbxProcessStatus(ProcessIDs.length - 1) As TextBox
    Private tbxDataStatus(DataIDs.length - 1) As TextBox

    Dim UserID As String


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MessageBox.Show("Quit CEM GUI Application?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub


    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
                Security.Principal.WindowsPrincipal Then
            'The application is using Windows authentication.
            'The Name format is DOMAIN\USERNAME
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            Return My.User.Name
        End If
    End Function


    Private Function SignoffProcessSQLBuild()
        Dim strSQL As String
        '        strSQL = "Select * FROM Signoff_process"
        strSQL = "Select a.ASOFDATE, "
        strSQL &= " a.PROCESS_ID As ID, "
        strSQL &= " a.RAG,"
        strSQL &= " a.SIGNOFF_COMMENT As COMMENT,"
        strSQL &= " a.SIGNOFF_DATETIME As DATETIME, "
        strSQL &= " a.USER_ID"
        strSQL &= " From PROCESS_SIGNOFF a"
        Return strSQL
    End Function

    Private Function SignoffDataSQLBuild()
        Dim strSQL As String
        strSQL = "Select a.ASOFDATE, "
        strSQL &= " a.REPORT_DATA_GROUP_ID As ID, "
        strSQL &= " a.RAG,"
        strSQL &= " a.SIGNOFF_COMMENT As COMMENT,"
        strSQL &= " a.SIGNOFF_DATETIME As DATETIME, "
        strSQL &= " a.USER_ID"
        strSQL &= " From REPORT_DATA_GROUP_SIGNOFF a"
        Return strSQL
    End Function

    Private Sub DataSetCreate()
        Dim processAdapter As SqlClient.SqlDataAdapter
        Dim dataAdapter As SqlClient.SqlDataAdapter


        Dim strDataSQL As String
        Dim strProcessSQL As String
        Dim strConn As String



        strDataSQL = SignoffDataSQLBuild()
        strProcessSQL = SignoffProcessSQLBuild()
        strConn = ConnectStringBuild()
        moDS = New DataSet()
        Try

            processAdapter = New SqlClient.SqlDataAdapter(strProcessSQL, strConn)
            processAdapter.Fill(moDS, "process_signoff")
            With moDS.Tables("process_signoff")
                .PrimaryKey = New DataColumn() { .Columns("asofdate"), .Columns("id")}
            End With

            dataAdapter = New SqlClient.SqlDataAdapter(strDataSQL, strConn)
            dataAdapter.Fill(moDS, "data_signoff")
            With moDS.Tables("data_signoff")
                .PrimaryKey = New DataColumn() { .Columns("asofdate"), .Columns("id")}
            End With



        Catch ex As Exception
            MessageBox.Show(ex.Message & " In DataSetCreate Sub")
        End Try
    End Sub


    Private Function ConnectStringBuild()
        Dim strConn As String

        Select Case db
            Case "CEM_TEST"
                strConn = "Data Source=rm-mssql-test;Initial Catalog=CEM_TEST;Integrated Security=True"
            Case "CEM_PROD"
                strConn = "Data Source = CE8S04;Initial Catalog=CEM_PROD;Integrated Security=True"
            Case "Hugo"
                strConn = "Data Source=DESKTOP-7N67KRI\SQLEXPRESS;"
                strConn &= "Initial Catalog=SIGNOFF;"
                strConn &= "Integrated Security=True;"
                strConn &= "Connect Timeout=15;"
                strConn &= "TrustServerCertificate =True;"
                strConn &= "ApplicationIntent=ReadWrite;"
                strConn &= "MultiSubnetFailover =False"
            Case Else
                strConn = ""
                MessageBox.Show("No valid database connection string")
        End Select

        Return strConn
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataSetCreate()
        Addbuttons()
        dtpAsofdate_ValueChanged(sender, e)
    End Sub


    Private Sub dtpAsofdate_ValueChanged(sender As Object, e As EventArgs) Handles dtpAsofdate.ValueChanged

        Dim i As Integer

        For i = 0 To ProcessIDs.length - 1
            InsertProcessRow(i)
            SyncFormProcess(i)
        Next i

        For i = 0 To DataIDs.length - 1
            InsertDataRow(i)
            SyncFormData(i)
        Next i
    End Sub

    Private Sub InsertDataRow(ByVal i As Integer)
        ' Checks if a record for a data signoff element is in the table - if not inserts it. 
        ' To be run for each control after changing date

        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strDataSQL As String
        Dim strConn As String

        Dim oDr As DataRow


        oDr = moDS.Tables("data_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), DataIDs(i)})

        If oDr Is Nothing Then

            'If no matching record, add new record to table through dataset
            ' First add new row to dataset table
            oDr = moDS.Tables("data_signoff").NewRow()
            oDr.BeginEdit()
            oDr("asofdate") = dtpAsofdate.Value.ToString("dd-MMM-yyyy")
            oDr("id") = DataIDs(i)
            oDr("RAG") = "N" ' "N" = Not signed off 
            oDr.EndEdit()

            moDS.Tables("data_signoff").Rows.Add(oDr)

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
                oAdapter.Update(moDS, "data_signoff")

                '' Tell Dataset that changes to data source are complete 
                moDS.AcceptChanges()

            Catch ex As Exception
                MessageBox.Show("Sub 'InsertDataRow' says " & ex.Message)
            End Try

        End If

    End Sub

    Private Sub InsertProcessRow(ByVal i As Integer)
        ' Checks if a record for a process signoff element is in the table - if not inserts it. 
        ' To be run for each control after changing date

        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strSQL As String
        Dim strConn As String

        Dim oDr As DataRow


        oDr = moDS.Tables("process_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), ProcessIDs(i)})

        If oDr Is Nothing Then

            'If no matching record, add new record to table through dataset
            ' First add new row to dataset table
            oDr = moDS.Tables("process_signoff").NewRow()
            oDr.BeginEdit()
            oDr("asofdate") = dtpAsofdate.Value.ToString("dd-MMM-yyyy")
            oDr("id") = ProcessIDs(i)
            oDr("RAG") = "N" ' "N" = Not signed off 
            oDr.EndEdit()

            moDS.Tables("process_signoff").Rows.Add(oDr)

            Try
                'add row to SQL table
                '' get connectionstring
                strConn = ConnectStringBuild()
                '' Build SQL String
                strSQL = SignoffProcessSQLBuild()
                '' Create data adapter
                oAdapter = New SqlClient.SqlDataAdapter(strSQL, strConn)
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




    Private Sub ProcessUpdateRow(ByVal i As Integer)
        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strSQL As String
        Dim strConn As String


        Dim oDr As DataRow


        ' Find the row to update
        oDr = moDS.Tables("process_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), ProcessIDs(i)})

        oDr.BeginEdit()
        oDr("RAG") = rbgProcessRadioButtonGroups(i).RAG
        oDr("comment") = tbxProcessComments(i).Text
        oDr("User_id") = GetUserName()
        oDr("Datetime") = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        'oDr("id") = ProcessIDs(i)
        oDr.EndEdit()

        Try
            'add row to SQL table

            '' get connectionstring
            strConn = ConnectStringBuild()
            ''Build SQL String
            strSQL = SignoffProcessSQLBuild()
            ' Create data adapter
            oAdapter = New SqlClient.SqlDataAdapter(strSQL, strConn)
            ' 'Create commandbuilder for adapter
            '' 'This will build INSERT, UPDATE and DELETE SQL
            oBuild = New SqlClient.SqlCommandBuilder(oAdapter)

            '' Get UPDATE command from commandbuilder to adapter
            oAdapter.UpdateCommand = oBuild.GetUpdateCommand()

            '' Submit UPDATE statement through adapter
            oAdapter.Update(moDS, "process_signoff")

            '' Tell Dataset that changes to data source are complete 
            moDS.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " - in Sub ProcessUpdateRow")
        End Try
    End Sub ' ProcessUpdateRow


    Private Sub DataUpdateRow(ByVal i As Integer)
        Dim oAdapter As SqlClient.SqlDataAdapter
        Dim oBuild As SqlClient.SqlCommandBuilder
        Dim strSQL As String
        Dim strConn As String


        Dim oDr As DataRow


        ' Find the row to update
        oDr = moDS.Tables("data_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), DataIDs(i)})

        oDr.BeginEdit()
        oDr("RAG") = rbgDataRadioButtonGroups(i).RAG
        oDr("comment") = tbxDataComments(i).Text
        oDr("User_id") = GetUserName()
        oDr("Datetime") = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        oDr.EndEdit()

        Try
            'add row to SQL table

            '' get connectionstring
            strConn = ConnectStringBuild()
            ''Build SQL String
            strSQL = SignoffDataSQLBuild()
            ' Create data adapter
            oAdapter = New SqlClient.SqlDataAdapter(strSQL, strConn)
            ' 'Create commandbuilder for adapter
            '' 'This will build INSERT, UPDATE and DELETE SQL
            oBuild = New SqlClient.SqlCommandBuilder(oAdapter)

            '' Get UPDATE command from commandbuilder to adapter
            oAdapter.UpdateCommand = oBuild.GetUpdateCommand()

            '' Submit UPDATE statement through adapter
            oAdapter.Update(moDS, "data_signoff")

            '' Tell Dataset that changes to data source are complete 
            moDS.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " - in Sub DataUpdateRow")
        End Try
    End Sub ' DataUpdateRow



    Private Sub SyncFormProcess(ByVal i As Integer)
        ' Syncronised the process blocks on form with data from database
        Dim oDr As DataRow


        oDr = moDS.Tables("process_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), ProcessIDs(i)})
        If oDr IsNot Nothing Then
            rbgProcessRadioButtonGroups(i).RAG = oDr("RAG")
            tbxProcessComments(i).Text = oDr.Item("Comment").ToString
            If oDr.Item("datetime").ToString <> "" Then
                tbxProcessStatus(i).Text = oDr.Item("USER_ID").ToString & " - " & oDr.Item("datetime").ToString
            Else
                tbxProcessStatus(i).Text = "Not signed off"
            End If
        Else
            rbgProcessRadioButtonGroups(i).RAG = "N"
            tbxProcessComments(i).Text = ""
            tbxProcessStatus(i).Text = "Not signed off"
        End If

    End Sub 'SyncFormProcess



    Private Sub SyncFormData(ByVal i As Integer)
        ' Syncronised the data blocks on form with data from database
        Dim oDr As DataRow


        oDr = moDS.Tables("data_signoff").Rows.Find({dtpAsofdate.Value.ToString("dd-MMM-yyyy"), DataIDs(i)})
        If oDr IsNot Nothing Then
            rbgDataRadioButtonGroups(i).RAG = oDr("RAG")
            tbxDataComments(i).Text = oDr.Item("Comment").ToString
            If oDr.Item("datetime").ToString <> "" Then
                tbxDataStatus(i).Text = oDr.Item("USER_ID").ToString & " - " & oDr.Item("datetime").ToString
            Else
                tbxDataStatus(i).Text = "Not signed off"
            End If
        Else
            rbgDataRadioButtonGroups(i).RAG = "N"
            tbxDataComments(i).Text = ""
            tbxDataStatus(i).Text = "Not signed off"
        End If

    End Sub 'SyncFormData



    Private Sub RadioButton_click(sender As Object, e As EventArgs)
        MessageBox.Show(sender.name)
    End Sub


    Private Sub Addbuttons()
        Dim gbx As GroupBox
        Dim rbutton(2) As RadioButton

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
        Dim fsmall As New System.Drawing.Font("Microsoft Sans Serif", 6, FontStyle.Regular)


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

        ' Process Signoff 
        For i = 0 To ProcessIDs.length - 1
            gbx = New GroupBox
            gbx.Name = "gbxProcess" & ProcessIDs(i).ToString()
            gbx.Text = ProcessNames(i)
            gbx.Left = xStart
            gbx.Top = yStart + i * (gbxSpace + gbxHeight)
            gbx.Height = gbxHeight
            gbx.Width = gbxWide
            gbx.Font = f
            gbxDailyProcess.Controls.Add(gbx)

            ' Create 3 radio buttons - for Green, Amber and Red 
            Dim j = 0
            For Each rag In RAGs
                rbutton(j) = New RadioButton
                rbutton(j).Name = "rbnProcess" & ProcessIDs(i).ToString() & rag
                rbutton(j).Text = rag
                rbutton(j).Width = rbnWidth
                rbutton(j).Left = rbnxStart + j * (rbnWidth + rbnHSpace)
                rbutton(j).Top = rbnyStart
                rbutton(j).UseVisualStyleBackColor = True
                'AddHandler rbutton(j).Click, AddressOf RadioButton_click
                gbx.Controls.Add(rbutton(j))
                j = j + 1
            Next rag
            rbgProcessRadioButtonGroups(i) = New RadioButtonGroup(rbutton(0), rbutton(1), rbutton(2))

            ' Textbox for comments
            tbxProcessComments(i) = New TextBox
            tbxProcessComments(i).Multiline = True
            tbxProcessComments(i).ScrollBars = ScrollBars.Vertical

            tbxProcessComments(i).Height = tbxHeight
            tbxProcessComments(i).Width = tbxwidth
            tbxProcessComments(i).Left = rbnxStart + 3 * (rbnWidth + rbnHSpace)
            tbxProcessComments(i).Top = tbxyStart
            gbx.Controls.Add(tbxProcessComments(i))

            ' small non-enabled textbox for update status
            tbxProcessStatus(i) = New TextBox
            tbxProcessStatus(i).Height = rbutton(1).Height
            tbxProcessStatus(i).Width = tbxwidth
            tbxProcessStatus(i).Left = rbnxStart
            tbxProcessStatus(i).Top = rbnyStart + rbutton(1).Height
            tbxProcessStatus(i).Enabled = False
            tbxProcessStatus(i).BorderStyle = BorderStyle.None
            tbxProcessStatus(i).ForeColor = Color.Gray
            tbxProcessStatus(i).BackColor = TabPage1.BackColor
            'tbxProcessStatus(i).Text = "test"
            tbxProcessStatus(i).Font = fsmall
            gbx.Controls.Add(tbxProcessStatus(i))

        Next i


        ' DATA Signoff

        For i As Integer = 0 To DataIDs.length - 1
            gbx = New GroupBox
            gbx.Name = "gbxData" & ProcessIDs(i).ToString()
            gbx.Text = DataNames(i)
            gbx.Left = xStart
            gbx.Top = yStart + i * (gbxSpace + gbxHeight)
            gbx.Height = gbxHeight
            gbx.Width = gbxWide
            gbx.Font = f
            gbxDailyData.Controls.Add(gbx)

            ' Create 3 radio buttons - for Green, Amber and Red 
            Dim j = 0
            For Each rag In RAGs
                rbutton(j) = New RadioButton
                rbutton(j).Name = "rbnData" & ProcessIDs(i).ToString() & rag
                rbutton(j).Text = rag
                rbutton(j).Width = rbnWidth
                rbutton(j).Left = rbnxStart + j * (rbnWidth + rbnHSpace)
                rbutton(j).Top = rbnyStart
                rbutton(j).UseVisualStyleBackColor = True
                'AddHandler rbutton(j).Click, AddressOf RadioButton_click
                gbx.Controls.Add(rbutton(j))
                j = j + 1
            Next rag
            rbgDataRadioButtonGroups(i) = New RadioButtonGroup(rbutton(0), rbutton(1), rbutton(2))


            ' Textbox for comments
            tbxDataComments(i) = New TextBox
            tbxDataComments(i).Multiline = True
            tbxDataComments(i).ScrollBars = ScrollBars.Vertical

            tbxDataComments(i).Height = tbxHeight
            tbxDataComments(i).Width = tbxwidth
            tbxDataComments(i).Left = rbnxStart + 3 * (rbnWidth + rbnHSpace)
            tbxDataComments(i).Top = tbxyStart
            gbx.Controls.Add(tbxDataComments(i))


            ' small non-enabled textbox for update status
            tbxDataStatus(i) = New TextBox
            tbxDataStatus(i).Height = rbutton(1).Height
            tbxDataStatus(i).Width = tbxwidth
            tbxDataStatus(i).Left = rbnxStart
            tbxDataStatus(i).Top = rbnyStart + rbutton(1).Height
            tbxDataStatus(i).Enabled = False
            tbxDataStatus(i).BorderStyle = BorderStyle.None
            tbxDataStatus(i).ForeColor = Color.Gray
            tbxDataStatus(i).BackColor = TabPage1.BackColor
            tbxDataStatus(i).Font = fsmall
            '  tbxDataStatus(i).Text = "test"
            gbx.Controls.Add(tbxDataStatus(i))


        Next i




    End Sub

    Private Sub btnProcessGreen_Click(sender As Object, e As EventArgs) Handles btnProcessGreen.Click
        For i = 0 To ProcessNames.length - 1
            rbgProcessRadioButtonGroups(i).RAG = "G"
        Next i
    End Sub

    Private Sub btnDataGreen_Click(sender As Object, e As EventArgs) Handles btnDataGreen.Click
        For i = 0 To DataNames.length - 1
            rbgDataRadioButtonGroups(i).RAG = "G"
        Next i
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        For i = 0 To ProcessIDs.length - 1
            ProcessUpdateRow(i)
            SyncFormProcess(i)
        Next i

        For i = 0 To DataIDs.length - 1
            DataUpdateRow(i)
            SyncFormData(i)
        Next i


    End Sub
End Class



