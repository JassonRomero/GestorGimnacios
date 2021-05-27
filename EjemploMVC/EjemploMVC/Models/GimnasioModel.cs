using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploMVC.Models
{
    public class GimnasioModel
    {
        [JsonProperty(PropertyName = "nombre_negocio")]
        public string nombre_negocio { get; set; }
        public string Ubicacion { get; set; }
    }
}
