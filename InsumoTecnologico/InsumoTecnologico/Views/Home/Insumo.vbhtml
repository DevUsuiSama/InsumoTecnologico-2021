@Code
    ViewData("Title") = "😉 Productos Robados"
End Code

@Styles.Render("~/Style/css2")

<div class="div-main-product">
    <div class="espacio-superior-inferior-2">
        <div class="contenedor-catalogo-titulo">
            <h1 class="titulo-insumos">Catalogos de Insumos</h1>
        </div>
        <div class="contenedor-insumos">
            <div class="contenedor-catalogo">
                <h3 class="titulo-catalogo">Mouse</h3>
                <div class="contenedor-imagen-insumo">
                    <img src="https://http2.mlstatic.com/D_NQ_NP_2X_638392-MLA32146296591_092019-F.webp" alt="mouse" />
                    <div class="mostrar-precio">
                        <h3>Precio: $0</h3>
                        <h3>Cantidad: 0u</h3>
                        <button onclick="alert('Compra Realizada')">Comprar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
