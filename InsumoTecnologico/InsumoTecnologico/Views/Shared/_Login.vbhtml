<!--
    #Author:    Lucas Uggeri
    #Date:      06/06/2021 21:05
-->
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Iniciar Sesión</title>
    <link rel="shortcut icon" href="https://image.flaticon.com/icons/png/512/4100/4100544.png">
    @Styles.Render("~/Style/css")
    @Styles.Render("~/Style/css2")
    @Scripts.Render("~/Script/javascript")
</head>
<body>

    <!-- Division Principal => El que se encarga de pintar el fondo de pseudo-negro -->
    <header>
        <nav>

            <ul class="topnav">

                <li>
                    @Html.ActionLink("💻 Insumos Tecnológicos", "Index", "Home", New With {.area = ""}, New With {.class = "active"})
                </li>

                <li class="right">
                    <a class="inactive">😎&nbsp;Ingresa a tu cuenta y aprovecha las ofertas que hay. 😄</a>
                </li>

            </ul>

        </nav>
    </header>

    <!-- Division Central -->

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
