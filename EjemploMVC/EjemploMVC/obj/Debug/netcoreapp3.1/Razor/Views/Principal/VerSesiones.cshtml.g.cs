#pragma checksum "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5ee696a66175d10072d4e8c3f35f828862a8134"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Principal_VerSesiones), @"mvc.1.0.view", @"/Views/Principal/VerSesiones.cshtml")]
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
#line 1 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\_ViewImports.cshtml"
using EjemploMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\_ViewImports.cshtml"
using EjemploMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5ee696a66175d10072d4e8c3f35f828862a8134", @"/Views/Principal/VerSesiones.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a95f43b4bd5f52233104f97e714d3c5fed198f09", @"/Views/_ViewImports.cshtml")]
    public class Views_Principal_VerSesiones : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SesionesModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
  
    ViewData["Title"] = "VerSesiones";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Lista de sesiones</h1>\r\n\r\n");
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <th>Nombre</th>\r\n        <th>Fecha reserva</th>\r\n        <th>Horario</th>\r\n        <th>Cupos disponibles</th>\r\n    </tr>\r\n");
#nullable restore
#line 16 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
     foreach (SesionesModel temp in ViewBag.Sesiones)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
           Write(temp.gimnasioReserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 20 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
           Write(temp.fechaReserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 21 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
           Write(temp.horario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
           Write(temp.cupos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n            <param");
            BeginWriteAttribute("id", " id=\"", 533, "\"", 553, 1);
#nullable restore
#line 25 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
WriteAttributeValue("", 538, temp.codSesion, 538, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 554, "\"", 576, 1);
#nullable restore
#line 25 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
WriteAttributeValue("", 561, temp.codSesion, 561, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 577, "\"", 600, 1);
#nullable restore
#line 25 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
WriteAttributeValue("", 585, temp.codSesion, 585, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <td>\r\n                <div class=\"container-contact100-form-btn rs1-wrap-input100\">\r\n                    <input class=\"contact100-form-btn \" type=\"button\" href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 790, "\"", 864, 6);
            WriteAttributeValue("", 800, "realizarReservacion(", 800, 20, true);
            WriteAttributeValue(" ", 820, "$(\'#", 821, 5, true);
#nullable restore
#line 28 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"
WriteAttributeValue("", 825, temp.codSesion, 825, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 840, "\').val());", 840, 10, true);
            WriteAttributeValue(" ", 850, "return", 851, 7, true);
            WriteAttributeValue(" ", 857, "false;", 858, 7, true);
            EndWriteAttribute();
            WriteLiteral(" id=\"reservarSesion\" name=\"reservarSesion\" value=\"Reservar\" />\r\n\r\n\r\n                </div>\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\XPC\Downloads\Proyecto tres\EjemploMVC\EjemploMVC\Views\Principal\VerSesiones.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <span id=\"resultadoReservarSesion\"></span>\r\n\r\n\r\n\r\n\r\n\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SesionesModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
