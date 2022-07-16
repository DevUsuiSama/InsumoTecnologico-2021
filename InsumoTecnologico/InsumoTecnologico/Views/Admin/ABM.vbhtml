@ModelType UsuarioModelView
@Code
    Layout = "~/Views/Shared/_Admin.vbhtml"
    ViewData("Title") = "Administración"
End Code


<div id="agregar" class="ocultar div-formulario-agregar">
    <form method="post">
        <div class="form-group">
            <input id="nombre" required type="text" placeholder="Nombre" />
        </div>
        <div class="form-group">
            <input id="clave" required type="password" placeholder="Clave" />
        </div>
        <div class="form-group">
            <select id="rol">
                <option value="1">Administrador</option>
                <option value="0">Cliente</option>
            </select>
        </div>
        <div Class="div4">
            <input id="btn-agregar" Class="btn1" type="submit" value="Agregar" />
            <button id="btn-cancelar" Class="btn1" onclick="cerrarFormularioAgregar()">Cancelar</button>
        </div>
    </form>
</div>
<div id="editar" class="ocultar div-formulario-agregar">
    <form method="post">
        <div class="form-group">
            <input id="nombre2" required type="text" placeholder="Nombre" />
        </div>
        <div class="form-group">
            <input id="clave2" required type="password" placeholder="Clave" />
        </div>
        <div class="form-group">
            <select id="rol2">
                <option value="1">Administrador</option>
                <option value="0">Cliente</option>
            </select>
        </div>
        <div Class="div4">
            <input id="btn-editar" Class="btn1" type="submit" value="Aplicar Cambios" />
            <button id="btn-editar-cancelar" Class="btn1" onclick="cerrarFormularioEditar()">Cancelar</button>
        </div>
    </form>
</div>
<div id="panel" Class="ocultar div-panel">
    <div Class="div5">
        <div Class="div-titulo-2">
            <h4> Usuario</h4>
        </div>
        <Table id="tabla-usuario">
            <tbody>
                <tr>
                    @Code
                        For Each Lista As System.Data.DataColumn In Model.tabla.Columns
                            @<th>@Lista.ColumnName</th>
                        Next
                    End Code
                    <th>
                        @Html.CheckBox("Todo", False)
                        @Html.Label("Todo")
                    </th>
                </tr>
                @Code
                    Dim cont = 0
                    For Each Fila As System.Data.DataRow In Model.tabla.Rows
                        @<tr id="@CStr("fila" & cont)">
                            @For Each Columna As System.Data.DataColumn In Model.tabla.Columns
                                @<td>@Fila(Columna.ColumnName)</td>
                            Next
                            <td>
                                <input type="checkbox" id="@CStr("check" & cont)" value="@Fila("idUsuario")" />
                            </td>
                            @Code
                                cont = cont + 1
                            End Code
                        </tr>
                    Next
                End Code
            </tbody>
        </Table>
    </div>
    <div Class="div4">
        <button Class="btn1" onclick="abrirFormularioAgregar()">Agregar</button>
        <button Class="btn1" onclick="abrirFormularioEditar()">Editar</button>
        <button Class="btn1" onclick="eliminar()">Eliminar</button>
        <button Class="btn1" onclick="cerrarABM()">Salir</button>
    </div>
</div>
<div Class="div1">
    <div Class="div-titulo">
        <h1> ABM Administración</h1>
    </div>
    <div Class="div2">
        <button Class="btn1" onclick="abmUsuarios()">Ver Usuarios</button>
        <a href="@Url.Action("Salir", "User")" Class="btn1 btn-text-center">Salir</a>
    </div>
    <div Class="div3">
        <audio controls Class="div3">
            <source src="~/Music/Hacknet_Labyrinths_OST_Remi_Gallego_The_Algorithm_-_Payload_AKA_Userspacelike.mp3" type="audio/mp3">
            Tu navegador no soporta audio HTML5.
        </audio>
    </div>
    <div Class="div-copy">
        &copy;ABM Insumos 2021
    </div>
