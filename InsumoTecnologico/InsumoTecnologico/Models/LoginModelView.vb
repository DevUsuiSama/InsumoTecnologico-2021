'
' #Author: Uggeri Lucas
' #Date: 09/06/2021
'

Imports System.ComponentModel.DataAnnotations

Public Class LoginModelView
    <Required>
    <Display(Name:="Nombre De Usuario")>
    <DataType(DataType.Text)>
    Public Property Nombre() As String

    <Required>
    <Display(Name:="Contraseña")>
    <DataType(DataType.Password)>
    Public Property Clave() As String
End Class
