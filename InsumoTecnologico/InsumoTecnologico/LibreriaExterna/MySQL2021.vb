'
' Libreria Desarrollado Por UsuiSama.
'
' Historial:
'
' Desarrollado el jueves, 19 de noviembre de 2020 a las 18:58:09
' Actualizado el sabado, 2 de enero de 2021 a las 15:29:25
' Actualizado el miercoles, 9 de junio de 2021 a las 19:03:25
' Actualizado el domingo, 13 de junio de 2021 a las 00:40:53
'
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class MySQL2021
    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ' Atributos

    Private _Server As String
    Private _Port As String
    Private _DataBase As String
    Private _User As String
    Private _Password As String
    Private _ConexionMySQL As MySqlConnection

    'Script SQL
    Private _SelectFrom As String
    Private _SelectColumnFrom As String
    Private _InsertInto As String
    Private _UpdateFrom As String
    Private _DeleteFrom As String

    'Script SQL Avanzado
    Private _SelectCondition2FromGroupByOrderBy

    'Tipo de Operacion

    Private _Operacion As TipoDeOperacion = -1
    Private _OperacionAvanzado As TipoDeOperacionAvanzado = -1

    '
    ' Constructor
    '

    Public Sub New()
        'Constructor Vacio
    End Sub

    '
    ' Estructura
    '

    Enum TipoDeOperacion As Integer
        Insert '=0
        Update '=1
        Delete '=2
    End Enum

    Enum TipoDeOperacionAvanzado As Integer
        SelectReturnSingleValue '=0
    End Enum

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    ' Metodos y Propiedades

    ''' <summary>
    ''' Script Select que tenga como consulta varias columna; <c>Ejemplo: SELECT * FROM Alumnos</c>
    ''' </summary>
    Public WriteOnly Property SelectFrom() As String
        Set(value As String)
            _SelectFrom = "SELECT * FROM `" & _DataBase & "`.`" & value & "`;"
        End Set
    End Property

    ''' <summary>
    ''' Script Select que tenga como consulta una sola columna; <c>Ejemplo: SELECT DNI FROM Alumnos</c>
    ''' </summary>
    Public WriteOnly Property SelectColumnFrom(NombreDeLaColumna As String) As String
        Set(NombreDeLaTabla As String)
            _SelectColumnFrom = "SELECT `" & _DataBase & "`.`" & NombreDeLaTabla & "`.`" & NombreDeLaColumna & "` FROM `" & _DataBase & "`.`" & NombreDeLaTabla & "`;"
        End Set
    End Property

    Public WriteOnly Property InsertInto(Parametros As String, Valores As String) As String
        Set(NombreDeLaTabla As String)
            _InsertInto = "INSERT INTO `" & _DataBase & "`.`" & NombreDeLaTabla & "`(" & Parametros & ") VALUES (" & Valores & ");"
        End Set
    End Property

    Public WriteOnly Property UpdateFrom(Parametros As String, Identificador As String) As String
        Set(NombreDeLaTabla As String)
            _UpdateFrom = "UPDATE `" & _DataBase & "`.`" & NombreDeLaTabla & "` SET " & Parametros & " WHERE " & Identificador & ";"
        End Set
    End Property

    Public WriteOnly Property DeleteFrom(Identificador As String) As String
        Set(NombreDeLaTabla As String)
            _DeleteFrom = "DELETE FROM `" & _DataBase & "`.`" & NombreDeLaTabla & "` WHERE " & Identificador & ";"
        End Set
    End Property


    ''' <summary>
    ''' Script SQL Avanzado => Busca, Compara y Devuelve un valor Booleano
    ''' </summary>
    ''' <remarks>
    ''' Recuerde los arrays, solo puede tener como maximo dos elementos. Ej. [ 0, 1 ]
    ''' </remarks>
    ''' <param name="PrimerValor"></param>
    Public WriteOnly Property SelectCondition2FromGroupByOrderBy(PrimerValor() As String, SegundoValor() As String, Ordenado As String) As String
        Set(NombreDeLaTabla As String)
            _SelectCondition2FromGroupByOrderBy = "SELECT IF(" & PrimerValor(0) & " = `" & _DataBase & "`.`" & NombreDeLaTabla & "`.`" & SegundoValor(0) & "` " _
                & "AND " & PrimerValor(1) & " = `" & _DataBase & "`.`" & NombreDeLaTabla & "`.`" & SegundoValor(1) & "`, TRUE, FALSE) AS comparacion " _
                & "FROM `" & _DataBase & "`.`" & NombreDeLaTabla & "` GROUP BY " _
                & "`" & _DataBase & "`.`" & NombreDeLaTabla & "`.`" & Ordenado & "` ORDER BY comparacion DESC LIMIT 1;"
        End Set
    End Property

    Public ReadOnly Property ConexionMySQL() As MySqlConnection
        Get
            Return _ConexionMySQL
        End Get
    End Property

    Public WriteOnly Property Server() As String
        Set(value As String)
            _Server = value
        End Set
    End Property

    Public WriteOnly Property Port() As String
        Set(value As String)
            _Port = value
        End Set
    End Property

    Public WriteOnly Property DataBase() As String
        Set(value As String)
            _DataBase = value
        End Set
    End Property

    Public WriteOnly Property User() As String
        Set(value As String)
            _User = value
        End Set
    End Property

    Public WriteOnly Property Password() As String
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public WriteOnly Property Operacion() As TipoDeOperacion
        Set(value As TipoDeOperacion)
            _Operacion = value
        End Set
    End Property

    Public WriteOnly Property OperacionAvanzado() As TipoDeOperacionAvanzado
        Set(value As TipoDeOperacionAvanzado)
            _OperacionAvanzado = value
        End Set
    End Property

    Public Function ConectarMySQL() As Boolean
        Dim EstadoDeLaConexion As Boolean = True
        Try
            _ConexionMySQL = New MySqlConnection
            If _ConexionMySQL.State = ConnectionState.Closed Then
                With _ConexionMySQL
                    .ConnectionString = "Server=" + _Server + ";" _
                        & "Port=" + _Port + ";" _
                        & "Database=" + _DataBase + ";" _
                        & "User=" + _User + ";" _
                        & "Password=" + _Password
                End With
                _ConexionMySQL.Open()
            End If
        Catch ex As Exception
            EstadoDeLaConexion = False
        End Try
        Return EstadoDeLaConexion
    End Function

    Public Function GestionarBaseDeDatos(Proceso As Func(Of DataTable, Boolean, Boolean)) As Boolean
        Dim ComandoSQL As MySqlCommand
        Dim AdaptadorDeDatos As New MySqlDataAdapter()
        Dim TablaDeDatos As New DataTable()
        Dim EstadoDeLaConsulta As Boolean = False

        If ConectarMySQL() Then
            Try
                ComandoSQL = _ConexionMySQL.CreateCommand()
                ComandoSQL.CommandText = _SelectFrom
                ComandoSQL.CommandType = CommandType.Text
                AdaptadorDeDatos.SelectCommand = ComandoSQL
                Try
                    AdaptadorDeDatos.Fill(TablaDeDatos)
                    EstadoDeLaConsulta = Proceso(TablaDeDatos, EstadoDeLaConsulta)
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        _ConexionMySQL.Close()
        Return EstadoDeLaConsulta
    End Function

    Public Function GestionarBaseDeDatos(Proceso As Func(Of MySqlDataReader, Boolean, Boolean)) As Boolean
        Dim ComandoSQL As MySqlCommand
        Dim LeerDatos As MySqlDataReader
        Dim EstadoDeLaConsulta As Boolean = False

        If ConectarMySQL() Then
            Try
                ComandoSQL = _ConexionMySQL.CreateCommand()
                ComandoSQL.CommandText = _SelectColumnFrom
                ComandoSQL.CommandType = CommandType.Text
                LeerDatos = ComandoSQL.ExecuteReader()
                EstadoDeLaConsulta = Proceso(LeerDatos, EstadoDeLaConsulta)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        _ConexionMySQL.Close()
        Return EstadoDeLaConsulta
    End Function

    Public Function GestionarBaseDeDatos(TipoDeOperacion As TipoDeOperacion, Proceso As Func(Of MySqlCommand, MySqlCommand)) As Boolean
        Dim ComandoSQL As MySqlCommand
        Dim EstadoDeLaGestion As Boolean = False

        If ConectarMySQL() Then
            Try
                ComandoSQL = _ConexionMySQL.CreateCommand()
                Select Case TipoDeOperacion
                    Case TipoDeOperacion.Insert
                        ComandoSQL.CommandText = _InsertInto
                    Case TipoDeOperacion.Update
                        ComandoSQL.CommandText = _UpdateFrom
                    Case TipoDeOperacion.Delete
                        ComandoSQL.CommandText = _DeleteFrom
                    Case Else
                        Throw New Exception("Metodo obj.GestionarBaseDeDatos(" & TipoDeOperacion & ", ...), Valor Agregado = " & TipoDeOperacion & " no existe!!" & ChrW(13) & ChrW(10) &
                                "Los Valores existente son:" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Insert" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Update" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Delete")
                End Select
                ComandoSQL = Proceso(ComandoSQL)
                ComandoSQL.CommandType = CommandType.Text
                ComandoSQL.ExecuteNonQuery()
                EstadoDeLaGestion = True
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        ConexionMySQL.Close() 'Ley de vida
        Return EstadoDeLaGestion
    End Function

    Public Function GestionarBaseDeDatos(Proceso As Func(Of MySqlCommand, MySqlCommand)) As Boolean
        Dim ComandoSQL As MySqlCommand
        Dim EstadoDeLaGestion As Boolean = False

        If ConectarMySQL() Then
            Try
                ComandoSQL = _ConexionMySQL.CreateCommand()
                Select Case _Operacion
                    Case TipoDeOperacion.Insert
                        ComandoSQL.CommandText = _InsertInto
                    Case TipoDeOperacion.Update
                        ComandoSQL.CommandText = _UpdateFrom
                    Case TipoDeOperacion.Delete
                        ComandoSQL.CommandText = _DeleteFrom
                    Case Else
                        Throw New Exception("Metodo obj.GestionarBaseDeDatos(" & _Operacion & ", ...), Valor Agregado = " & _Operacion & " no existe!!" & ChrW(13) & ChrW(10) &
                                "Los Valores existente son:" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Insert" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Update" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacion.Delete")
                End Select
                ComandoSQL = Proceso(ComandoSQL)
                ComandoSQL.CommandType = CommandType.Text
                ComandoSQL.ExecuteNonQuery()
                EstadoDeLaGestion = True
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        ConexionMySQL.Close() 'Ley de vida
        Return EstadoDeLaGestion
    End Function

    Public Function GestionarBaseDeDatosAvanzado(Proceso As Func(Of MySqlCommand, MySqlCommand)) As Boolean
        Dim ComandoSQL As MySqlCommand
        Dim LeerDatos As MySqlDataReader
        Dim EstadoDeLaGestion As Boolean = False

        If ConectarMySQL() Then
            Try
                ComandoSQL = _ConexionMySQL.CreateCommand()
                Select Case _OperacionAvanzado
                    Case TipoDeOperacionAvanzado.SelectReturnSingleValue
                        ComandoSQL.CommandText = _SelectCondition2FromGroupByOrderBy
                    Case Else
                        Throw New Exception("Metodo obj.GestionarBaseDeDatos(" & _OperacionAvanzado & ", ...), Valor Agregado = " & _OperacionAvanzado & " no existe!!" & ChrW(13) & ChrW(10) &
                                "Los Valores existente son:" & ChrW(13) & ChrW(10) &
                                ChrW(9) & "> TipoDeOperacionAvanzado.SelectCondition2")
                End Select
                ComandoSQL = Proceso(ComandoSQL)
                ComandoSQL.CommandType = CommandType.Text
                LeerDatos = ComandoSQL.ExecuteReader()
                'Como la consulta devuelve unicamente una fila. No hay necesidad de poner un while o un foreach.
                If LeerDatos.Read() Then EstadoDeLaGestion = LeerDatos.GetBoolean(0)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
        ConexionMySQL.Close()
        Return EstadoDeLaGestion
    End Function

    '+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
End Class



