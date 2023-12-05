namespace WebAPI.DTOs
{
    public class MovimientoAltaDTO
    { 
        public double saldo { get; set; } 
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public int tipoMovimientoId { get; set; }
        public int fuenteFinanciamientoId { get; set; }
    }
}
