using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeFuentes.Modelo
{
    public class FuenteFinanciamiento
    {
        [Column("idFuenteFinanciamiento")]
        public int id { get; set; }
        public double saldo { get; set; }
        public DateTime fecha_acreditacion { get; set; }
        public string motivo { get; set; }
        public bool baja { get; set; } 
        public string observaciones { get; set; }
        [ForeignKey("idTipoFondo")]
        public virtual TipoFondo tipoFondo { get; set; }  

        [ForeignKey("idProyecto")]
        //[JsonIgnore]
        public virtual Proyecto proyecto { get; set; }

        public virtual List<Responsable> responsables { get; set; }
        public virtual List<Movimiento> movimientos { get; set; }
    }
}
