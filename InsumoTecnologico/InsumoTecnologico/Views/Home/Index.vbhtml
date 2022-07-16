@Code
    ViewData("Title") = "Insumos Tecnológicos"
End Code

<!-- Division Central -->

<main role="main">
    <div class="espacio-superior-inferior">
        <div class="div-main-2">
            <div class="div-main-1">
                <div>
                    <h1 class="main-titulo">Insumos lo mejores productos de la frontera</h1>
                </div>
                <form id="formulario">
                    <input class="input-type-text" type="text" id="buscador" />
                    <button class="input-type-submit fa fa-search" type="submit"></button>
                </form>
                <script>
                    var form = document.getElementById("formulario");
                    form.addEventListener("submit", ev => {
                        ev.preventDefault();
                        alert(document.getElementById("buscador").value);
                    });
                </script>
            </div>
            <div class="panel-novedades">
                <h1 class="main-titulo-novedades">Novedades</h1>
                <details>
                    <summary class="main-frase-novedades">Contrabando</summary>
                    <p class="main-frase-novedades">
                        Ultimo Mouse de 9th generacion obtenida de nuestro personal en la mediaciónes de la aduana.
                    </p>
                </details>
                <details>
                    <summary class="main-frase-novedades">Aduana</summary>
                    <p class="main-frase-novedades">
                        Extorsionamos a los aduaneros. Ahora podras obtener tus productos sin costes adicionales.
                    </p>
                </details>
                <h1 class="main-titulo-novedades">Musica Maestro</h1>
                <audio controls class="reproductor-de-musica">
                    <source src="~/Music/Hacknet_Labyrinths_OST_Remi_Gallego_The_Algorithm_-_Payload_AKA_Userspacelike.mp3" type="audio/mp3">
                    Tu navegador no soporta audio HTML5.
                </audio>
            </div>
        </div>
    </div>
</main>


