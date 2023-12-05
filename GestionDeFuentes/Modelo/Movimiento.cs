using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeFuentes.Modelo
{
    public class Movimiento
    {
        [Column("idMovimiento")]
        public int id { get; set; }
        public double saldo { get; set; }
        public bool baja { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("idTipoMovimiento")]
        public virtual TipoMovimiento tipoMovimiento { get; set; }

        [ForeignKey("idFuenteFinanciamiento")]
        //[JsonIgnore]
        public virtual FuenteFinanciamiento fuenteFinanciamiento { get; set; }
    }
}
