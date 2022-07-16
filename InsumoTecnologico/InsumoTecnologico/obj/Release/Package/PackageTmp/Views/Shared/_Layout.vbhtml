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
        <div class="borde-superior texto-silenciado contenedor">
            &nbsp;&nbsp;&nbsp;&nbsp;&copy;LucasUggeri @DateTime.Now.Year - Insumos Tecnológicos -
            <a class="enlace" href="https://www.google.com/intl/es_AR/policies/privacy/archive/20160325/">Privacidad</a>
        </div>
    </footer>

</body>
</html>
