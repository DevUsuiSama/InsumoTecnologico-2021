@Code
    ViewData("Title") = "😉 Contacto"
End Code

<!-- Contacto -->
<div>
    <h1 class="crear-cuenta">😉 Contactanos 😜</h1>
    <form action="" method="post">

        <div class="centrar-elementos-paralelos">
            <div class="separar-elementos contenedor_de_imagen_parte_dos">
                <img src="~/Picture/Lucastro.jpg" alt="Avatar" class="avatar" />
            </div>
            <div class="padre separar-elementos">
                <h3 class="hijo nuevo-sub-titulo-para-contacto">
                    Mi Nombre, Lucas Uggeri.
                    <br />
                    Edad 28 años, de pura calidad.
                    <br />
                    Mi Pasatiempo? Ver tu mirada, nena. 😉
                    <br />
                    Nro Telefono: [#0x0]. Siempre Disponible. 😎
                </h3>
            </div>
        </div>

        <div class="contenedor-input">
            <label for="nombre"><b>Nombre</b></label>
            <input type="text" placeholder="Ingrese su Nombre" name="nombre" required>

            <label for="correo"><b>Correo Electronico</b></label>
            <input type="text" placeholder="Ingrese su Correo Electronico" name="correo" required>

            <label for="localidad">Localidad</label>
            <select id="localidad" name="localidad">
                <option value="posadas">Posadas</option>
                <option value="garupa">Garupa</option>
                <option value="fatima">Fatima</option>
                <option value="candelaria">Candelaria</option>
            </select>

            <label for="mensaje">Mensaje</label>
            <textarea id="mensaje" name="mensaje" placeholder="Redactar Queja..." style="height:200px"></textarea>

            <input type="submit" value="Enviar Mensaje">
        </div>
    </form>
</div>

