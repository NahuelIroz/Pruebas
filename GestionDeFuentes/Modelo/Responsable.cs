using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Modelo
{
    public class Responsable
    {
        [Column("idResponsable")]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public bool baja { get; set; }
        [ForeignKey("idFuenteFinanciamiento")]
        //[JsonIgnore]
        public virtual FuenteFinanciamiento FuenteFinanciamiento { get; set; }
    }
}
