Option Strict On

Public Class Car


    Private Shared carCount As Integer = 0
    Private carIDNumber As Integer = 0
    Private carMake As String = String.Empty
    Private carModel As String = String.Empty
    Private carYear As Integer = 1900
    Private carPrice As Double = 10000
    Private carNewStatus As Boolean = False

    'Default Constructor
    Public Sub New()

        carCount += 1      ' increment the shared/static variable counter by 1
        carIDNumber = carCount ' assign the customers id

    End Sub
    'Parameterized Constructor
    Public Sub New(make As String, model As String, year As Integer, price As Double, newStatus As Boolean)

        Me.New()

        carMake = make
        carModel = model
        carYear = year
        carPrice = price
        carNewStatus = newStatus

    End Sub

    Public ReadOnly Property getCount() As Integer
        Get
            Return carCount
        End Get
    End Property
    Public ReadOnly Property getID() As Integer
        Get
            Return carIDNumber
        End Get
    End Property
    Public Property getMake() As String
        Get
            Return carMake
        End Get
        Set(ByVal value As String)
            carMake = value
        End Set
    End Property
    Public Property getModel() As String
        Get
            Return carModel
        End Get
        Set(ByVal value As String)
            carModel = value
        End Set
    End Property
    Public Property getYear() As Integer
        Get
            Return carYear
        End Get
        Set(ByVal value As Integer)
            carYear = value
        End Set
    End Property
    Public Property getPrice() As Double
        Get
            Return carPrice
        End Get
        Set(ByVal value As Double)
            carPrice = value
        End Set
    End Property
    Public Property getStatus() As Boolean
        Get
            Return carNewStatus
        End Get
        Set(ByVal value As Boolean)
            carNewStatus = value
        End Set
    End Property
    Public Function CarString() As String

        Return "Car Details: " & carMake & ", " & carModel & ", " & carYear.ToString & ", " & carPrice.ToString & ". " & IIf(carNewStatus = True, "New", "Used").ToString()

    End Function

End Class
