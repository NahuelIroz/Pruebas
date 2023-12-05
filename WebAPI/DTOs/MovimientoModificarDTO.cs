using GestionDeFuentes.Modelo;

namespace WebAPI.DTOs
{
    public class MovimientoModificarDTO
    {
        public int id { get; set; }
        public double saldo { get; set; } 
        public string descripcion { get; set; } 
        public int tipoMovimientoId { get; set; } 

    }
}
