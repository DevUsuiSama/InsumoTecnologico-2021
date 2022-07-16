'
' #Author: Uggeri Lucas
' #Date: 09/06/2021
'

Imports System.Web.Mvc
Imports LosMuzhazhosEstudiosos.DB

Namespace Controllers
    Public Class UserController
        Inherits Controller

        Function Salir() As ActionResult
            Session.Clear()
            Return Redirect(Url.Action("Index", "Home"))
        End Function

        ' GET: Login
        <AllowAnonymous>
        Function Login() As ActionResult
            ViewBag.Comprobar = False
            Return View()
        End Function

        <HttpPost>
        <AllowAnonymous>
        Function Login(user As LoginModelView) As ActionResult
            If ModelState.IsValid Then
                Dim obj_transaction = New Transaccion
                Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()

                If obj_mysql_2021.ConectarMySql() Then
                    Debug.WriteLine("Conexion Establecida")
                    Dim obj_usuario As New Usuarios(Of MySql2021)() With {.ParametrosMySQL = obj_mysql_2021}
                    If obj_usuario.Buscar() IsNot Nothing Then
                        Dim verificar As Boolean = False


                        If Not obj_usuario.VerificarSiEstaRegistrado(user.Nombre, user.Clave) Then
                            Debug.WriteLine("Usuario no registrado")
                            ViewBag.Comprobar = True
                        Else
                            Dim Lista As DataTable = obj_usuario.Buscar()
                            Dim Rol = -1
                            For Each Fila As DataRow In Lista.Rows
                                If Fila("Nombre") = user.Nombre Then
                                    Rol = Fila("Rol")
                                End If
                            Next
                            Session("Nombre") = user.Nombre
                            Session("Clave") = user.Clave
                            If Rol = False Then
                                Return Redirect(Url.Action("Logueado", "Home"))
                            ElseIf Rol = True Then
                                Return Redirect(Url.Action("ABM", "Admin"))
                            End If
                        End If
                    End If
                End If
            End If
            Return View(user)
        End Function

        <AllowAnonymous>
        Function SignIn() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        <AllowAnonymous>
        <ValidateAntiForgeryToken()>
        Function SignIn(user As RegistrarModelView) As ActionResult
            If ModelState.IsValid Then
                Dim obj_transaction = New Transaccion
                Dim obj_mysql_2021 = obj_transaction.DefinirMySQL()

                If obj_mysql_2021.ConectarMySql() Then
                    Debug.WriteLine("Conexion Establecida")
                    Dim obj_usuario As New Usuarios(Of MySql2021)() With {
                    .ParametrosMySQL = obj_mysql_2021
                    }

                    If obj_usuario.Buscar() IsNot Nothing Then

                        If obj_usuario.Buscar().Rows.Count = 0 Then 'Base De Datos Vacia

                            obj_usuario._Rol = 1 'Administrador
                            obj_usuario._Nombre = user.Nombre
                            obj_usuario._Clave = user.Clave

                            If obj_usuario.Registrar() Then
                                Debug.WriteLine("Registrado")
                                Session("Nombre") = user.Nombre
                                Session("Clave") = user.Clave
                                Return Redirect(Url.Action("ABM", "Admin"))
                            End If

                        Else

                            obj_usuario._Rol = 0 'Simple Cliente
                            obj_usuario._Nombre = user.Nombre
                            obj_usuario._Clave = user.Clave

                            If obj_usuario.Registrar() Then
                                Debug.WriteLine("Registrado")
                                Session("Nombre") = user.Nombre
                                Session("Clave") = user.Clave
                                Return Redirect(Url.Action("Create", "Home"))
                            End If

                        End If

                    End If

                Else
                    obj_mysql_2021.ConexionMySql.Close()
                End If
            End If
            Return View(user)
        End Function
    End Class
End Namespace