@ModelType LoginModelView
@Code
    Layout = "~/Views/Shared/_Login.vbhtml"
    Dim script As New JavaScriptResult
End Code

<div>
    @Using (Html.BeginForm("Login", "User", FormMethod.Post))

        @<div class="contenedor_de_imagen">
            <img src="~/Picture/img_avatar3.png" alt="Avatar" Class="avatar" />
        </div>

        @<div Class="contenedor-input">
            <div class="form-group">
                <b>@Html.LabelFor(Function(model) model.Nombre)</b>
                @Html.EditorFor(Function(model) model.Nombre)
                @Html.ValidationMessageFor(Function(model) model.Nombre, "", New With {
                                                .style = "color:#ff0000;font-family:Arial;font-size:17px;text-shadow:1px1px1pxblack;font-weight:bold"
                                                })
            </div>
            <div class="form-group">
                <b>@Html.LabelFor(Function(model) model.Clave)</b>
                @Html.EditorFor(Function(model) model.Clave, New With {.class = "text-danger form-control-lg"})
                @Html.ValidationMessageFor(Function(model) model.Clave, "", New With {
                                                .style = "color:#ff0000;font-family:Arial;font-size:17px;text-shadow:1px1px1pxblack;font-weight: bold"
                                                })
            </div>
            <div class="centrar-boton">
                <Button type="submit" value="Login">Iniciar Sesión</Button>
            </div>
            <Label>
                <input type="checkbox" checked="checked" name="recordar"> Recordar Nombre y Contraseña
            </Label>
        </div>

    End Using

    @If ViewBag.Comprobar Then
        @<script type="text/javascript">MensajeErrorIniciarSesion()</script>
        @<h2 style="color: #ff0000; font-family: Arial; font-size: 17px; text-shadow: 1px 1px 1px black; font-weight: bold; text-align: center ">
            ❌ No estas registrado, capo. ❌
        </h2>
        @Code
            ViewBag.Comprobar = False
        End Code
            End If
</div>

