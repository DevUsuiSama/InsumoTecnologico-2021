@ModelType RegistrarModelView
@Code
    Layout = "~/Views/Shared/_SignIn.vbhtml"
End Code


<div>
    <h1 class="crear-cuenta">Crear Cuenta</h1>
    @Using (Html.BeginForm("SignIn", "User", FormMethod.Post))
        @Html.AntiForgeryToken()
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
                @Html.EditorFor(Function(model) model.Clave)
                @Html.ValidationMessageFor(Function(model) model.Clave, "", New With {
                                                .style = "color:#ff0000;font-family:Arial;font-size:17px;text-shadow:1px1px1pxblack;font-weight: bold"
                                                })
            </div>
            <div class="form-group">
                <b>@Html.LabelFor(Function(model) model.ConfirmarClave)</b>
                @Html.EditorFor(Function(model) model.ConfirmarClave)
                @Html.ValidationMessageFor(Function(model) model.ConfirmarClave, "", New With {
                                                .style = "color:#ff0000;font-family:Arial;font-size:17px;text-shadow:1px1px1pxblack;font-weight: bold"
                                                })
            </div>
            <div class="centrar-boton">
                <button type="submit" value="Create">Registrarse</button>
            </div>
        </div>
    End Using
</div>
