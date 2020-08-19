using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniNext.Models
{
    public class Pelicula : Contenido
    {
        public string Descripcion { get; set; }
        public string ImageFile { get; set; }
        public string Imageroute { get; set; }
    }
}