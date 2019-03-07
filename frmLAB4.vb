Option Strict On
Public Class frmLAB4

    'Declarations

    Public Const MINIMUM_VALUE = 0
    Public Const MAXIMUM_VALUE = 99999
    Sub ResetForm()

        'reset values

        '============

        'reset true/false 
        'enable the calculate button

        'clear text/labels

        '================
    End Sub

    Function ValidInput(ByVal input As String) As Boolean

        Dim validOut As Integer
        Dim validated As Boolean

        If Integer.TryParse(input, validOut) Then
            If validOut >= MINIMUM_VALUE And validOut <= MAXIMUM_VALUE Then
                validated = True
            Else
                validated = False
            End If
        End If

        Return validated

    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit() ' exit program
    End Sub

    Private Sub lvwOutput_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwOutput.SelectedIndexChanged

    End Sub

    Private Sub frmLAB4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetForm()
    End Sub
End Class
