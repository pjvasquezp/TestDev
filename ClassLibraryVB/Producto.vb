Public Class Producto
    Private Id As String
    Private Nombre As String
    Private Marca As String
    Public Property _Marca() As String
        Get
            Return Marca
        End Get
        Set(ByVal value As String)
            Marca = value
        End Set
    End Property

    Public Property _Nombre() As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property _Id() As String
        Get
            Return Id
        End Get
        Set(ByVal value As String)
            Id = value
        End Set
    End Property


End Class
