Imports System.Web.Mvc
Imports System.Web.Optimization

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Return View()
        End Function

        Function Contact() As ActionResult
            Return View()
        End Function

        Function Insumo() As ActionResult
            Return View()
        End Function

        Function RenderUser() As ActionResult
            Return PartialView("_UserPartial")
        End Function

        Function Create() As ActionResult
            Return View()
        End Function

        Function Logueado() As ActionResult
            Return View()
        End Function
    End Class
End Namespace