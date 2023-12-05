using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Modelo
{
    public class Proyecto
    {
        [Column("idProyecto")]
        public int id { get; set; }
        public string nombre { get; set; } 
        public bool baja { get; set; } 
        public virtual List<FuenteFinanciamiento> fuentesFinanciamiento { get; set; }
    }
}
