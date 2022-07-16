
@Code
    Dim obj_transaction = New Transaccion
    Dim obj_usuario = New Usuarios(Of LosMuzhazhosEstudiosos.DB.MySql2021)() With {
        .ParametrosMySQL = obj_transaction.DefinirMySQL()
    }
End Code

@If obj_usuario.VerificarSiEstaRegistrado(Session("Nombre"), Session("Clave")) Then 'Control De Usuario
    @<li class="right">
        <a href="@Url.Action("Salir", "User")" onclick="MensajeCerrarSesion()"><i class="fa fa-fw fa-close"></i>Cerrar Sesión</a>
    </li>
Else
    @<li Class="right">
        <a href="@Url.Action("SignIn", "User")"><i Class="fa fa-fw fa-sign-in"></i>Registrarse</a>
    </li>

    @<li Class="right">
        <a href="@Url.Action("Login", "User")"><i Class="fa fa-fw fa-user"></i>Iniciar Sesión</a>
    </li>
End If



