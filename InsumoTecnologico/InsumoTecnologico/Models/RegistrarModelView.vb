'
' #Author: Uggeri Lucas
' #Date: 09/06/2021
'

Imports System.ComponentModel.DataAnnotations

Public Class RegistrarModelView
    <Required>
    <Display(Name:="Nombre De Usuario")>
    <DataType(DataType.Text)>
    Public Property Nombre() As String

    <Required>
    <Display(Name:="Contraseña")>
    <DataType(DataType.Password)>
    Public Property Clave() As String

    <Required>
    <Display(Name:="Confirmar Contraseña")>
    <DataType(DataType.Password)>
    <Compare("Clave", ErrorMessage:="Las contraseña no son iguales, viejo. No podes ser tan tonto.")>
    Public Property ConfirmarClave() As String
End Class
