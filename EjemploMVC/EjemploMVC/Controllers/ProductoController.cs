using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using EjemploMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EjemploMVC.Controllers
{
    
    public class ProductoController : Controller
    {
        public IConfiguration Configuration { get; }

        public ProductoController(IConfiguration configuration) {
            Configuration = configuration;
        } // constructor

        //[Route("nuevadireccion")]
        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Listar()
        {


            List<ProductoModel> productos = new List<ProductoModel>();

            if (ModelState.IsValid) {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    string sqlQuery = $"exec sp_listar";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection)) {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader productoReader = command.ExecuteReader();
                        while (productoReader.Read())
                        {
                            ProductoModel productoTemp = new ProductoModel();
                            productoTemp.Id = Int32.Parse(productoReader["id"].ToString());
                            productoTemp.Nombre = productoReader["nombre"].ToString();

                            productos.Add(productoTemp);
                        } // while
                        connection.Close();
                    }
                }


            } // ModelState.IsValid

            ViewBag.Productos = productos;

            return View();
        }

        public IActionResult Registrar() {

            return View();
        }

        [HttpPost]
        public IActionResult Registrar(ProductoModel productoModel)
        {

            if (ModelState.IsValid) {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);
                string sqlQuery = $"exec sp_registrar_producto @nombre='{productoModel.Nombre}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection)) { 
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }

            } // ModelState.IsValid


            return View();
        } // Registrar

        public IActionResult RegistrarAjax()
        {

            return View();
        }

        [HttpPost]
        public IActionResult RegistrarAjax(ProductoModel productoModel)
        {
            if (ModelState.IsValid)
            {
                string connectionString = Configuration["ConnectionStrings:DB_Connection"];
                var connection = new SqlConnection(connectionString);
                string sqlQuery = $"exec sp_registrar_producto @nombre='{productoModel.Nombre}'";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }

            } // ModelState.IsValid

            return new JsonResult("Producto Registrado");

        } // RegistrarAjax

    } // fin clase
}
