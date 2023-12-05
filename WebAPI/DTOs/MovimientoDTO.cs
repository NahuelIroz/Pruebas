using GestionDeFuentes.Modelo;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs
{
    public class MovimientoDTO
    {
        public int id { get; set; }
        public double saldo { get; set; }
        public bool baja { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public TipoMovimientoDTO tipoMovimiento { get; set; } 
        public virtual FuenteFinanciamientoDTO fuenteFinanciamiento { get; set; }
    }
}
