Option Strict On

Public Class frmLAB4

    'Course: NETD-2202-01
    'Assignment: Lab 4 Car Inventory
    'Name: Sterling Wenzelbach
    'Date : Created: 2019-03-03; Modifed 2019-03-11
    'Program description: A user will select a make and year from a drop down list. A price and model will be typed in textboxe, and a checkbox for new status is available.
    'When the information is validated, it will be displayed in the listbox output. The user can add new cars or edit existing cars by selectng them in the listbox.
    '==================================
    'Reference: 4. Example CustomerList
    '==================================

    'Declarations
    Private carList As New SortedList          ' collection of all the customerList in the list
    Private currentID As String = String.Empty ' current selected customer identification number
    Private edit As Boolean = False            '


    Sub TextBoxProperties()
        txtPrice.Select()
        txtPrice.SelectionStart = 0
        txtPrice.SelectionLength = Len(txtPrice.Text)

    End Sub
    Private Sub Reset()

        'txtPrice.Text = String.Empty
        'txtModel.Text = String.Empty
        'cmbYear.SelectedIndex = -1
        'cmbMake.SelectedIndex = -1
        'chkNew.Checked = False
        lblOutput.Text = String.Empty
        currentID = String.Empty

    End Sub

    Function ValidInput() As Boolean

        Dim validated As Boolean = False
        Dim output As String = String.Empty
        Const MINIMUM_VALUE = 0

        If txtPrice.Text.Trim.Length = 0 Then
            output += "Enter a price." & vbCrLf
        ElseIf IsNumeric(txtPrice.Text) = False Then
            output += "Price must be a number." & vbCrLf
            TextBoxProperties()
        ElseIf CDbl(txtPrice.Text) <= MINIMUM_VALUE Then
            output += "Price must be greater than " & MINIMUM_VALUE & vbCrLf
            TextBoxProperties()
        Else
            validated = True
        End If
        If cmbMake.SelectedIndex = -1 Then
            output += "Select a make." & vbCrLf
            validated = False
        End If
        If txtModel.Text.Trim.Length = 0 Then
            output += "Enter a model." & vbCrLf
            validated = False
        End If
        If cmbYear.SelectedIndex = -1 Then
            output += "Select a year." & vbCrLf
            validated = False
        End If

        If validated = False Then
            lblOutput.Text = "ERROR(S)" & vbCrLf & output
            lblOutput.ForeColor = Color.Red
        End If

        Return validated

    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
            Application.Exit() ' exit program
        End Sub

    Private Sub lvwOutput_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwOutput.SelectedIndexChanged

        Const idSubItemIndex As Integer = 1

        ' Get the customer identification number
        'WORKS IF YOU CLICK OFF THE ITEM BEFORE CLICKING A DIFFERENT ITEM.
        currentID = lvwOutput.Items(lvwOutput.FocusedItem.Index).SubItems(idSubItemIndex).Text

        ' Use the customer identification number to get the customer from the collection object
        Dim car As Car = CType(carList.Item(currentID), Car)

        cmbMake.Text = car.getMake
        cmbYear.Text = CType(car.getYear, String)
        txtModel.Text = car.getModel
        txtPrice.Text = CType(car.getPrice, String)
        chkNew.Checked = car.getStatus
        lblOutput.Text = car.CarString


    End Sub

    Private Sub frmLAB4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMake.SelectedIndex = 1
        cmbYear.SelectedIndex = 1
        txtModel.Text = "11"
        txtPrice.Text = "1111"
    End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim car As Car                  ' declare a Customer class
        Dim carItem As ListViewItem    ' declare a ListViewItem class

        edit = True

        If ValidInput() Then

            If currentID.Trim.Length = 0 Then

                car = New Car(cmbMake.Text, txtModel.Text, CInt(cmbYear.Text), CDbl(txtPrice.Text), chkNew.Checked)
                carList.Add(car.getID.ToString(), car)
            Else

                car = CType(carList.Item(currentID), Car)

                car.getModel = txtModel.Text
                car.getPrice = CInt(txtPrice.Text)
                car.getYear = CInt(cmbYear.Text)
                car.getMake = cmbMake.Text
                car.getStatus = chkNew.Checked
            End If

            lvwOutput.Items.Clear()
            lblOutput.ForeColor = Color.Black

            For Each carAdd As DictionaryEntry In carList

                ' instantiate a new ListViewItem
                carItem = New ListViewItem()

                ' get the customer from the list
                car = CType(carAdd.Value, Car)

                ' assign the values to the ckecked control
                ' and the subitems
                carItem.Checked = car.getStatus
                carItem.SubItems.Add(car.getID.ToString())
                carItem.SubItems.Add(car.getMake)
                carItem.SubItems.Add(car.getModel)
                carItem.SubItems.Add(car.getYear.ToString())
                carItem.SubItems.Add("$" & car.getPrice.ToString())

                ' add the new instantiated and populated ListViewItem
                ' to the listview control
                lvwOutput.Items.Add(carItem)

            Next carAdd

            Reset()
            edit = False
        End If
    End Sub

    Private Sub lvwOutput_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvwOutput.ItemCheck

        If edit = False Then
            e.NewValue = e.CurrentValue
        End If

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTipCar.Popup

    End Sub

    Private Sub lvwOutput_Leave(sender As Object, e As EventArgs) Handles lvwOutput.Leave
        lblOutput.Text = String.Empty
    End Sub
End Class
