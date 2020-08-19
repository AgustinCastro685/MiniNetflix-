using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniNext.Models
{
    public class Documental : Contenido
    {
        public string GeneroDocumental { get; set; }
        public string Descripcion { get; set; }
        public string ImageFile { get; set; }
        public string Imageroute { get; set; }
    }
}
