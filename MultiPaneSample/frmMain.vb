Imports System.IO
Public Class frmMain
    Private strfileName As String
    Private WithEvents Welcome As sunfrmWelcome

    Private arrSubForms As ArrayList

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        arrSubForms = New ArrayList
        Welcome = New sunfrmWelcome

        'add all subforms to the arraylist
        arrSubForms.Add(Welcome)

        'add each subform to the workarea groubox (hidden by default)
        grpWorkArea.Controls.Add(Welcome)
        Welcome.Location = CalcLocation(grpWorkArea, Welcome)
        Welcome.Visible = True
    End Sub

    Private Sub HideAllSubForms()
        'hide all subforms
        For Each obj As UserControl In arrSubForms
            obj.Visible = False
        Next
    End Sub
    Private Function CalcLocation(grpbox As GroupBox, subForm As UserControl) As Point
        Return New Point((grpbox.Width - subForm.Width) / 2, (grpbox.Width - subForm.Width) / 2)

    End Function

    Private Sub OpenFile(strType As String)
        Dim intResult As Integer
        ofdData.InitialDirectory = Application.StartupPath
        ofdData.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt"
        ofdData.FilterIndex = 2
        Select Case strType
            Case "CustomerData"
                ofdData.Title = "Select Customer Data File"
            Case "OrderData"
                ofdData.Title = "Select Order Data File"
            Case Else
                MessageBox.Show("Unexpected data type in OpenFile", "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
        intResult = ofdData.ShowDialog
        If intResult = DialogResult.Cancel Then
            Exit Sub
        End If
        strfileName = ofdData.FileName
        Try
            ReadInputFile(strfileName, strType)
        Catch ex As Exception
            'put error handling here - at least a message boc to dump out the raw error
        End Try
    End Sub

    Private Sub ReadInputFile(strFileIn As String, strType As String)
        Dim fileIn As StreamReader
        Dim strLineIn As String
        Dim strFields() As String
        Dim i As Integer
        fileIn = New StreamReader(strFileIn)
        fileIn.ReadLine() 'throw away the first record in the file

    End Sub
End Class
