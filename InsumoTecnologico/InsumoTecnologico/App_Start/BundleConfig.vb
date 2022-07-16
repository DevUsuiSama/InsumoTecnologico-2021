Imports System.Web.Optimization

Public Module BundleConfig
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/Script/javascriptAdmin").Include("~/Script/AdminABM.js"))
        bundles.Add(New ScriptBundle("~/Script/javascript").Include("~/Script/mensajes.js", "~/Script/historia.js"))
        bundles.Add(New StyleBundle("~/Style/css").Include("~/Style/navegador.css", "~/Style/pie_de_pagina.css", "~/Style/contenido_principal.css"))
        bundles.Add(New StyleBundle("~/Style/css2").Include("~/Style/formulario.css"))
        bundles.Add(New StyleBundle("~/Style/cssAdmin").Include("~/Style/Admin/abm.css"))
    End Sub
End Module