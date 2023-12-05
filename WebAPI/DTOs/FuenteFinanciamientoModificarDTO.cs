namespace WebAPI.DTOs
{
    public class FuenteFinanciamientoModificarDTO
    {
        public int id { get; set; }
        public double saldo { get; set; }
        public DateTime fecha_acreditacion { get; set; }
        public string motivo { get; set; } 
        public string observaciones { get; set; }
        public int tipoFondoId { get; set; }
        public int proyectoId { get; set; }
    }
}
