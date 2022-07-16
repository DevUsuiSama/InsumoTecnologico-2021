<!--
    #Author:    Lucas Uggeri
    #Date:      06/06/2021 21:05
-->
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Registrarse</title>

    @Styles.Render("~/Style/css")
</head>
<body>

    <header>
        <nav>

            <ul class="topnav">

                <li>
                    @Html.ActionLink("💻 Insumos Tecnológicos", "Index", "Home", New With {.area = ""}, New With {.class = "active"})
                </li>

                <li class="right">
                    <a class="inactive">😎&nbsp;Cree una cuenta y aproveche las ofertas de hoy. 😄</a>
                </li>

            </ul>

        </nav>
    </header>

    @RenderBody()

    <footer class="borde-superior texto-silenciado">
        <div class="contenedor">
            &nbsp;&nbsp;&nbsp;&nbsp;&copy;LucasUggeri @DateTime.Now.Year - Insumos Tecnológicos -
            <a class="enlace" href="https://www.google.com/intl/es_AR/policies/privacy/archive/20160325/">Privacidad</a>
        </div>
    </footer>

</body>
</html>
