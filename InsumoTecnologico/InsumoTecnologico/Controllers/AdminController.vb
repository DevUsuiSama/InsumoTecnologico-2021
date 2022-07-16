Imports System.Web.Mvc
Imports LosMuzhazhosEstudiosos.DB

Namespace Controllers
    Public Class AdminController
        Inherits Controller

        Function Salir() As ActionResult
            Session.Clear()
            Return Redirect(Url.Action("Index", "Home"))
        End Function

        Function ABM(usuario As UsuarioModelView) As ActionResult
            Dim obj_transaction = New Transaccion
            Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()
            If obj_mysql_2021.ConectarMySql() Then
                Dim obj_usuario As New Usuarios(Of MySql2021)() With {.ParametrosMySQL = obj_mysql_2021}
                If obj_usuario.Buscar() IsNot Nothing Then
                    usuario.tabla = obj_usuario.Buscar()
                    Return View(usuario)
                Else
                    Session.Clear()
                    Return Redirect(Url.Action("Index", "Home"))
                End If
            Else
                Session.Clear()
                Return Redirect(Url.Action("Index", "Home"))
            End If
        End Function

        <HttpPost()>
        Function Agregar(Nombre As String, Clave As String, Rol As String) As ActionResult
            Dim obj_transaction = New Transaccion
            Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()

            If obj_mysql_2021.ConectarMySql() Then
                Debug.WriteLine("Conexion Establecida")
                Dim obj_usuario As New Usuarios(Of MySql2021)() With {
                .ParametrosMySQL = obj_mysql_2021
                }

                If obj_usuario.Buscar() IsNot Nothing Then
                    If Rol = "1" Then
                        obj_usuario._Rol = 1 'Administrador
                    ElseIf Rol = "0" Then
                        obj_usuario._Rol = 0 'Simple Cliente
                    End If
                    obj_usuario._Nombre = Nombre
                    obj_usuario._Clave = Clave

                    If obj_usuario.Registrar() Then
                        Return Content("Nueva Cuenta Registrada")
                    Else
                        Return Content("Falla monumental al Registrada la Cuenta")
                    End If
                Else
                    Return Content("No hay tabla de datos")
                End If
            Else
                Return Content("No hay conexion")
            End If
        End Function

        Function Actualizar(Id As String, Nombre As String, Clave As String, Rol As String) As ActionResult
            Dim obj_transaction = New Transaccion
            Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()

            If obj_mysql_2021.ConectarMySql() Then
                Debug.WriteLine("Conexion Establecida")
                Dim obj_usuario As New Usuarios(Of MySql2021)() With {
                .ParametrosMySQL = obj_mysql_2021
                }

                If obj_usuario.Buscar() IsNot Nothing Then
                    obj_usuario._Id = Integer.Parse(Id)
                    If Rol = "1" Then
                        obj_usuario._Rol = 1 'Administrador
                    ElseIf Rol = "0" Then
                        obj_usuario._Rol = 0 'Simple Cliente
                    End If
                    obj_usuario._Nombre = Nombre
                    obj_usuario._Clave = Clave

                    If obj_usuario.Actualizar() Then
                        Return Content("Cuenta Actualizada")
                    Else
                        Return Content("Falla monumental al intentar actualizar los datos de la cuenta")
                    End If
                Else
                    Return Content("No hay tabla de datos")
                End If
            Else
                Return Content("No hay conexion")
            End If
        End Function

        <HttpPost()>
        Function Eliminar(check As String) As ActionResult
            Dim obj_transaction = New Transaccion
            Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()
            If obj_mysql_2021.ConectarMySql() Then
                Dim obj_usuario As New Usuarios(Of MySql2021)() With {.ParametrosMySQL = obj_mysql_2021}
                If obj_usuario.Buscar() IsNot Nothing Then
                    obj_usuario._Id = check
                    If obj_usuario.Eliminar() Then
                        Return Content("Cuenta Eliminada")
                    Else
                        Return Content("Falla monumental al intentar eliminar la cuenta")
                    End If
                Else
                    Return Content("No hay tabla de datos")
                End If
            Else
                Return Content("No hay conexion")
            End If
        End Function
    End Class
End Namespace