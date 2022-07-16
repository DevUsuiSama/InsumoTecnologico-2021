'
' #Author: Uggeri Lucas
' #Date: 09/06/2021
'

Imports LosMuzhazhosEstudiosos.DB
Imports Microsoft.FSharp.Core
Imports MySql.Data.MySqlClient

'--------------------------------------------------------------------------------------------------------------------------------------
' Funciones Lambda

Public Class FunctionBuscar
    Inherits FSharpFunc(Of Tuple(Of DataTable, Boolean), Boolean)

    Private ListaUsuario As DataTable

    Public Overrides Function Invoke(func As Tuple(Of DataTable, Boolean)) As Boolean
        ListaUsuario = func.Item1
        Return True
    End Function

    Public ReadOnly Property GetListaUsuario() As DataTable
        Get
            Return ListaUsuario
        End Get
    End Property
End Class


Public Class FunctionVerificar
    Inherits FSharpFunc(Of MySqlCommand, MySqlCommand)

    Private Nombre As String
    Private Clave As String

    Sub New(Nombre As String, Clave As String)
        Me.Nombre = Nombre
        Me.Clave = Clave
    End Sub

    Public Overrides Function Invoke(func As MySqlCommand) As MySqlCommand
        With func.Parameters
            .AddWithValue("@Nombre", Nombre)
            .AddWithValue("@Clave", Clave)
        End With
        Return func
    End Function
End Class


Public Class FunctionRegistrar
    Inherits FSharpFunc(Of MySqlCommand, MySqlCommand)

    Private Nombre As String
    Private Clave As String
    Private Rol As Integer

    Sub New(Nombre As String, Clave As String, Rol As Integer)
        Me.Nombre = Nombre
        Me.Clave = Clave
        Me.Rol = Rol
    End Sub

    Public Overrides Function Invoke(func As MySqlCommand) As MySqlCommand
        With func.Parameters
            .AddWithValue("@Nombre", Nombre)
            .AddWithValue("@Clave", Clave)
            .AddWithValue("@Rol", Rol)
        End With
        Return func
    End Function
End Class

Public Class FunctionActualizar
    Inherits FSharpFunc(Of MySqlCommand, MySqlCommand)

    Private Id As String
    Private Nombre As String
    Private Clave As String
    Private Rol As Integer

    Sub New(Id As Integer, Nombre As String, Clave As String, Rol As Integer)
        Me.Id = Id
        Me.Nombre = Nombre
        Me.Clave = Clave
        Me.Rol = Rol
    End Sub

    Public Overrides Function Invoke(func As MySqlCommand) As MySqlCommand
        With func.Parameters
            .AddWithValue("@Id", Id)
            .AddWithValue("@Nombre", Nombre)
            .AddWithValue("@Clave", Clave)
            .AddWithValue("@Rol", Rol)
        End With
        Return func
    End Function
End Class

Public Class FunctionEliminar
    Inherits FSharpFunc(Of MySqlCommand, MySqlCommand)

    Private Id As String

    Sub New(Id As Integer)
        Me.Id = Id
    End Sub

    Public Overrides Function Invoke(func As MySqlCommand) As MySqlCommand
        With func.Parameters
            .AddWithValue("@Id", Id)
        End With
        Return func
    End Function
End Class

'--------------------------------------------------------------------------------------------------------------------------------------
' Clase Usuario

Public Class Usuarios(Of T As MySql2021)
    Private Id As String
    Private Nombre As String
    Private Clave As String
    Private Rol As Integer

    Private _ParametrosMySQL As T

    Public Sub New()
        'Constructor Vacio
    End Sub

    Public Sub New(Nombre As String, Clave As String, Rol As Integer)
        Me.Nombre = Nombre
        Me.Clave = Clave
        Me.Rol = Rol
    End Sub

    Public Property _Id As String
        Set(value As String)
            Id = value
        End Set
        Get
            Return Id
        End Get
    End Property

    Public Property _Nombre As String
        Set(value As String)
            Nombre = value
        End Set
        Get
            Return Nombre
        End Get
    End Property

    Public Property _Clave As String
        Set(value As String)
            Clave = value
        End Set
        Get
            Return Clave
        End Get
    End Property

    Public Property _Rol As Integer
        Set(value As Integer)
            Rol = value
        End Set
        Get
            Return Rol
        End Get
    End Property

    Public WriteOnly Property ParametrosMySQL() As T
        Set(value As T)
            _ParametrosMySQL = value
        End Set
    End Property

    Public Function Buscar() As DataTable
        Dim ListaUsuario As DataTable
        Dim func As New FunctionBuscar
        If Not _ParametrosMySQL.GestionarBaseDeDatos(func) Then
            ListaUsuario = Nothing
        Else
            ListaUsuario = func.GetListaUsuario
        End If
        Return ListaUsuario
    End Function

    Public Function Registrar() As Boolean
        _ParametrosMySQL.Operacion = TipoDeOperacion.Insert
        Dim func As New FunctionRegistrar(Nombre, Clave, Rol)
        Return _ParametrosMySQL.GestionarBaseDeDatos(func)
    End Function

    Public Function Actualizar() As Boolean
        _ParametrosMySQL.Operacion = TipoDeOperacion.Update
        Dim func As New FunctionActualizar(Id, Nombre, Clave, Rol)
        Return _ParametrosMySQL.GestionarBaseDeDatos(func)
    End Function

    Public Function Eliminar() As Boolean
        _ParametrosMySQL.Operacion = TipoDeOperacion.Delete
        Dim func As New FunctionEliminar(Id)
        Return _ParametrosMySQL.GestionarBaseDeDatos(func)
    End Function

    Public Function VerificarSiEstaRegistrado(Nombre As String, Clave As String) As Boolean
        _ParametrosMySQL.OperacionAvanzado = TipoDeOperacionAvanzado.SelectConditionReturnSingleValue
        Dim func As New FunctionVerificar(Nombre, Clave)
        Return _ParametrosMySQL.GestionarBaseDeDatosAvanzado(func)
    End Function
End Class



