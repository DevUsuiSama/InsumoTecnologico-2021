<!--
    #Author:    Lucas Uggeri
    #Date:      06/06/2021 21:05
-->

<!DOCTYPE html>
<html lang="es-ar">
<head>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>@ViewBag.Title</title>

    @Styles.Render("~/Style/css")
    @Scripts.Render("~/Script/javascript")
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="shortcut icon" href="https://image.flaticon.com/icons/png/512/4100/4100544.png">

</head>
<body>
    <!-- Division Principal => El que se encarga de pintar el fondo de pseudo-negro -->
    <header>
        <nav>

            <ul class="topnav">
                <li>
                    @Html.ActionLink("💻 Insumos Tecnológicos", "Index", "Home", New With {.area = ""}, New With {.class = "active"})
                </li>

                <li>
                    <a href="@Url.Action("Insumo", "Home")"><i class="fa fa-fw fa-search"></i>Insumos</a>
                </li>

                <li>
                    <a href="@Url.Action("Contact", "Home")"><i class="fa fa-fw fa-envelope"></i>Contacto</a>
                </li>

                @Code
                    Html.RenderAction("RenderUser", "Home")
                End Code
            </ul>

        </nav>
    </header>

    @RenderBody()

    <!-- pie de pagina -->
    <footer>
        <div class="div-footer-1">
            <div class="contenedor-texto-1">
                <h1 class="titulo-texto-silenciado">Quienes somos</h1>
                <p class="texto-silenciado">
                    Somos una compañia especializada en el contrabando a gran escala.
                </p>
            </div>
            <div class="contenedor-texto-1">
                <h1 class="titulo-texto-silenciado">Como Contactarnos</h1>
                <p class="texto-silenciado">
                    <strong>Direccion:</strong>&nbsp;Calle Uruguay 1322.<br />
                    <strong>Nro Telefono:</strong>&nbsp;372828282828.
                </p>
            </div>
        </div>
        <div class="div-footer-2">
            <p class="texto-silenciado"><strong>&copy;Insumos 2021</strong> Funciona Gracias a UsuiSama 😎👍</p>
        </div>
    </footer>

</body>
</html>
