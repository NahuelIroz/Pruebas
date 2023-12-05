using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionDeFuentes.Modelo
{
    public class TipoFondo
    {
        [Column("idTipoFondo")]
        public int id { get; set; }
        public int codigo { get; set; }  
        public string  descripcion { get; set; }
        public bool baja { get; set; }
    }
}
