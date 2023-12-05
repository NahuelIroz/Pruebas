using GestionDeFuentes.Modelo;

namespace WebAPI.DTOs
{
    public class FuenteFinanciamientoDTO
    {
        public int id { get; set; }
        public double saldo { get; set; }
        public DateTime fecha_acreditacion { get; set; }
        public string motivo { get; set; }
        public bool baja { get; set; }
        public string observaciones { get; set; }
        public TipoFondoDTO tipoFondo { get; set; } 
        public virtual ProyectoDTO proyecto { get; set; } 
        public virtual List<ResponsableDTO> responsables { get; set; }
        public virtual List<MovimientoDTO> movimientos { get; set; }
    }
}
