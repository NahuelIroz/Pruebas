namespace WebAPI.DTOs
{
    public class FuenteFinanciamientoAltaDTO
    { 
        public double saldo { get; set; } 
        public string motivo { get; set; }
        public DateTime fecha_acreditacion { get; set; }
        public string observaciones { get; set; }
        public int tipoFondoId { get; set; }
        public int proyectoId { get; set; }
    }
}
