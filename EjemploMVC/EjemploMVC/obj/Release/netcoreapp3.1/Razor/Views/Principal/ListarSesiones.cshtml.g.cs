#pragma checksum "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f25c8796e69eeb28bc0dd1d750ca9cb0dcf6f249"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Principal_ListarSesiones), @"mvc.1.0.view", @"/Views/Principal/ListarSesiones.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\_ViewImports.cshtml"
using EjemploMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\_ViewImports.cshtml"
using EjemploMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f25c8796e69eeb28bc0dd1d750ca9cb0dcf6f249", @"/Views/Principal/ListarSesiones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a95f43b4bd5f52233104f97e714d3c5fed198f09", @"/Views/_ViewImports.cshtml")]
    public class Views_Principal_ListarSesiones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListarSesionesModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"
  
    ViewData["Title"] = "ListarSesiones";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Lista de sesiones</h1>\r\n");
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <th>Nombre gimnasio</th>\r\n        <th>Fecha reserva</th>\r\n        <th>Horario</th>\r\n    </tr>\r\n");
#nullable restore
#line 13 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"
     foreach (ListarSesionesModel temp in ViewBag.ListarSesionesCliente)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 16 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"
           Write(temp.gimnasioReserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"
           Write(temp.fechaReserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"
           Write(temp.horario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 22 "D:\Universidad\Lenguajes\Proyecto3Negocio\EjemploMVC\EjemploMVC\Views\Principal\ListarSesiones.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n</table>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListarSesionesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
