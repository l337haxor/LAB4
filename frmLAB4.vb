Option Strict On

Public Class frmLAB4

    'Declarations



    Private carList As New SortedList          ' collection of all the customerList in the list
    Private currentID As String = String.Empty ' current selected customer identification number
    Private editMode As Boolean = False


    Sub TextBoxProperties()

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

    Function ValidInput(ByVal input As String) As Boolean

        Const MINIMUM_VALUE = 0
        Const MAXIMUM_VALUE = 99999
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

        Const idSubItemIndex As Integer = 1

        ' Get the customer identification number 
        currentID = lvwOutput.Items(lvwOutput.FocusedItem.Index).SubItems(idSubItemIndex).Text

        ' Use the customer identification number to get the customer from the collection object
        Dim car As Car = CType(carList.Item(currentID), Car)

        ' set the controls on the form
        cmbMake.Text = car.getMake
        cmbYear.Text = CType(car.getYear, String)
        txtModel.Text = car.getModel
        txtPrice.Text = CType(car.getPrice, String)
        chkNew.Checked = car.getStatus

        lblOutput.Text = car.CarString

    End Sub

        Private Sub frmLAB4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        Dim car As Car                  ' declare a Customer class
        Dim carItem As ListViewItem    ' declare a ListViewItem class

        editMode = True

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
            carItem.SubItems.Add(car.getPrice.ToString())

            ' add the new instantiated and populated ListViewItem
            ' to the listview control
            lvwOutput.Items.Add(carItem)

        Next carAdd

        Reset()
        editMode = False
    End Sub

    Private Sub lvwOutput_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvwOutput.ItemCheck

        If editMode = False Then

            ' the new value to the current value
            ' so it cannot be set in the listview by the user
            e.NewValue = e.CurrentValue

        End If

    End Sub
End Class
