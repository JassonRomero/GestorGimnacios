using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Models
{
    public class PrincipalModel
    {
       
        public string Nombre { get; set; }

        public string Contrasena { get; set; }

        public string Ubicacion { get; set; }

        public string Descripcion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public TimeSpan HorarioA { get; set; }

        public TimeSpan HorarioC { get; set; }

        public int Capacidad { get; set; }

        public int Porcentaje { get; set; }

        public IFormFile Logo { get; set; }

        public IFormFile Imagen1 { get; set; }

        public IFormFile Imagen2 { get; set; }

        public IFormFile Imagen3 { get; set; }

        public IFormFile Imagen4 { get; set; }

        public IFormFile Imagen5 { get; set; }

    }
}
