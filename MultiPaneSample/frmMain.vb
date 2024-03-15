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

End Class
