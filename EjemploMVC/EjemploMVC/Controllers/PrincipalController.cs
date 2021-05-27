using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EjemploMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;


using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EjemploMVC.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public IConfiguration Configuration { get; }

        public PrincipalController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;

        } // constructor

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NegocioIndex()
        {
            return View();
        }


        public IActionResult ClienteIndex()
        {

            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/getNegocios/");

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            List<GimnasioModel> negocios = new List<GimnasioModel>();

            try
            {
                negocios = new List<GimnasioModel>();

                //var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                negocios = JsonConvert.DeserializeObject<List<GimnasioModel>>(responseString);
                //return respuesta;

            }
            catch
            {

                negocios = new List<GimnasioModel>();
                ProductoModel negocio = new ProductoModel();
                // var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                negocios.Add(JsonConvert.DeserializeObject<GimnasioModel>(responseString));
                //return respuesta;
            }

            ViewBag.Negocios = negocios;

            return View();

        }


        public IActionResult RegistrarNegocio()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RegistrarNegocio(PrincipalModel principalModel)
        {


            Directory.CreateDirectory("wwwroot/assets/img/" + principalModel.Nombre);

            string logo = "logo.jpg";
            string img1 = "imagen1.jpg";
            string img2 = "imagen2.jpg";
            string img3 = "imagen3.jpg";
            string img4 = "imagen4.jpg";
            string img5 = "imagen5.jpg";
           

            if (principalModel.Logo != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, logo);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Logo.CopyTo(f);
                f.Close();
            }

            if (principalModel.Imagen1 != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, img1);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Imagen1.CopyTo(f);
                f.Close();
            }

            if (principalModel.Imagen2 != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, img2);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Imagen2.CopyTo(f);
                f.Close();
            }

            if (principalModel.Imagen3 != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, img3);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Imagen3.CopyTo(f);
                f.Close();
            }

            if (principalModel.Imagen4 != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, img4);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Imagen4.CopyTo(f);
                f.Close();
            }


            if (principalModel.Imagen5 != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "assets/img/" + principalModel.Nombre);
                var filePath = Path.Combine(uploads, img5);
                FileStream f = new FileStream(filePath, FileMode.Create);
                principalModel.Imagen5.CopyTo(f);
                f.Close();
            };

        
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/registrar/" + principalModel.Nombre + "&" + principalModel.Contrasena + "&" + principalModel.Descripcion + "&" + principalModel.Ubicacion + "&" + principalModel.Telefono + "&" + principalModel.Correo + "&" + principalModel.HorarioA + "&" + principalModel.HorarioC + "&" + principalModel.Capacidad + "&" + principalModel.Porcentaje);


            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
                   
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return View ("Login");


        } // Registrar
        public IActionResult GestionarEstablecimiento()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GestionarEstablecimiento(PrincipalModel principalModel)
        {

            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/actualizar/" + principalModel.Nombre + "&"+ principalModel.Descripcion + "&" + principalModel.HorarioA + "&" + principalModel.HorarioC + "&" + principalModel.Capacidad + "&" + principalModel.Porcentaje);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return new JsonResult("Datos actualizados");


        } // Registrar

        public IActionResult Login()
        {
            return View();
        }





        [HttpPost]
        public IActionResult Login(PrincipalModel principalModel)
        {

           /// Directory.CreateDirectory("resumen/uno"+".pdf");

            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/login/"+principalModel.Nombre+"&"+principalModel.Contrasena);            


            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            if (responseString == "[]")
            {
                return new JsonResult("NoEncontrado");
            }
            else {
                return new JsonResult("Encontrado");
            }


        } // Login



        [HttpPost]
        public IActionResult LoginCliente(PrincipalModel principalModel)
        {

            
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/loginCliente/" + principalModel.Nombre + "&" + principalModel.Contrasena);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            if (responseString == "[]")
            {
                return new JsonResult("NoEncontrado");
            }
            else
            {
                return new JsonResult("Encontrado");
            }
            
           // return new JsonResult("Encontrado");


        } // Login


        [HttpPost]
        public IActionResult ModuloCliente(SesionesModel sesionesModel)
        {

            
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/consultaFecha/" + sesionesModel.gimnasioReserva + "&" + sesionesModel.fechaReserva);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            List<SesionesModel> sesion = new List<SesionesModel>();

            try
            {
                sesion = new List<SesionesModel>();

                //var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                sesion = JsonConvert.DeserializeObject<List<SesionesModel>>(responseString);
                //return respuesta;

            }
            catch
            {

                sesion = new List<SesionesModel>();
                //SesionesModel sesionTemp = new SesionesModel();
                // var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                sesion.Add(JsonConvert.DeserializeObject<SesionesModel>(responseString));
                //return respuesta;
            }


            ViewBag.Sesiones = sesion;

            return View("VerSesiones");


            /*
            SesionesModel sesionTemp = new SesionesModel();
            sesionTemp.fechaReserva = "03-07-2020";
            sesionTemp.gimnasioReserva = "Snake";
            sesionTemp.horario = "06:00:00";
            sesionTemp.cupos = 50;
            sesion.Add(sesionTemp);

            SesionesModel sesionTemp2 = new SesionesModel();
            sesionTemp2.fechaReserva = "08-07-2020";
            sesionTemp2.gimnasioReserva = "Fitnes";
            sesionTemp2.horario = "09:00:00";
            sesionTemp2.cupos = 25;
            sesion.Add(sesionTemp2);

            ViewBag.Sesiones = sesion;

            return View("VerSesiones");
            */
        }


        [HttpPost]
        public IActionResult VerSesiones(ReservarModel reservar)
        {

            
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/reservar/" + reservar.CodSesion + "&" + reservar.NombreCliente);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            

            return new JsonResult("ReservaExitosa ");
           
        }


        [HttpPost]
        public IActionResult PantallaReservas(SesionesModel sesion)
        {

            
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/listarReserva/" + sesion.gimnasioReserva + "&" + sesion.fechaReserva + "&" + sesion.codSesion);            

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            List<ListarSesionesModel> listaSesion = new List<ListarSesionesModel>(); ;

            try
            {
                listaSesion = new List<ListarSesionesModel>();

                //var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaSesion = JsonConvert.DeserializeObject<List<ListarSesionesModel>>(responseString);
                //return respuesta;

            }
            catch
            {
                listaSesion = new List<ListarSesionesModel>();
                //SesionesModel sesionTemp = new SesionesModel();
                // var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaSesion.Add(JsonConvert.DeserializeObject<ListarSesionesModel>(responseString));
                //return respuesta;
            }

           // sesiones.gimnasioReserva, sesiones.horario, sesiones.fechaReserva


            /*
            List<ListarSesionesModel> sesion2 = new List<ListarSesionesModel>();

            ListarSesionesModel ad = new ListarSesionesModel();
            ad.gimnasioReserva = "Fitnnes";
            ad.fechaReserva = "2020-17-03";
            ad.horario = "A LAS 6";

            sesion2.Add(ad);

            ListarSesionesModel ad2 = new ListarSesionesModel();
            ad2.gimnasioReserva = "Fitnnesuhfgas";
            ad.fechaReserva = "2020-17-03";
            ad2.horario = "A LAS 6asasas";
            sesion2.Add(ad2);
            */

            ViewBag.ListarSesionesCliente = listaSesion;

            return View("ListarSesiones");

          

        }


        [HttpPost]
        public IActionResult InfoNegocioGym(SesionesModel sesion)
        {
            
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/consultaClaseOnline/" + sesion.gimnasioReserva);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            List<VerIformeGYMModel> listaSesion = new List<VerIformeGYMModel>(); ;

            try
            {
                listaSesion = new List<VerIformeGYMModel>();

                //var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaSesion = JsonConvert.DeserializeObject<List<VerIformeGYMModel>>(responseString);
                //return respuesta;

            }
            catch
            {
                listaSesion = new List<VerIformeGYMModel>();
                //SesionesModel sesionTemp = new SesionesModel();
                // var json = objReader.ReadToEnd();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaSesion.Add(JsonConvert.DeserializeObject<VerIformeGYMModel>(responseString));
                //return respuesta;
            }





            ViewBag.listarClasesOnile = listaSesion;
             
            //return new JsonResult("Nombre del GYM "+ session.nombre  + " Descripción "+session.descripción + " Ubicación "+session.ubicación);

            return View("VerClasesOnline");

        }


        [HttpPost]
        public IActionResult ClaseOnline(ClaseOnlineModel claseOnline)
        {
                              
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/insertClaseOnline/" + claseOnline.NombreGym + "&" + claseOnline.NombreClase+ "&" + claseOnline.Fecha + "&" + claseOnline.Hora );

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
           

            if (responseString == "[]")
            {
                return new JsonResult("NoInsertado");
            }
            else
            {
                return new JsonResult("Insertado");
            }
                        

            //return new JsonResult(claseOnline.NombreGym + "&" + claseOnline.NombreClase + "&" + claseOnline.Fecha + "&" + claseOnline.Hora);


        }


        [HttpPost]
        public IActionResult VerResumen(SesionesModel resumen)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://webapiproyectotresluisjasson.azurewebsites.net/api/Negocios/verResumen/" + resumen.gimnasioReserva + "&"+ resumen.fechaReserva + "&" + resumen.codSesion);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            var response = (HttpWebResponse)request.GetResponse();

            List<ResumenModel> listaResumen= new List<ResumenModel>(); ;

            try
            {
                listaResumen = new List<ResumenModel>();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaResumen = JsonConvert.DeserializeObject<List<ResumenModel>>(responseString);

            }
            catch
            {
                listaResumen = new List<ResumenModel>();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                listaResumen.Add(JsonConvert.DeserializeObject<ResumenModel>(responseString));

            }


            crearResumenCliente(listaResumen, resumen.gimnasioReserva);
            //ViewBag.listarClasesOnile = listaSesion;

            return new JsonResult("");

            //return View("VerClasesOnline");
        }


        public void crearResumenCliente(List<ResumenModel> resumen, string nombreArchivo)
        {

            Directory.CreateDirectory("wwwroot/resumen/" + nombreArchivo);

            //Crear un PDF
            Document doc = new Document(PageSize.LETTER);

            string ruta = "wwwroot/resumen/" + nombreArchivo + "/ResumenClientes.pdf";
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(ruta, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Luis Brenes");

            // Abrimos el archivo
            doc.Open();

            //Escribir sobre el PDF
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Resumen de los clientes"));
            doc.Add(Chunk.NEWLINE);

            PdfPCell nombreGym;
            PdfPCell fechaReserva;
            PdfPCell horario;
            PdfPCell nombreCliente;

            for (int i = 0; i < resumen.Count(); i++) {
                PdfPTable tblPrueba = new PdfPTable(4);
                tblPrueba.WidthPercentage = 80;

                // Configuramos el título de las columnas de la tabla
                if (i == 0)
                {
                    nombreGym = new PdfPCell(new Phrase("Nombre gimnasio", _standardFont));
                    nombreGym.BorderWidth = 0;
                    nombreGym.BorderWidthBottom = 0.75f;

                    fechaReserva = new PdfPCell(new Phrase("Fecha reserva", _standardFont));
                    fechaReserva.BorderWidth = 0;
                    fechaReserva.BorderWidthBottom = 0.75f;

                    horario = new PdfPCell(new Phrase("Horario", _standardFont));
                    horario.BorderWidth = 0;
                    horario.BorderWidthBottom = 0.75f;

                    nombreCliente = new PdfPCell(new Phrase("Nombre cliente", _standardFont));
                    nombreCliente.BorderWidth = 0;
                    nombreCliente.BorderWidthBottom = 0.75f;

                    tblPrueba.AddCell(nombreGym);
                    tblPrueba.AddCell(fechaReserva);
                    tblPrueba.AddCell(horario);
                    tblPrueba.AddCell(nombreCliente);
                }

                // Añadimos las celdas a la tabla
               
                

                // Llenamos la tabla con información
                nombreGym = new PdfPCell(new Phrase(resumen[i].gimnasioReserva, _standardFont));
                nombreGym.BorderWidth = 0;

                fechaReserva = new PdfPCell(new Phrase(resumen[i].fechaReserva, _standardFont));
                fechaReserva.BorderWidth = 0;

                horario = new PdfPCell(new Phrase(resumen[i].horario, _standardFont));
                horario.BorderWidth = 0;

                nombreCliente = new PdfPCell(new Phrase(resumen[i].nombreCliente, _standardFont));
                nombreCliente.BorderWidth = 0;

                tblPrueba.AddCell(nombreGym);
                tblPrueba.AddCell(fechaReserva);
                tblPrueba.AddCell(horario);
                tblPrueba.AddCell(nombreCliente);
                doc.Add(tblPrueba);


            }

            doc.Close();
            writer.Close();


            /*
            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);
             doc.Add(tblPrueba);
            */




        }



        public IActionResult PantallaReservas()
        {

            return View();
        }


        public IActionResult InfoNegocioGym()
        {

            return View();
        }


        public IActionResult ModuloAdmin()
        {

            return View();
        }


        public IActionResult LoginCliente()
        {

            return View();
        }

        public IActionResult ModuloCliente()
        {

            return View();
        }     


        public IActionResult ClaseOnline()
        {

            return View();
        }


        public IActionResult VerResumen()
        {

            return View();
        }

        
    }

}