</div>
<script>
    function abmUsuarios() {
        var panel = document.getElementById("panel");
        if (panel.classList.contains("ocultar")) {
            panel.classList.remove("ocultar");
        }
    }

    function cerrarABM() {
        var panel = document.getElementById("panel");
        if (!panel.classList.contains("ocultar")) {
            panel.classList.add("ocultar");
        }
    }

    function abrirFormularioAgregar() {
        var form = document.getElementById("agregar");
        if (form.classList.contains("ocultar")) {
            form.classList.remove("ocultar");
        }
    }

    function cerrarFormularioAgregar() {
        var form = document.getElementById("agregar");
        if (!form.classList.contains("ocultar")) {
            form.classList.add("ocultar");
        }
    }

    var aux_id = -1;
    var aux_nombre = "";
    var aux_clave = "";
    var aux_rol = "";

    function abrirFormularioEditar() {
        let cont = 0;
        for (let i = 0; i < max_check; i++) {
            let check = document.getElementById("check" + i);
            if (check.checked) {
                let nombre = document.getElementById("nombre2");
                let clave = document.getElementById("clave2");
                let rol = document.getElementById("rol2");
                let fila = document.getElementById("fila" + i);
                nombre.value = fila.cells[1].innerHTML;
                clave.value = fila.cells[2].innerHTML;
                if (fila.cells[3].innerHTML == "True") {
                    rol.value = 1;
                } else if (fila.cells[3].innerHTML == "False") {
                    rol.value = 0;
                }
                aux_id = fila.cells[0].innerHTML;
                aux_nombre = nombre.value;
                aux_clave = clave.value;
                aux_rol = rol.value;
                var form = document.getElementById("editar");
                if (form.classList.contains("ocultar")) {
                    form.classList.remove("ocultar");
                }
            } else {
                cont++;
            }
        }
        if (cont == max_check) {
            alert("Selecione una cuenta a editar");
            verificar = false;
        }
    }

    function cerrarFormularioEditar() {
        var form = document.getElementById("editar");
        if (!form.classList.contains("ocultar")) {
            form.classList.add("ocultar");
        }
    }

    var checkTodo = document.getElementById("Todo");
    checkTodo.addEventListener("click", () => {
        alert("No se puede utilizar esta opción");
        checkTodo.checked = false;
    });

    var max_check = @cont;
    for (let i = 0; i < max_check; i++) {
        let check = document.getElementById("check" + i);
        check.addEventListener("click", () => {
            for (let e = 0; e < max_check; e++) {
                if (e != i) {
                    let check2 = document.getElementById("check" + e);
                    if (check2.checked)
                        check.checked = false;
                }
            }
        });
    }

    var btn_agregar = document.getElementById("btn-agregar");
    btn_agregar.addEventListener("click", ev => {
        ev.preventDefault();
        let nombre = document.getElementById("nombre");
        let clave = document.getElementById("clave");
        let rol = document.getElementById("rol");
        if (nombre.value != "" && clave.value != "") {
            const data = new URLSearchParams("Nombre=" + nombre.value + "&Clave=" + clave.value + "&Rol=" + rol.value);
            fetch("@Url.Action("Agregar", "Admin")", {
                method: "POST",
                body: data
            }).then(res => {
                if (res.ok)
                    return res.text();
                else
                    alert("Error");
            }).then(data => {
                alert(data);
                location.reload();
            });
        } else {
            alert("Complete los campos requeridos");
        }
    });
    var btn_cancelar = document.getElementById("btn-cancelar");
    btn_cancelar.addEventListener("click", ev => {
        ev.preventDefault();
    });

    var btn_editar = document.getElementById("btn-editar");
    btn_editar.addEventListener("click", ev => {
        ev.preventDefault();
        let nombre = document.getElementById("nombre2");
        let clave = document.getElementById("clave2");
        let rol = document.getElementById("rol2");
        if (nombre.value != "" && clave.value != "") {
            if (nombre.value != aux_nombre || clave.value != aux_clave || rol.value != aux_rol) {
                const data = new URLSearchParams("Id=" + aux_id + "&Nombre=" + nombre.value + "&Clave=" + clave.value + "&Rol=" + rol.value);
                fetch("@Url.Action("Actualizar", "Admin")", {
                    method: "POST",
                    body: data
                }).then(res => {
                    if (res.ok)
                        return res.text();
                    else
                        alert("Error");
                }).then(data => {
                    alert(data);
                    location.reload();
                });
            } else {
                alert("No se editaron los datos");
            }
        } else {
            alert("Complete los campos requeridos");
        }
    });
    var btn_editar_cancelar = document.getElementById("btn-editar-cancelar");
    btn_editar_cancelar.addEventListener("click", ev => {
        ev.preventDefault();
    });

    function eliminar() {
        let cont = 0;
        for (let i = 0; i < max_check; i++) {
            let check = document.getElementById("check" + i);
            if (check.checked) {
                if (confirm("¿Eliminar Usuario?")) {
                    const data = new URLSearchParams("Check=" + document.getElementById("check" + i).value);
                    fetch("@Url.Action("Eliminar", "Admin")", {
                        method: "POST",
                        body: data
                    }).then(res => {
                        if (res.ok)
                            return res.text();
                        else
                            alert("Error");
                    }).then(data => {
                        alert(data);
                        if (data == "Cuenta Eliminada") {
                            location.reload();
                            //let fila = document.getElementById("fila" + i);
                            //fila.remove();
                        }
                    });
                }
            } else {
                cont++;
            }
        }
        if (cont == max_check) {
            alert("Selecione una cuenta a eliminar");
            verificar = false;
        }
    }
</script>