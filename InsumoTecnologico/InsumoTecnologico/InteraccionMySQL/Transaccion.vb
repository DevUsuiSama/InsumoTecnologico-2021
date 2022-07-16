'
' #Author: Uggeri Lucas
' #Date: 09/06/2021
'


Imports LosMuzhazhosEstudiosos.DB

Public Class Transaccion
    Private Sub InicializarScriptSQL(ByRef Objeto As MySql2021, NombreDeLaTabla As String)
        With Objeto
            .SelectColumnFrom(tabla:=NombreDeLaTabla, columna:="Nombre")
            .InsertInto(tabla:=NombreDeLaTabla, parametros:="`Nombre`, `Clave`, `Rol`", identificador:="@Nombre, @Clave, @Rol")
            .UpdateFrom(tabla:=NombreDeLaTabla, parametros:="`Nombre` = @Nombre, `Clave` = @Clave, `Rol` = @Rol", "`idUsuario` = @Id")
            .DeleteFrom(tabla:=NombreDeLaTabla, identificador:="`idUsuario` = @Id")
            .SelectConditionFromGroupByOrderByLimit1(
                tabla:=NombreDeLaTabla,
                condicion:="@Nombre = `insumoinformatico`.`usuario`.`Nombre` AND @Clave = `insumoinformatico`.`usuario`.`Clave`, TRUE, FALSE",
                agrupado_por:="idUsuario", ordenado_por:="comparacion")
        End With
    End Sub

    Public Function DefinirMySQL() As MySql2021
        Dim ObjMySQL2021 As New MySql2021 With {    'Creamos Un Objeto Tipo MySQL2020
                   .Server = "localhost",           'Servidor => localhost
                   .Port = "3306",                  'Puerto => 3306
                   .DataBase = "insumoinformatico",'Base De Datos => Nombre
                   .User = "......",                  'Usuario
                   .Password = ".......",      'Constraseña
                   .SelectFrom = "usuario"          'ScripSQL => SELECT * FROM X;
        }
        InicializarScriptSQL(Objeto:=ObjMySQL2021, NombreDeLaTabla:="usuario")
        Return ObjMySQL2021
    End Function
End Class
