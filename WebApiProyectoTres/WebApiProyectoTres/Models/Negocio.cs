using System;
using System.Collections.Generic;

namespace WebApiProyectoTres.Models
{
    public partial class Negocio
    {
        public int IdNegocio { get; set; }
        public string NombreNegocio { get; set; }
        public string Contrasena { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public TimeSpan HorarioA { get; set; }
        public TimeSpan HorarioC { get; set; }
        public int CapacidadMaxima { get; set; }
        public int PorcentajePermitido { get; set; }
       /* public string Logo { get; set; }
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public string Imagen4 { get; set; }
        public string Imagen5 { get; set; }*/
    }
}
